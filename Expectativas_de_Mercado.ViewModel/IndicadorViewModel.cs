using Expectativas_de_Mercado.Model.Core;
using System.Collections.ObjectModel;

namespace Expectativas_de_Mercado.ViewModel;
public class IndicadorViewModel 
{
    public Indicador Indicador { get; set; }
    public ObservableCollection<Indicador> Indicadores { get; set; }    
    public IndicadorViewModel()  {
        Indicadores = new ObservableCollection<Indicador>();
        foreach (Indicador_Id indicadorId in Enum.GetValues(typeof(Indicador_Id)))
            Indicadores.Add(new Indicador(indicadorId));
    }
}
