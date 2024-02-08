using Expectativas_de_Mercado.Model.Core;
using HomeBrokerXUnit.Faker;

namespace Model;

public class IndicadorTests
{
    [Fact]
    public void Indicador_CanBeCreated()
    {
        // Arrange
        var indicador = IndicadorFaker.GetNewFaker();

        // Assert
        Assert.NotNull(indicador);
    }

    [Fact]
    public void Indicador_Properties_Are_Initialized()
    {
        // Arrange
        var indicador = new Indicador();

        // Act & Assert
        Assert.Equal(Indicador_Id.Todos, indicador.Id);
        Assert.Equal(string.Empty, indicador.Descricao);
        Assert.NotNull(indicador.ExpectativasMercados);
        Assert.Empty(indicador.ExpectativasMercados);
    }

    [Fact]
    public void Indicador_CanBe_Created_With_Descricao()
    {
        // Arrange
        var descricao = "IPCA";
        var indicador = new Indicador(descricao);

        // Act & Assert
        Assert.Equal(descricao, indicador.Descricao);
    }

    [Fact]
    public void Indicador_CanBe_Created_With_Enum()
    {
        // Arrange
        var indicadorId = Indicador_Id.IPCA;
        var indicador = new Indicador(indicadorId);

        // Act & Assert
        Assert.Equal(indicadorId, indicador.Id);
        Assert.Equal("IPCA", indicador.Descricao);
    }
}
