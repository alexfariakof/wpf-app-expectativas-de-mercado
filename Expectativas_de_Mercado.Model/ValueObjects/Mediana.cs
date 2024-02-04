namespace Expectativas_de_Mercado.Model.ValueObjects;
public record Mediana 
{
    public decimal Value { get; set; }
    public static implicit operator decimal(Mediana d) => d.Value;
    public static implicit operator Mediana(decimal value) => new Mediana(value);
}
