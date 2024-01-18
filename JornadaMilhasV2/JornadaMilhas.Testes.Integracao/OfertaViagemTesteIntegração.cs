using JornadaMilhasV0.Dados;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegra��o:IDisposable
{
    //Setup
    private readonly JornadaMilhasContext context;
    private readonly DAL ofertasDAL;
    
    public OfertaViagemTesteIntegra��o()
    {     

        context = new JornadaMilhasContext();   
        ofertasDAL = new DAL(context);
    }

    [Fact]
    public void TestaConexaoComBaseDeDados()
    {

      
        //Arrange

        //Act
        var resultado = context.Database.CanConnectAsync();

        //Assert
        Assert.True(resultado.Result) ;

    }

    [Fact]
    public void TestaObterTodasAsOfertas()
    {
        //Arrange
        //Act
        var listaDeOfertas = ofertasDAL.ObterTodasOfertasViagem();
        //Assert
        Assert.NotNull(listaDeOfertas);
        Assert.Equal(5, listaDeOfertas.Count);
    }

    [Fact]
    public void TestaObterOfertasPorId()
    {
        //Arrange
        //Act
        var oferta = ofertasDAL.ObterOfertaViagemPorId(3);
        //Assert
        Assert.NotNull(oferta);
    }

    //Cleanup
    public void Dispose()
    {     

      context.Dispose();
    }
        
}