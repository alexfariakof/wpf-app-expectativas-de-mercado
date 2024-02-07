using System.Net.Http.Headers;
using Newtonsoft.Json;
using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Bacen.Integration.Converters;
using Bacen.Integration.Bacen.Model;

namespace Bacen.Integration.Bacen;
public class BacenAdapter : IExpectativasMercados
{
    private const string baseUrl = "https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/";
    public async Task<List<ExpectativasMercadoMensal>> GetExpectativasMercadoMensais(Indicador indicador, DateTime dtInicial, DateTime dtFinal)
    {                
        try
        {            
            using (HttpClient client = new HttpClient())
            {
                var endPoint = indicador.Id == Indicador_Id.Selic ? "ExpectativasMercadoSelic" : "ExpectativaMercadoMensais";
                var formattedDtInicial = dtInicial.ToString("yyyy-MM-dd");
                var formattedDtFinal = dtFinal.ToString("yyyy-MM-dd");                
                var orderBy = indicador.Id == Indicador_Id.Selic ? "&$orderby=Data asc" : "&$orderby=Data asc,DataReferencia asc";
                var filter = $"{endPoint}?$top=10000&$filter=Indicador%20eq%20'{indicador.Descricao}'%20and%20Data%20gt%20'{formattedDtInicial}'%20and%20Data%20lt%20'{formattedDtFinal}'{orderBy}";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}{filter}"))
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(new { }));
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    using (HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var data = JsonConvert.DeserializeObject<ResponseObject>(responseBody);
                        var expectativasMercadosMensais = new ExpectativasMercadoMensaisParser().ParseList(data.Value);
                        return expectativasMercadosMensais ?? new();
                    }
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}
