using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.ViewModel;
using Expectativas_de_Mercado.WPF.View;
using System.Collections.ObjectModel;
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
        this.DpInicio.SelectedDate = DateTime.Now.AddMonths(-1);
        this.DpFim.SelectedDate = DateTime.Now;
        this.Width = this.MinWidth;
        this.viewModel = new ExpectativasMercadoMensalViewModel();
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
        this.BtnPesquisar.Click += this.BtnPesquisar_Click;
        this.BtnGrafico.Click += this.BtnGrafico_Click;
        this.CboIndicador.SelectionChanged += this.CboIndicador_SelectionChanged;
        this.BtnExportar.Click += this.BtnExportar_Click;
        this.BtnSalvar.Click += this.BtnSalvar_Click;
        this.BtnRecuperar.Click += this.BtnRecuperarPesquisa_Click;
    }

    /// <summary>
    /// Manipula o clique no botão de pesquisa, atualizando os dados conforme a seleção.
    /// </summary>
    /// <param name="sender">O objeto que acionou o evento.</param>
    /// <param name="e">Os argumentos do evento.</param>
    private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
    {
        if (!IsIndicadorValid()) return;
        this.viewModel = new ExpectativasMercadoMensalViewModel((Indicador)CboIndicador.SelectedItem, DpInicio.SelectedDate.Value, DpFim.SelectedDate.Value);
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
    }

    /// <summary>
    /// Manipula o clique no botão de exibição do gráfico, abrindo uma nova janela com o gráfico do indicador selecionado.
    /// </summary>
    private void BtnGrafico_Click(object sender, RoutedEventArgs e)
    {
        if (!IsIndicadorValid()) return;
        if (!IsViewModelValid()) return;

        Grafico page = new Grafico();
        Window window = new Window
        {
            Content = page,  
            Title = "Gráfico Expectativas Mensais " + ((Indicador)CboIndicador.SelectedItem).Descricao
        };

        page.ShowGrafico(this.viewModel);
        window.ShowDialog();        
    }

    /// <summary>
    /// Manipula o evento de clique no botão "BtnExportar".
    /// Exporta os dados do ViewModel para um arquivo CSV.
    /// </summary>
    /// <param name="sender">O objeto que acionou o evento.</param>
    /// <param name="e">Os argumentos do evento.</param>
    private void BtnExportar_Click(object sender, RoutedEventArgs e)
    {
        var indicadorSelecionado = (Indicador)CboIndicador.SelectedItem;
        var formattedDtInicial = DpInicio.SelectedDate.Value.ToString("yyyyMMdd");
        var formattedDtFinal = DpFim.SelectedDate.Value.ToString("yyyyMMdd");
                
        if (!IsViewModelValid()) return;

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
    /// Manipula o evento de alteração de seleção no ComboBox "CboIndicador".
    /// </summary>
    /// <param name="sender">O objeto que acionou o evento.</param>
    /// <param name="e">Os argumentos do evento.</param>
    private void CboIndicador_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        this.viewModel = new ExpectativasMercadoMensalViewModel();
        this.DgExpectativaMercadoMensal.DataContext = viewModel;
    }

    /// <summary>
    /// Manipula o evento de clique do botão "Salvar", exibindo uma caixa de diálogo para salvar a pesquisa.
    /// </summary>
    /// <param name="sender">O objeto que acionou o evento.</param>
    /// <param name="e">Os argumentos do evento.</param>
    private void BtnSalvar_Click(object sender, RoutedEventArgs e)
    {
        if (!IsViewModelValid()) return;

        SalvarPesquisaDialog salvarPesquisaDialog = new SalvarPesquisaDialog(
            (Indicador)CboIndicador.SelectedItem,
            DpInicio.SelectedDate.Value,
            DpFim.SelectedDate.Value,
            viewModel.ExpectativasMercadoMensais.ToList());

        if (salvarPesquisaDialog.ShowDialog() == true)
        {
            MessageBox.Show($"Pesquisa armazenada com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    /// <summary>
    /// Manipula o evento de clique do botão "Recuperar Pesquisa", exibindo uma janela de pesquisa.
    /// </summary>
    /// <param name="sender">O objeto que acionou o evento.</param>
    /// <param name="e">Os argumentos do evento.</param>
    private void BtnRecuperarPesquisa_Click(object sender, RoutedEventArgs e)
    {
        PesquisaWindow pesquisaWindow = new PesquisaWindow();

        if (pesquisaWindow.ShowDialog() == true)
        {
            this.viewModel = new ExpectativasMercadoMensalViewModel();
            viewModel.ExpectativasMercadoMensais = new ObservableCollection<ExpectativasMercado>(pesquisaWindow.expectativasMercados);
            this.DgExpectativaMercadoMensal.DataContext = viewModel;
        }
    }

    /// <summary>
    /// Verifica se existe um indicador selecionado.
    /// </summary>
    /// <returns>
    /// Retorna verdadeiro se a Combobox Indicador contiver
    /// um indicador válido caso contrário, exibe um aviso e retorna falso.
    /// </returns>
    private bool IsIndicadorValid()
    {
        var indicadorSelecionado = (Indicador)CboIndicador.SelectedItem;
        if (indicadorSelecionado.Id == Indicador_Id.Invalid)
        {
            MessageBox.Show("Selecione um indicador.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Verifica se o DataContext do DataGrid contém dados válidos.
    /// </summary>
    /// <returns>
    /// Retorna verdadeiro se o DataContext do DataGrid contiver dadoscaso contrário, exibe um aviso e retorna falso.
    /// </returns>
    private bool IsViewModelValid()
    {
        if (viewModel.ExpectativasMercadoMensais == null || viewModel.ExpectativasMercadoMensais.Count == 0)
        {
            MessageBox.Show("Não há nenhum resultado de pesquisa para realizar a operação.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
        return true;
    }
}