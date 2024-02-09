using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Expectativas_de_Mercado.Repository.Implementations;
public class PesquisaRepository : IPesquisaRepository
{
    private readonly RegisterContext _context;
    private DbSet<Indicador> dsIndicador;
    private DbSet<Pesquisa> dsPesquisa;
    private DbSet<ExpectativasMercado> dsExpecativadasMercado;
    public PesquisaRepository()
    {
        _context = RegisterContext.Instance;
        dsIndicador = _context.Set<Indicador>();
        dsPesquisa = _context.Set<Pesquisa>();
        dsExpecativadasMercado = _context.Set<ExpectativasMercado>();
}
    public List<Pesquisa> GetAll()
    {
        try
        {
            var pesquisas = dsPesquisa.ToList();
            foreach (var item in pesquisas)
                item.Indicador = dsIndicador.Where(i => i.Id.Equals(item.IndicadorId)).First();
            return pesquisas;
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
            return dsPesquisa.Where(p => p.Id == id).First();
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
            pesquisa.Indicador = dsIndicador.Where(i => i == pesquisa.Indicador).First();
            dsPesquisa.Add(pesquisa);
            foreach (var item in pesquisa.ExpectativasMercados)
            {
                item.Indicador = pesquisa.Indicador;
                item.IndicadorId = pesquisa.Indicador.Id;
            }
            dsExpecativadasMercado.AddRange(pesquisa.ExpectativasMercados);
            _context.SaveChanges();
        }
        catch(Exception ex)
        {
            throw new ArgumentException("Pesquisa_Repositorio_Insert", ex);
        }
        return pesquisa;
    }

    public bool Delete(Pesquisa pesquisa)
    {
        try
        {
            var result = dsPesquisa.SingleOrDefault(prop => prop.Id.Equals(pesquisa.Id));
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

    public List<ExpectativasMercado> GetExpectativasMercadoPesquisadas(Guid id)
    {
        try
        {
            var expectativasPesquisadas = dsExpecativadasMercado.Where(prop => prop.PesquisaId.Equals(id)).ToList();
            foreach (var item in expectativasPesquisadas)
                item.Indicador = dsIndicador.Where(i => i.Id.Equals(item.IndicadorId)).First();
            return expectativasPesquisadas;
        }
        catch
        {
            throw new ArgumentException("Pesquisa_Repositorio_GetExpectativasMercadoPesquisadas");
        }

    }
}