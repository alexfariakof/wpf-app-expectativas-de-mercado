using Bacen.Integration.Converters.Model;
using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Model.ValueObjects;

namespace Bacen.Integration.Converters;
internal class ExpectativasMercadoMensaisParser : IParser<ExpectativasMercadoMensais, ExpectativasMercado>
{
    public ExpectativasMercado Parse(ExpectativasMercadoMensais origin)
    {
        if (origin == null) return new ExpectativasMercado();
        var objtoConvert = new ExpectativasMercado();

        objtoConvert.Indicador = new Indicador(origin.Indicador) ;
        objtoConvert.Data = origin.Data;
        objtoConvert.DataReferencia = origin.DataReferencia;
        objtoConvert.Reuniao= origin.Reuniao;
        objtoConvert.Media = new Media { Value = origin.Media };
        objtoConvert.Mediana = new Mediana { Value = origin.Mediana };
        objtoConvert.DesvioPadrao = new DesvioPadrao { Value  = origin.DesvioPadrao };
        objtoConvert.Minimo = origin.Minimo;
        objtoConvert.Maximo = origin.Maximo;
        objtoConvert.NumeroRespondentes = origin.NumeroRespondentes;
        objtoConvert.BaseCalculo = origin.BaseCalculo;
        return objtoConvert;
    }
    public List<ExpectativasMercado> ParseList(List<ExpectativasMercadoMensais> origin)
    {
        if (origin == null) return new List<ExpectativasMercado>();
        return origin.Select(item => Parse(item)).ToList();
    }
}
