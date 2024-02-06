using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.ViewModel;
using System.Windows;

namespace Expectativas_de_Mercado.WPF;
public partial class MainWindow : Window
{
    private ExpectativasMercadoMensalViewModel viewModel;
    public MainWindow()
    {
        InitializeComponent();
        DpInicio.SelectedDate = DateTime.Now.AddDays(-6);
        DpFim.SelectedDate = DateTime.Now;
        this.viewModel = new ExpectativasMercadoMensalViewModel();
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
        this.BtnPesquisar.Click += this.BtnPesquisar_Click;

    }
    private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
    {
        var indicadorSelecionado = (Indicador)CboIndicador.SelectedItem;
        this.viewModel = new ExpectativasMercadoMensalViewModel(indicadorSelecionado,  DpInicio.SelectedDate.Value, DpFim.SelectedDate.Value);
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
    }
}