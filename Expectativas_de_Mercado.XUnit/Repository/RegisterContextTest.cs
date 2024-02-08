using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class RegisterContextTest
{

    [Fact]
    public void Should_Have_DbSets_RegisterContext()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<RegisterContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

        // Act
        using (var context = new RegisterContext(options))
        {
            // Assert
            Assert.NotNull(context.Indicador);
            Assert.NotNull(context.ExpectativasMercado); 
        }
    }

    [Fact]
    public void Should_Apply_Configurations_RegisterContext()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<RegisterContext>()
            .UseInMemoryDatabase(databaseName: "InMemory_DataBase_RegisterContext").Options;

        // Act
        using (var context = new RegisterContext(options))
        {
            // Assert
            var model = context.Model;
            Assert.True(model.FindEntityType(typeof(Indicador)) != null);
            Assert.True(model.FindEntityType(typeof(ExpectativasMercado)) != null);
        }
    }
}