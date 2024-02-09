using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Repository;

/// <summary>
/// Contexto do banco de dados para o registro de entidades como Indicador e ExpectativasMercado.
/// </summary>
#pragma warning disable CS8629 // Nullable value type may be null.
public class RegisterContext : DbContext
{
    private static RegisterContext _instance;
    private static readonly object _lock = new object();

    public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }

    public static RegisterContext Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<RegisterContext>();
                    optionsBuilder.UseSqlServer("Data Source=127.0.0.1, 1433;Initial Catalog=ExpectativasMercadoDB;User Id=sa;Password=!aA12345;");
                    _instance = new RegisterContext(optionsBuilder.Options);
                }
                return _instance;
            }
        }
    }

    /// <summary>
    /// Conjunto de dados para a entidade Indicador.
    /// </summary>
    public DbSet<Indicador> Indicador { get; set; }

    /// <summary>
    /// Conjunto de dados para a entidade ExpectativasMercado.
    /// </summary>
    public DbSet<ExpectativasMercado> ExpectativasMercado { get; set; }

    /// <summary>
    /// Conjunto de dados para a entidade Pesquisa.
    /// </summary>
    public DbSet<Pesquisa> Pesquisa { get; set; }

    /// <summary>
    /// Configuração do modelo de entidade no contexto do banco de dados.
    /// </summary>
    /// <param name="modelBuilder">Construtor de modelo utilizado para configurar as entidades.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica configurações específicas do mapeamento para as entidades Indicador e ExpectativasMercado.
        modelBuilder.ApplyConfiguration(new IndicadorMap());
        modelBuilder.ApplyConfiguration(new ExpectativasMercadoMap());
        modelBuilder.ApplyConfiguration(new PesquisaMap());
    }
}
