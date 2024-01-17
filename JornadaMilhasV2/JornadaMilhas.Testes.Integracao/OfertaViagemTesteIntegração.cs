using JornadaMilhasV0.Dados;
using Xunit.Abstractions;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegra��o
{
    //Setup
     private readonly JornadaMilhasContext context;
     public OfertaViagemTesteIntegra��o()
    {   

        context = new JornadaMilhasContext();
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