using Expectativas_de_Mercado.Model.Core;

namespace Bacen.Integration.Bacen.Tests;
public class BacenAdapterTests
{
    [Fact]
    public async Task Should_Returns_Valid_Data_GetExpectativasMercadoMensais()
    {
        // Arrange
        var bacenAdapter = new BacenAdapter();
        var indicador = new Indicador { Descricao = "IPCA" };
        var dtInicial = DateTime.Now.AddDays(-10);
        var dtFinal = DateTime.Now;

        // Act
        var result = await bacenAdapter.GetExpectativasMercadoMensais(indicador, dtInicial, dtFinal);

        // Assert
        Assert.NotNull(result);        
    }
}
