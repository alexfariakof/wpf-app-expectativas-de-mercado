using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Expectativas_de_Mercado.Repository.Implementations;
public class PesquisaRepository : IPesquisaRepository
{
    private readonly RegisterContext _context;
    private DbSet<Pesquisa> dataSet;
    public PesquisaRepository()
    {
        _context = RegisterContext.Instance;
        dataSet = _context.Set<Pesquisa>();
    }
    public List<Pesquisa> GetAll()
    {
        try
        {
            return dataSet.ToList();
        }
        catch
        {
            throw new ArgumentException("Pesquisa_Repositorio_Get");
        }
    }

    public Pesquisa GetById(Guid id)
    {
        try
        {
            return dataSet.Where(p => p.Id == id).First();
        }
        catch
        {
            throw new ArgumentException("Pesquisa_Repositorio_GetById");
        }
    }
    public Pesquisa Insert(Pesquisa pesquisa)
    {
        try
        {
            dataSet.Add(pesquisa);
            _context.SaveChanges();
        }
        catch
        {
            throw new ArgumentException("Pesquisa_Repositorio_Insert"); ;
        }
        return pesquisa;
    }

    public bool Delete(Pesquisa pesquisa)
    {
        try
        {
            var result = dataSet.SingleOrDefault(prop => prop.Id.Equals(pesquisa.Id));
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception("Pesquisa_Repositorio_Delete", ex);
        }
    }
}