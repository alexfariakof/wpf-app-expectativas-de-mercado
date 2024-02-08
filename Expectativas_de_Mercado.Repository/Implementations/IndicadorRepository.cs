using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Expectativas_de_Mercado.Repository.Implementations;
public class IdicadorRepository: IIndicadorRepository
{
    private readonly RegisterContext _context;
    private DbSet<Indicador> dataSet;
    public IdicadorRepository(RegisterContext context)
    {
        _context = context;
        dataSet = context.Set<Indicador>();
    }

    public List<Indicador> GetAll()
    {
        try
        {
            return dataSet.ToList();
        }
        catch
        {
            throw new ArgumentException("Indicador_Repositorio_Get");
        }
    }

    public Indicador GetById(int id)
    {
        try
        {
            return dataSet.Where(i => ((int)i.Id) == id).First();
        }
        catch
        {
            throw new ArgumentException("Indicador_Repositorio_GetById");
        }
    }
}