using Bogus;
using Expectativas_de_Mercado.Model.Core;

namespace HomeBrokerXUnit.Faker;

/// <summary>
/// Classe responsável por gerar dados falsos (fakes) para a entidade Indicador.
/// </summary>
public class IndicadorFaker
{
    /// <summary>
    /// Gera uma nova instância falsa de Indicador.
    /// </summary>
    /// <returns>Uma instância falsa de Indicador.</returns>
    public static Indicador GetNewFaker()
    {
        return new Faker<Indicador>()
            .RuleFor(i => i.Id, f => f.PickRandom<Indicador_Id>())
            .RuleFor(i => i.Descricao, f => f.Lorem.Sentence())
            .Generate();
    }
}
