namespace Expectativas_de_Mercado.Model.ValueObjects;
public record DesvioPadrao
{
    public decimal Value { get; set; }
    public static implicit operator decimal(DesvioPadrao d) => d.Value;
    public static implicit operator DesvioPadrao(decimal value) => new DesvioPadrao(value);
}
