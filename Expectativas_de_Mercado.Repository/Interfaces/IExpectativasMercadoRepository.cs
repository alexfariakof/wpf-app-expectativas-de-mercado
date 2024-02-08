using Expectativas_de_Mercado.Model.Aggregates;

namespace Expectativas_de_Mercado.Repository.Interfaces;
public interface IExpectativasMercadoRepository
{
    ExpectativasMercado Insert(ExpectativasMercado expectativasMercado);
    List<ExpectativasMercado> Get(DateTime dtInicial, DateTime dtFinal);
    bool Exists(DateTime dtInicial, DateTime dtFinal);
}
