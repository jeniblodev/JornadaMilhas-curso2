using JornadaMilhasV0.Dados;
using Xunit.Abstractions;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegra��o
{
    //Setup
    private readonly JornadaMilhasContext context;
    private readonly DAL dal;
     public OfertaViagemTesteIntegra��o()
    {     

        context = new JornadaMilhasContext();
        dal = new DAL(context);
    }

    [Fact]
    public void TestaConexaoComBaseDeDados()
    {
        //Arrange
        //Act
        var resultado = context.Database.CanConnectAsync();
        //Assert
        Assert.True(resultado.Result);

    }
             
}