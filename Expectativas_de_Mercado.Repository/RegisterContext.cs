using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class RegisterContext: DbContext
{
    public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }
    public DbSet<Indicador> Indicador { get; set; } = null;
    public DbSet<ExpectativasMercado> ExpectativasMercado { get; set; } = null;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new IndicadorMap());
        modelBuilder.ApplyConfiguration(new ExpectativasMercadoMap());
    }
}
