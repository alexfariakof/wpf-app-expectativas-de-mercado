using Expectativas_de_Mercado.Model.Aggregates;
using HomeBrokerXUnit.Faker;

namespace Model;
public class ExpectativasMercadoTests
{
    [Fact]
    public void ExpectativasMercado_CanBe_Created()
    {
        // Arrange
        var expectativasMercado = new ExpectativasMercado();
        expectativasMercado.Id = Guid.NewGuid();

        // Assert
        Assert.NotNull(expectativasMercado);
        Assert.NotNull(expectativasMercado?.Id);
    }

    [Fact]
    public void ExpectativasMercado_Properties_Are_Initialized()
    {
        // Arrange
        var expectativasMercado = ExpectativasMercadoFaker.GetNewFaker();

        // Act & Assert
        Assert.NotNull(expectativasMercado.Indicador);
        Assert.NotNull(expectativasMercado.Data);
        Assert.NotNull(expectativasMercado.DataReferencia);
        Assert.NotNull(expectativasMercado.Reuniao);
        Assert.NotNull(expectativasMercado.Media);
        Assert.NotNull(expectativasMercado.Mediana);
        Assert.NotNull(expectativasMercado.DesvioPadrao);
        Assert.True(expectativasMercado.Minimo > 0m);
        Assert.True(0m < expectativasMercado.Maximo);
        Assert.True(0 < expectativasMercado.NumeroRespondentes);
        Assert.True(0 < expectativasMercado.BaseCalculo);
    }
}
