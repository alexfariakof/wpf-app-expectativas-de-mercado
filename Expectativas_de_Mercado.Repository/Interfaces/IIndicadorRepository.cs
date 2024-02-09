using Expectativas_de_Mercado.Model.Core;

namespace Expectativas_de_Mercado.Repository.Interfaces;
public interface IIndicadorRepository
{
    List<Indicador> GetAll();
    Indicador GetById(int id);
}