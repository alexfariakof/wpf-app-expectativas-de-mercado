using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Model.ValueObjects;

namespace Expectativas_de_Mercado.Model.Model.Aggregates;
public class ExpectativasMercadoMensais : Base
{
    Indicador Indicador { get; set; } = new Indicador();
    DateTime Data {  get; set; }
    DateTime DataReferencia { get; set; }
    Media Media { get; set; } = new Media();
    Mediana Mediana { get; set; } = new  Mediana();
    DesvioPadrao DesvioPadrao { get; set; } = new DesvioPadrao();
    decimal Minimo { get; set; }
    decimal Maximo { get; set; }
    int NumeroRespondentes { get; set; }
    int BaseCalculo { get; set; }    
}
