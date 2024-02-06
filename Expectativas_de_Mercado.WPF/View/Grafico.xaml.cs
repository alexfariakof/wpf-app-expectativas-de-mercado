using System.Windows.Controls;

namespace Expectativas_de_Mercado.WPF.View;
public partial class Grafico : Page
{
    public Grafico()
    {
        InitializeComponent();
    }

    public void ShowGrafico()
    {
        double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };
        WpfPlot1.Plot.Add.Scatter(dataX, dataY);
        WpfPlot1.Refresh();
    }

}
