using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Data;

namespace Expectativas_de_Mercado.Repository.Implementations;
public class ExpectativasMercadoRepository : IExpectativasMercadoRepository
{
    private readonly RegisterContext _context;
    private DbSet<ExpectativasMercado> dataSet;
    public ExpectativasMercadoRepository()
    {
        _context = RegisterContext.Instance;
        dataSet = _context.Set<ExpectativasMercado>();
    }
    public bool Exists(DateTime dtInicial, DateTime dtFinal)
    {
        try
        {
            var mindate = dataSet.Select(em => em.Data).Min().Value;
            var maxdate = dataSet.Select(em => em.Data).Max().Value;
            return (mindate == dtInicial && maxdate == dtFinal);
        }
        catch 
        {
            return false;
        }        
    }

    public List<ExpectativasMercado> Get(DateTime dtInicial, DateTime dtFinal)
    {
        try
        {
            return dataSet.Where(em => em.Data >= dtInicial && em.Data <= dtFinal).ToList();
        }
        catch 
        {
            throw new ArgumentException("ExpectativasMercado_Repositorio_Get");
        }
    }

    public ExpectativasMercado Insert(ExpectativasMercado expectativasMercado)
    {
        try
        {
            dataSet.Add(expectativasMercado);
            _context.SaveChanges();
        }
        catch 
        {
            throw new ArgumentException("expectativasMercado_Repositorio_Insert"); ;
        }
        return expectativasMercado;
    }
}