namespace Expectativas_de_Mercado.Model.ValueObjects;
public record Media 
{
    public decimal Value { get; set; }
    public static implicit operator decimal(Media d) => d.Value;
    public static implicit operator Media(decimal value) => new Media(value);
}
