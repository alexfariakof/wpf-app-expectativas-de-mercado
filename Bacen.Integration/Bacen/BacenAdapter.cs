using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PixCharge.Integration.Adapter.Plataform.OpenPix.Models;
using Bacen.Integration.Converters;
using Bacen.Integration.Bacen.Model;

namespace Bacen.Integration.Bacen;
public class BacenAdapter : IExpectativasMercados
{
    private const string baseUrl = "https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/ExpectativaMercadoMensais";    
    public async Task<List<ExpectativasMercadoMensal>> GetExpectativasMercadoMensais(Indicador indicador, DateTime dtInicial, DateTime dtFinal)
    {
        using (HttpClient client = new HttpClient())
        {
            var formattedDtInicial = dtInicial.ToString("yyyy-MM-dd");
            var formattedDtFinal = dtFinal.ToString("yyyy-MM-dd");

            var filter = $"?$top=10000&$filter=Indicador%20eq%20'{indicador.Descricao}'%20and%20Data%20gt%20'{formattedDtInicial}'%20and%20Data%20lt%20'{formattedDtFinal}'&$orderby=Data desc";

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
}
