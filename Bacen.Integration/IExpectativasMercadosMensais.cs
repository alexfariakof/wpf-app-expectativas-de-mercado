using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;

namespace Bacen.Integration;
public interface IExpectativasMercadosMensais
{
    public Task<List<ExpectativasMercado>> GetExpectativasMercadoMensais(Indicador indicador, DateTime dtInicial, DateTime dtFinal);

}
