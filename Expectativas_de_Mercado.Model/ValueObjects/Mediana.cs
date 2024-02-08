namespace Expectativas_de_Mercado.Model.ValueObjects;
public record Mediana 
{
    public double Value { get; set; }
    public static implicit operator double (Mediana d) => d.Value;
    public static implicit operator Mediana(double  value) => new Mediana(value);
    public Mediana() { }
    public Mediana(double  value) => this.Value = value;
}
