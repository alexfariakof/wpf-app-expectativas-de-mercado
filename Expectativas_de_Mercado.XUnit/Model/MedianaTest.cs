using Expectativas_de_Mercado.Model.ValueObjects;

namespace Model;
public class MedianaTests
{
    [Fact]
    public void Implicit_Conversion_From_Decimal()
    {
        // Arrange
        decimal originalValue = 20.58m;

        // Act
        Mediana mediana = originalValue;

        // Assert
        Assert.Equal(originalValue, mediana.Value);
    }

    [Fact]
    public void Implicit_Conversion_To_Decimal()
    {
        // Arrange
        Mediana mediana = new Mediana(20.15m);

        // Act
        decimal convertedValue = mediana;

        // Assert
        Assert.Equal(mediana.Value, convertedValue);
    }

    [Fact]
    public void Equality_Check()
    {
        // Arrange
        decimal value1 = 10.123m;
        decimal value2 = 10.123m;

        // Act
        Mediana mediana1 = new Mediana(value1);
        Mediana mediana2 = new Mediana(value2);

        // Assert
        Assert.Equal(mediana1, mediana2);
        Assert.Equal(mediana1.GetHashCode(), mediana2.GetHashCode());
    }
}
