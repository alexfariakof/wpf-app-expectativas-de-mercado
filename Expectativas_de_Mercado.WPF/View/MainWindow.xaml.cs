using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.ViewModel;
using Expectativas_de_Mercado.WPF.View;
using System.IO;
using System.Text;
using System.Windows;

namespace Expectativas_de_Mercado.WPF;

/// <summary>
/// Representa a janela principal da aplicação WPF.
/// </summary>
#pragma warning disable CS8629 // Nullable value type may be null.
public partial class MainWindow : Window
{
    private ExpectativasMercadoMensalViewModel viewModel;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="MainWindow"/>.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        DpInicio.SelectedDate = DateTime.Now.AddDays(-6);
        DpFim.SelectedDate = DateTime.Now;
        this.viewModel = new ExpectativasMercadoMensalViewModel();
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
        this.BtnPesquisar.Click += this.BtnPesquisar_Click;
        this.BtnGrafico.Click += this.BtnGrafico_Click;
        this.CboIndicador.SelectionChanged += this.CboIndicador_SelectionChanged;
        this.BtnExportar.Click += this.BtnExportar_Click;
    }

    /// <summary>
    /// Manipula o clique no botão de pesquisa, atualizando os dados conforme a seleção.
    /// </summary>
    private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
    {
        var indicadorSelecionado = (Indicador)CboIndicador.SelectedItem;
        if (indicadorSelecionado.Id == Indicador_Id.Invalid)
        {
            MessageBox.Show("Selecione um indicador para realizar a pesquisa.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        this.viewModel = new ExpectativasMercadoMensalViewModel(indicadorSelecionado, DpInicio.SelectedDate.Value, DpFim.SelectedDate.Value);
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
    }

    /// <summary>
    /// Manipula o clique no botão de exibição do gráfico, abrindo uma nova janela com o gráfico do indicador selecionado.
    /// </summary>
    private void BtnGrafico_Click(object sender, RoutedEventArgs e)
    {
        var indicadorSelecionado = (Indicador)CboIndicador.SelectedItem;
        if (indicadorSelecionado.Id == Indicador_Id.Invalid)
        {
            MessageBox.Show("Selecione um indicador para exibir o gráfico.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        Grafico page = new Grafico();
        Window window = new Window
        {
            Content = page,  
            Title = "Gráfico Expectativas Mensais " + indicadorSelecionado.Descricao
        };

        page.ShowGrafico();
        window.ShowDialog();        
    }

    /// <summary>
    /// Manipula o clique no botão de exportar, exportando os dados para um arquivo CSV do indicador selecionado.
    /// </summary>
    private void BtnExportar_Click(object sender, RoutedEventArgs e)
    {
        var indicadorSelecionado = (Indicador)CboIndicador.SelectedItem;
        var formattedDtInicial = DpInicio.SelectedDate.Value.ToString("yyyyMMdd");
        var formattedDtFinal = DpFim.SelectedDate.Value.ToString("yyyyMMdd");

        if (viewModel.ExpectativasMercadoMensais == null || viewModel.ExpectativasMercadoMensais.Count == 0)
        {
            MessageBox.Show("Não há dados para exportar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
        {
            Filter = "Arquivo CSV (*.csv)|*.csv",
            FileName = $"{indicadorSelecionado.Descricao}_{formattedDtInicial}_{formattedDtFinal}" 
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            try
            {
                using (var streamWriter = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    if (indicadorSelecionado.Id == Indicador_Id.Selic)
                        streamWriter.WriteLine("Indicador;Data;Reunião;Média;Mediana;Desvio Padrão;Mínimo;Máximo;Número de Respondentes;Base de Cálculo");
                    else
                        streamWriter.WriteLine("Indicador;Data;Data Referência;Média;Mediana;Desvio Padrão;Mínimo;Máximo;Número de Respondentes;Base de Cálculo");

                    foreach (var item in viewModel.ExpectativasMercadoMensais)
                    {
                        if (indicadorSelecionado.Id == Indicador_Id.Selic)
                            streamWriter.WriteLine($"{item.Indicador.Descricao};{item.Data.Value.ToShortDateString()};{item.Reuniao};{item.Media.Value};{item.Mediana.Value};{item.DesvioPadrao.Value};{item.Minimo};{item.Maximo};{item.NumeroRespondentes};{item.BaseCalculo}");
                        else
                            streamWriter.WriteLine($"{item.Indicador.Descricao};{item.Data.Value.ToShortDateString()};{item.DataReferencia.Value.ToShortDateString()};{item.Media.Value};{item.Mediana.Value};{item.DesvioPadrao.Value};{item.Minimo};{item.Maximo};{item.NumeroRespondentes};{item.BaseCalculo}");
                    }
                }

                MessageBox.Show("Exportação concluída com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar para CSV: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    /// <summary>
    /// Manipula a alteração na seleção do ComboBox de indicadores, reiniciando os dados.
    /// </summary>
    private void CboIndicador_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        this.viewModel = new ExpectativasMercadoMensalViewModel();
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
    }
}