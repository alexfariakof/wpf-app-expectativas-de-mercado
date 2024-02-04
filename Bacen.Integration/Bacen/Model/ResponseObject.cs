using Newtonsoft.Json;
using PixCharge.Integration.Adapter.Plataform.OpenPix.Models;

namespace Bacen.Integration.Bacen.Model;
public class ResponseObject
{
    [JsonProperty("@odata.context")]
    public string ODataContext { get; set; } = String.Empty;

    [JsonProperty("value")]
    public List<ExpectativasMercadoMensais> Value { get; set; } = new();
}