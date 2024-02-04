using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;

namespace Bacen.Integration;

public interface IExpectativasMercados
{
    public Task<List<ExpectativasMercadoMensal>> GetExpectativasMercadoMensais(Indicador indicador, DateTime dtInicial, DateTime dtFinal);

}
