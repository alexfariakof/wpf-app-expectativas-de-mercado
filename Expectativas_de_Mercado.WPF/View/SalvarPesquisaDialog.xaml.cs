using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.ViewModel;
using System.Windows;

namespace Expectativas_de_Mercado.WPF.View;
public partial class SalvarPesquisaDialog : Window
{
    private PesquisaViewModel _viewModel;
    private Pesquisa _pesquisa;
    public SalvarPesquisaDialog(Indicador indicador, DateTime periodoInicial, DateTime periodoFinal, List<ExpectativasMercado> expectativasPesquisadas)
    {
        InitializeComponent();
        _viewModel = new PesquisaViewModel();
        _pesquisa = new();
        _pesquisa.Indicador = indicador;
        _pesquisa.PeriodoInicial = periodoInicial;
        _pesquisa.PeriodoFinal = periodoFinal;
        _pesquisa.ExpectativasMercados = expectativasPesquisadas;
    }
    private void btnConfirm_Click(object sender, RoutedEventArgs e)
    {
        if (String.IsNullOrEmpty(txtDescricao.Text))
        {
            MessageBox.Show("Entre com uma descrição para armazenar a pesquisa.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        _pesquisa.Descricao = txtDescricao.Text;
        _viewModel.SalvarPesquisa(_pesquisa);
        DialogResult = true;
    }
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}
