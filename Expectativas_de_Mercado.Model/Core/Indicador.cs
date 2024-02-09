using Expectativas_de_Mercado.Model.Aggregates;
using System.ComponentModel;

namespace Expectativas_de_Mercado.Model.Core;
public enum Indicador_Id
{
    [Description("Nenhum Selecionado")]
    Invalid = 0, 

    [Description("IPCA")]
    IPCA = 1,

    [Description("IGP-M")]
    IGP_M = 2,

    [Description("Selic")]
    Selic = 3,
}
public class Indicador
{
    public Indicador_Id Id { get; set; }

    private string _descricao = String.Empty;
    public string Descricao
    {
        get { return _descricao; }
        set { _descricao = value; }
    }
    public List<ExpectativasMercado> ExpectativasMercados { get; set; } = new();
    public Indicador() { }
    public Indicador(string description) 
    { 
        this._descricao = description;
        this.Id = GetIdByDescricao(this._descricao);

    }
    public Indicador(Indicador_Id indicador)
    {
        this.Id = indicador;
        this._descricao = GetDesciption(indicador);       
    }

    private Indicador_Id GetIdByDescricao(string descricao)
    {
        var IndicadorId = Indicador_Id.Invalid;

        foreach (var value in Enum.GetValues(typeof(Indicador_Id)))
        {
            if (value.ToString() == descricao)
            {
                IndicadorId = (Indicador_Id)value;
                break;
            }
        }
        return IndicadorId;
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