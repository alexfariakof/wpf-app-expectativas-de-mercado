using Bogus;
using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.ValueObjects;

namespace HomeBrokerXUnit.Faker;

/// <summary>
/// Classe responsável por gerar dados falsos (fakes) para a entidade ExpectativasMercado.
/// </summary>
internal class ExpectativasMercadoFaker
{
    /// <summary>
    /// Gera uma nova instância falsa de ExpectativasMercado.
    /// </summary>
    /// <returns>Uma instância falsa de ExpectativasMercado.</returns>
    internal static ExpectativasMercado GetNewFaker()
    {
        return new Faker<ExpectativasMercado>()
            .RuleFor(e => e.Indicador, f => IndicadorFaker.GetNewFaker())
            .RuleFor(e => e.Data, f => f.Date.Recent())
            .RuleFor(e => e.DataReferencia, f => f.Date.Future())
            .RuleFor(e => e.Reuniao, f => f.Lorem.Word())
            .RuleFor(e => e.Media, f => new Media(f.Random.Decimal(1, 10)))
            .RuleFor(e => e.Mediana, f => new Mediana(f.Random.Decimal(1, 10)))
            .RuleFor(e => e.DesvioPadrao, f => new DesvioPadrao(f.Random.Decimal(1, 10)))
            .RuleFor(e => e.Minimo, f => f.Random.Decimal())
            .RuleFor(e => e.Maximo, f => f.Random.Decimal())
            .RuleFor(e => e.NumeroRespondentes, f => f.Random.Int(1, 100))
            .RuleFor(e => e.BaseCalculo, f => f.Random.Int(100, 1000))
            .Generate();
    }

    /// <summary>
    /// Gera uma lista de instâncias falsas de ExpectativasMercado.
    /// </summary>
    /// <param name="count">O número de instâncias a serem geradas na lista.</param>
    /// <returns>Uma lista de instâncias falsas de ExpectativasMercado.</returns>
    internal static List<ExpectativasMercado> GetListFaker(int count)
    {
        List<ExpectativasMercado> listFaker = new List<ExpectativasMercado>();

        for (int i = 0; i < count; i++)
            listFaker.Add(GetNewFaker());

        return listFaker;
    }
}
