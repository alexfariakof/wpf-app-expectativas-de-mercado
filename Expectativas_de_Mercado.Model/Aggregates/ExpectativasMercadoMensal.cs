using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Model.ValueObjects;

namespace Expectativas_de_Mercado.Model.Aggregates;
public class ExpectativasMercadoMensal : Base
{
    public Indicador Indicador { get; set; } = new Indicador();
    public DateTime? Data {  get; set; }
    public DateTime? DataReferencia { get; set; }
    public string Reuniao { get; set; } = String.Empty;
    public Media Media { get; set; } = new Media();
    public Mediana Mediana { get; set; } = new  Mediana();
    public DesvioPadrao DesvioPadrao { get; set; } = new DesvioPadrao();
    public decimal Minimo { get; set; }
    public decimal Maximo { get; set; }
    public int NumeroRespondentes { get; set; }
    public int BaseCalculo { get; set; }    
}
