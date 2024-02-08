using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.ViewModel;

namespace ViewModel;
// Revisar Implemtação do Mock ViewlModel 
public class IndicadorViewModelTest
{
    [Fact]
    public void ViewModel_Initialization_Sets_Indicadores()
    {
        // Arrange
        var viewModel = new IndicadorViewModel();

        // Act
        var indicadores = viewModel.Indicadores;

        // Assert
        Assert.NotNull(indicadores);
        Assert.Equal(Enum.GetValues(typeof(Indicador_Id)).Length, indicadores.Count);
        Assert.True(indicadores.All(indicador => Enum.IsDefined(typeof(Indicador_Id), indicador.Id)));
    }
}