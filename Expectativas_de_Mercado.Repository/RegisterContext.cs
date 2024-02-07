using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class RegisterContext: DbContext
{
    public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }
    public DbSet<IPCA> IPCA { get; set; } = null;
    public DbSet<IGPM> IGPM { get; set; } = null;
    public DbSet<Selic> Selic { get; set; } = null;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new IPCAMap());
        modelBuilder.ApplyConfiguration(new IGPMMap());
        modelBuilder.ApplyConfiguration(new SelicMap());
    }
}
