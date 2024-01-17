using JornadaMilhasV0.Dados;
using Xunit.Abstractions;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegração
{
    //Setup
     private readonly JornadaMilhasContext context;
     public OfertaViagemTesteIntegração()
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