using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.ValueObjects;
using Expectativas_de_Mercado.ViewModel;
using System.Windows.Controls;

namespace Expectativas_de_Mercado.WPF.View;
public partial class Grafico : Page
{
    public Grafico()
    {
        InitializeComponent();
        WpfPlot1.Plot.Axes.DateTimeTicksBottom();        
    }
    public void ShowGrafico(ExpectativasMercadoMensalViewModel viewModel)
    {
        var groupedByDataExpectativasMercados = viewModel.ExpectativasMercadoMensais
         .Where(em => em.Data.HasValue)
         .GroupBy(em => em.Data)
         .Select(group =>
         {
             var firstItem = group.First();
             return new ExpectativasMercado
             {
                 Data = firstItem.Data,
                 DataReferencia = firstItem.DataReferencia,
                 Reuniao = firstItem.Reuniao,
                 Media = new Media { Value = firstItem.Media?.Value ?? 0 },
                 Mediana = new Mediana { Value = firstItem.Mediana?.Value ?? 0 },
                 DesvioPadrao = new DesvioPadrao { Value = firstItem.DesvioPadrao?.Value ?? 0 },
                 Minimo = group.Min(em => em.Minimo),
                 Maximo = group.Max(em => em.Maximo),
                 NumeroRespondentes = group.Sum(em => em.NumeroRespondentes),
                 BaseCalculo = group.Sum(em => em.BaseCalculo)
             };
         })
         .ToList();

        var XAxis = groupedByDataExpectativasMercados.Where(em => em.Data.HasValue).Select(em => em.Data).ToArray();
        decimal[] media = groupedByDataExpectativasMercados.Where(em => em.Media != null).Select(em => em.Media.Value).ToArray();
        decimal[] mediana= groupedByDataExpectativasMercados.Where(em => em.Mediana!= null).Select(em => em.Mediana.Value).ToArray();
        decimal[] desvioPadrao = groupedByDataExpectativasMercados.Where(em => em.DesvioPadrao != null).Select(em => em.DesvioPadrao.Value).ToArray();
        decimal[] minimo = groupedByDataExpectativasMercados.Where(em => em.Minimo != 0).Select(em => em.Minimo).ToArray();
        decimal[] maximo = groupedByDataExpectativasMercados.Where(em => em.Maximo != 0).Select(em => em.Maximo).ToArray();


        WpfPlot1.Plot.Add.Scatter(XAxis, media, ScottPlot.Color.FromHex("#0B0FED"));
        WpfPlot1.Plot.Add.Scatter(XAxis, mediana, ScottPlot.Color.FromHex("#F37D06"));
        WpfPlot1.Plot.Add.Scatter(XAxis, desvioPadrao, ScottPlot.Color.FromHex("#000000"));
        WpfPlot1.Plot.Add.Scatter(XAxis, minimo, ScottPlot.Color.FromHex("#44E40C"));
        WpfPlot1.Plot.Add.Scatter(XAxis, maximo, ScottPlot.Color.FromHex("#ED0202"));
        WpfPlot1.Plot.Axes.AutoScale();
        WpfPlot1.Plot.Axes.SetLimitsY(((double)minimo.Min()), ((double)maximo.Max()));
        WpfPlot1.Plot.Axes.Zoom(.8, .7);
        WpfPlot1.Refresh();
    }    
}
