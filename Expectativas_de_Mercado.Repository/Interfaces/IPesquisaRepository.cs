using Expectativas_de_Mercado.Model.Aggregates;

namespace Expectativas_de_Mercado.Repository.Interfaces;
public interface IPesquisaRepository
{
    List<Pesquisa> GetAll();
    Pesquisa GetById(Guid id);    
    Pesquisa Insert(Pesquisa pesquisa);
    bool Delete(Pesquisa pesquisa);
}