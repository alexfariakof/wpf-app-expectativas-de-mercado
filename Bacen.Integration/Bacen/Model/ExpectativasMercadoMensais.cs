namespace Bacen.Integration.Converters.Model;

[Serializable]
public sealed class ExpectativasMercadoMensais
{
    public string Indicador { get; set; } = String.Empty;
    public DateTime? Data { get; set; }
    public DateTime? DataReferencia { get; set; }
    public string Reuniao { get; set; } = String.Empty;
    public decimal Media { get; set; } 
    public decimal Mediana { get; set; }
    public decimal DesvioPadrao { get; set; }
    public decimal Minimo { get; set; }
    public decimal Maximo { get; set; }
    public int NumeroRespondentes { get; set; }
    public int BaseCalculo { get; set; }
}
