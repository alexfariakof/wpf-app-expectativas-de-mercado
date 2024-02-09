using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Expectativas_de_Mercado.WPF.View;
public partial class PesquisaWindow : Window
{
    private PesquisaViewModel viewModel;
    public PesquisaWindow()
    {
        InitializeComponent();
        this.DgPesquisas.MouseDoubleClick += DgPesquisas_MouseDoubleClick;
        viewModel = new PesquisaViewModel();
    }

    private void DgPesquisas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var source = (DataGrid)sender;
        var row = source.SelectedItem as Pesquisa; 

        if (row != null)
        {
            MessageBox.Show($"Você clicou duas vezes na linha com o ID {row.Id} e Descrição {row.Descricao}");
        }
    }
}
