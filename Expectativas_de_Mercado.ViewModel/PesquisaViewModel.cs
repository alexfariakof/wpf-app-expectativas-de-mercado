using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Repository.Implementations;
using Expectativas_de_Mercado.Repository.Interfaces;
using System.Collections.ObjectModel;

namespace Expectativas_de_Mercado.ViewModel;
public class PesquisaViewModel
{
    private readonly IPesquisaRepository _pesquisaRepository;
    public ObservableCollection<Pesquisa> Pesquisas { get; set; } = new();
    public PesquisaViewModel() 
    {
        _pesquisaRepository = new PesquisaRepository();
        Pesquisas = new ObservableCollection<Pesquisa>(_pesquisaRepository.GetAll());
    }
    public void SalvarPesquisa(Pesquisa pesquisa)
    {    
        pesquisa.Data = DateTime.Now;     
        _pesquisaRepository.Insert(pesquisa);
    }

    public List<ExpectativasMercado> GetExpectativasMercados(Guid pesquisaId)
    {
        return _pesquisaRepository.GetExpectativasMercadoPesquisadas(pesquisaId);
    }
}