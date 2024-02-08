using Expectativas_de_Mercado.Model.ValueObjects;

namespace Model;
public class MediaTests
{
    [Fact]
    public void Media_Conversion_Works()
    {
        // Arrange
        decimal originalValue = 42.5m;
        Media media = new Media(originalValue);

        // Act
        decimal convertedValue = media;

        // Assert
        Assert.Equal(originalValue, convertedValue);
    }

    [Fact]
    public void Media_Explicit_Conversion_Works()
    {
        // Arrange
        decimal originalValue = 0.08m;
        Media media = (Media)originalValue;

        // Act
        decimal convertedValue = media.Value;

        // Assert
        Assert.Equal(originalValue, convertedValue);
    }

    [Fact]
    public void Media_Equality_Check()
    {
        // Arrange
        decimal value1 = 58.04m;
        decimal value2 = 58.04m;

        // Act
        Media media1 = new Media(value1);
        Media media2 = new Media(value2);

        // Assert
        Assert.Equal(media1, media2);
        Assert.Equal(media1.GetHashCode(), media2.GetHashCode());
    }
}
