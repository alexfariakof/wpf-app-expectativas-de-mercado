using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Model.ValueObjects;
using PixCharge.Integration.Adapter.Converters;
using PixCharge.Integration.Adapter.Plataform.OpenPix.Models;

namespace Bacen.Integration.Converters;
internal class ExpectativasMercadoMensaisParser : IParser<ExpectativasMercadoMensais, ExpectativasMercadoMensal>
{
    public ExpectativasMercadoMensal Parse(ExpectativasMercadoMensais origin)
    {
        if (origin == null) return new ExpectativasMercadoMensal();
        var objtoConvert = new ExpectativasMercadoMensal();

        objtoConvert.Indicador = new Indicador { Descricao = origin.Indicador };
        objtoConvert.Data = origin.Data;
        objtoConvert.DataReferencia = origin.DataReferencia;
        objtoConvert.Media = new Media { Value = origin.Media };
        objtoConvert.Mediana = new Mediana { Value = origin.Mediana };
        objtoConvert.DesvioPadrao = new DesvioPadrao { Value  = origin.DesvioPadrao };
        objtoConvert.Minimo = origin.Minimo;
        objtoConvert.Maximo = origin.Maximo;
        objtoConvert.NumeroRespondentes = origin.NumeroRespondentes;
        objtoConvert.BaseCalculo = origin.BaseCalculo;
        return objtoConvert;
    }
    public List<ExpectativasMercadoMensal> ParseList(List<ExpectativasMercadoMensais> origin)
    {
        if (origin == null) return new List<ExpectativasMercadoMensal>();
        return origin.Select(item => Parse(item)).ToList();
    }
}
