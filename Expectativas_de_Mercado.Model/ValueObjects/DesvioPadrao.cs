namespace Expectativas_de_Mercado.Model.ValueObjects;
public record DesvioPadrao
{
    public double Value { get; set; }
    public static implicit operator double(DesvioPadrao d) => d.Value;
    public static implicit operator DesvioPadrao(double  value) => new DesvioPadrao(value);
    public DesvioPadrao() { }
    public DesvioPadrao(double value) => this.Value = value;
}
