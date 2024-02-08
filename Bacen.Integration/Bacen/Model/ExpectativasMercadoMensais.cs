namespace Bacen.Integration.Converters.Model;

[Serializable]
public sealed class ExpectativasMercadoMensais
{
    public string Indicador { get; set; } = String.Empty;
    public DateTime? Data { get; set; }
    public DateTime? DataReferencia { get; set; }
    public string Reuniao { get; set; } = String.Empty;
    public double Media { get; set; } 
    public double Mediana { get; set; }
    public double DesvioPadrao { get; set; }
    public double Minimo { get; set; }
    public double Maximo { get; set; }
    public int NumeroRespondentes { get; set; }
    public int BaseCalculo { get; set; }
}
