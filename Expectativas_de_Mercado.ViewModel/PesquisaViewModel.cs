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
    public void SalvarPesquisa(string descricao, List<ExpectativasMercado> expectativasPesquisadas)
    {
        var pesquisa = new Pesquisa();
        pesquisa.Descricao = descricao;
        pesquisa.Data = DateTime.Now;
        pesquisa.ExpectativasMercados = expectativasPesquisadas;
        _pesquisaRepository.Insert(pesquisa);
    }
}