using Expectativas_de_Mercado.Model.Aggregates;
using System.Collections.ObjectModel;

namespace Expectativas_de_Mercado.ViewModel;
public class PesquisaViewModel
{
    public ObservableCollection<Pesquisa> Pesquisas { get; set; } = new();
    public PesquisaViewModel() 
    {

    }


}