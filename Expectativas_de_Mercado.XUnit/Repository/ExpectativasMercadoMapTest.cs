using Expectativas_de_Mercado.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Expectativas_de_Mercado.Repository.Mapping;

namespace Repository.Mapping;
public class ExpectativasMercadoMapTest
{
    [Fact]
    public void Entity_Configuration_IsValid()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase_ExpectativasMercadoMapTest")
            .Options;

        using (var context = new DbContext(options))
        {
            var builder = new ModelBuilder(new ConventionSet());
            var configuration = new ExpectativasMercadoMap();

            configuration.Configure(builder.Entity<ExpectativasMercado>());

            var model = builder.Model;
            var entityType = model.FindEntityType(typeof(ExpectativasMercado));

            // Act
            var idProperty = entityType?.FindProperty("Id");
            var dataProperty = entityType?.FindProperty("Data");
            var dataReferenciaProperty = entityType?.FindProperty("DataReferencia");
            var reuniaoProperty = entityType?.FindProperty("Reuniao");
            var mediaProperty = entityType?.FindNavigation(nameof(ExpectativasMercado.Media));
            var medianaProperty = entityType?.FindNavigation(nameof(ExpectativasMercado.Mediana));
            var desvioPadraoProperty = entityType?.FindNavigation(nameof(ExpectativasMercado.DesvioPadrao));
            var minimoProperty = entityType?.FindProperty("Minimo");
            var maximoProperty = entityType?.FindProperty("Maximo");
            var numeroRespondentesProperty = entityType?.FindProperty("NumeroRespondentes");
            var baseCalculoProperty = entityType?.FindProperty("BaseCalculo");

            // Assert
            Assert.NotNull(idProperty);
            Assert.NotNull(dataProperty);
            Assert.NotNull(dataReferenciaProperty);
            Assert.NotNull(reuniaoProperty);
            Assert.NotNull(mediaProperty);
            Assert.NotNull(medianaProperty);
            Assert.NotNull(desvioPadraoProperty);
            Assert.NotNull(minimoProperty);
            Assert.NotNull(maximoProperty);
            Assert.NotNull(numeroRespondentesProperty);
            Assert.NotNull(baseCalculoProperty);
        }
    }
}
