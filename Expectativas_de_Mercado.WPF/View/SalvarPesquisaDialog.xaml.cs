using System.Windows;

namespace Expectativas_de_Mercado.WPF.View;
public partial class SalvarPesquisaDialog : Window
{
    public string Descricao { get; private set; }
    public SalvarPesquisaDialog()
    {
        InitializeComponent();
        Descricao = String.Empty;
    }
    private void btnConfirm_Click(object sender, RoutedEventArgs e)
    {
        if (String.IsNullOrEmpty(txtDescricao.Text))
        {
            MessageBox.Show("Entre com uma descrição para armazenar a pesquisa.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        Descricao = txtDescricao.Text;
        DialogResult = true;
    }
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}
