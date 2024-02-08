using Expectativas_de_Mercado.Model.ValueObjects;

namespace Model;
public class DesvioPadraoTests
{
    [Theory]
    [InlineData(42.5)]
    [InlineData(15.75)]
    [InlineData(99.99)]
    public void Implicit_Conversion_From_Decimal(decimal originalValue)
    {
        // Act
        DesvioPadrao desvioPadrao = originalValue;

        // Assert
        Assert.Equal(originalValue, desvioPadrao.Value);
    }

    [Theory]
    [InlineData(42.5)]
    [InlineData(15.75)]
    [InlineData(99.99)]
    public void Implicit_Conversion_To_Decimal(decimal originalValue)
    {
        // Arrange
        DesvioPadrao desvioPadrao = new DesvioPadrao(originalValue);

        // Act
        decimal convertedValue = desvioPadrao;

        // Assert
        Assert.Equal(originalValue, convertedValue);
    }

    [Fact]
    public void Equality_Check()
    {
        // Arrange
        decimal value1 = 899.587m;
        decimal value2 = 899.587m;

        // Act
        DesvioPadrao desvioPadrao1 = new DesvioPadrao(value1);
        DesvioPadrao desvioPadrao2 = new DesvioPadrao(value2);

        // Assert
        Assert.Equal(desvioPadrao1, desvioPadrao2);
        Assert.Equal(desvioPadrao1.GetHashCode(), desvioPadrao2.GetHashCode());
    }
}