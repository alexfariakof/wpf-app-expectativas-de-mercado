using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Repository.Mapping;
public class IndicadorMapTest
{
    [Fact]
    public void Entity_Configuration_IsValid()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase_IndicadorMapTest")
            .Options;

        using (var context = new DbContext(options))
        {
            var builder = new ModelBuilder(new ConventionSet());
            var configuration = new IndicadorMap();

            configuration.Configure(builder.Entity<Indicador>());

            var model = builder.Model;
            var entityType = model.FindEntityType(typeof(Indicador));

            // Act
            var idProperty = entityType?.FindProperty("Id");
            var descricaoProperty = entityType?.FindProperty("Descricao");
            var expectativasMercadosNavigation = entityType?.FindNavigation(nameof(Indicador.ExpectativasMercados));

            // Assert
            Assert.NotNull(idProperty);
            Assert.NotNull(descricaoProperty);
            Assert.NotNull(expectativasMercadosNavigation);
        }
    }
}
