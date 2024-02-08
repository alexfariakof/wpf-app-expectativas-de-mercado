namespace Expectativas_de_Mercado.Model.ValueObjects;
public record Media 
{
    public double Value { get; set; }
    public static implicit operator double(Media d) => d.Value;
    public static implicit operator Media(double  value) => new Media(value);
    public Media() { }
    public Media(double value) => this.Value = value;
}
