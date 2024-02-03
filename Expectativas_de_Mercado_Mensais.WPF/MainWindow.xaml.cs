using System.Windows;

namespace Expectativas_de_Mercado_Mensais.WPF;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
    {
        double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };
        WpfPlot1.Plot.Add.Scatter(dataX, dataY);
        WpfPlot1.Refresh();
    }

    private void Row_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        DgExpectativaMercadoMensal.Height = RowContainer.ActualHeight;
    }
}