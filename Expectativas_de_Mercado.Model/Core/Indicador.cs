using System.ComponentModel;

namespace Expectativas_de_Mercado.Model.Core;
public class Indicador
{
    public  Indicador_Id Id { get; set; }

    private string _descricao;
    public string Descricao
    {
        get { return _descricao; }
        set { _descricao = value; }
    }
    public Indicador() { }
    public Indicador(Indicador_Id indicador)
    {
        Id = indicador;
        this._descricao = GetDesciption(indicador);
    }
    private string GetDesciption(Indicador_Id indicador)
    {
        var value = indicador.ToString();
        var fieldInfo = indicador.GetType().GetField(value);

        if (fieldInfo != null)
        {
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes == null || attributes.Length == 0)
            {
                return value;
            }
            else
            {
                var descriptionAttribute = (DescriptionAttribute)attributes[0];
                return descriptionAttribute.Description;
            }
        }
        else
        {
            return value;
        }

    }
}

public enum Indicador_Id
{
    [Description("IPCA")]
    IPCA = 1,

    [Description("IGP-M")]
    IGP_M = 2,

    [Description("Selic")]
    Selic = 3,
}
