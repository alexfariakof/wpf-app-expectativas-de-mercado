using Bacen.Integration.Bacen;
using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using System.Collections.ObjectModel;

namespace Expectativas_de_Mercado.ViewModel;
public class ExpectativasMercadoMensalViewModel
{
    public ObservableCollection<ExpectativasMercado> ExpectativasMercadoMensais { get; set; } = new();
    public ExpectativasMercadoMensalViewModel()  { }
    public ExpectativasMercadoMensalViewModel(Indicador indicador, DateTime dtInicial, DateTime dtFinal) 
    {
        var bacenAdapter = new BacenAdapter();        
        var result = bacenAdapter.GetExpectativasMercadoMensais(indicador, dtInicial, dtFinal).Result;
        this.ExpectativasMercadoMensais = new ObservableCollection<ExpectativasMercado>(result);
    }
}