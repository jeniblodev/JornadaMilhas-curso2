using JornadaMilhasV0.Dados;
using JornadaMilhasV0.Modelos;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegração:IDisposable
{
    //Setup
    private readonly JornadaMilhasContext context;
    private readonly DAL ofertasDAL;
    
    public OfertaViagemTesteIntegração()
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

    [Fact]
    public void TestaInclusaoDeNovaOferta()
    {
        //Arrange
        var rota = new Rota("TesteRotaOrigem", "TesteRotaDestino");
        var dataIda = new DateTime(2024, 03, 20);
        var dataVolta = new DateTime(2024, 03, 25);
        var preco = 600;


        var novaOferta = new OfertaViagem(rota,dataIda ,dataVolta , 600 );
        //Act

        ofertasDAL.AdicionarOfertaViagem(novaOferta) ;
        //Assert
        var ofertas = ofertasDAL.ObterTodasOfertasViagem();
        Assert.Contains(novaOferta, ofertas);
    }


    //Cleanup
    public void Dispose()
    {     

      context.Dispose();
    }
        
}