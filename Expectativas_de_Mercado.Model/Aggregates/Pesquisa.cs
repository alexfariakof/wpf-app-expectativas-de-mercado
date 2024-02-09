using Expectativas_de_Mercado.Model.Core;

namespace Expectativas_de_Mercado.Model.Aggregates;
public class Pesquisa : Base
{
    public Indicador? Indicador { get; set; }
    public Indicador_Id IndicadorId { get; set; }
    public string Descricao { get; set; } = String.Empty;
    public DateTime Data {  get; set; }    
    public DateTime PeriodoInicial { get; set; }
    public DateTime PeriodoFinal { get; set; }
    public List<ExpectativasMercado> ExpectativasMercados { get; set; } = new();
}
