using Bacen.Integration;
using Expectativas_de_Mercado.Model.Core;
using Expectativas_de_Mercado.ViewModel;
using HomeBrokerXUnit.Faker;
using Moq;

namespace ViewModel;
// Revisar Implemtação do Mock ViewlModel 
public class ExpectativasMercadoMensalViewModelTest
{
    [Fact]
    public void ViewModel_Initialization_Sets_ExpectativasMercadoMensais()
    {
        // Arrange
        var mockBacenAdapter = new Mock<IBacenAdpter>();
        var expectedExpectativasMercado = ExpectativasMercadoFaker.GetListFaker(32);

        mockBacenAdapter.Setup(adapter =>
            adapter.GetExpectativasMercadoMensais(It.IsAny<Indicador>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(expectedExpectativasMercado);

        // Act
        var viewModel = new ExpectativasMercadoMensalViewModel(new Indicador(Indicador_Id.Selic), new DateTime(2024,2,1), new DateTime(2024, 2, 8));        
        var actualExpectativasMercado = viewModel.ExpectativasMercadoMensais;

        // Assert
        Assert.NotNull(actualExpectativasMercado);
        Assert.Equal(expectedExpectativasMercado.Count, actualExpectativasMercado.Count);
    }
}