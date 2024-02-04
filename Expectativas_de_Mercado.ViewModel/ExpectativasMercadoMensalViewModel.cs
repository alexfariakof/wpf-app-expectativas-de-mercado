using Expectativas_de_Mercado.Model.Aggregates;
using System.Collections.ObjectModel;

namespace Expectativas_de_Mercado.ViewModel;
public class ExpectativasMercadoMensalViewModel
{
    public ObservableCollection<ExpectativasMercadoMensal> ExpectativasMercadoMensais { get; set; }
    public ExpectativasMercadoMensalViewModel()   
    {
        ExpectativasMercadoMensais = new()
        {
            new ExpectativasMercadoMensal{ Indicador = new(Model.Core.Indicador_Id.IPCA) },
            new ExpectativasMercadoMensal{ Indicador = new(Model.Core.Indicador_Id.Selic) },
            new ExpectativasMercadoMensal{ Indicador = new(Model.Core.Indicador_Id.IPCA) },
            new ExpectativasMercadoMensal{ Indicador = new(Model.Core.Indicador_Id.IPCA) }
        };
    }
}