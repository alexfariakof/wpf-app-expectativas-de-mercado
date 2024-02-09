using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /// <summary>
    /// Contexto do banco de dados para o registro de entidades como Indicador e ExpectativasMercado.
    /// </summary>
    #pragma warning disable CS8618 //  Non-nullable property.
    public class RegisterContext : DbContext
    {
        /// <summary>
        /// Construtor que aceita opções de configuração do DbContext.
        /// </summary>
        /// <param name="options">Opções de configuração do DbContext.</param>
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }

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
        public DbSet<Pesquisa> Pesquisa{ get; set; }

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
}