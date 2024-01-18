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
        Assert.IsType<OfertaViagem>(oferta);
    }

    [Fact]
    public void TestaInclusaoDeNovaOferta()
    {
        //Arrange
        var rota = new Rota("TesteRotaOrigem", "TesteRotaDestino");
        var dataIda = new DateTime(2024, 03, 20);
        var dataVolta = new DateTime(2024, 03, 25);
        var preco = 600;


        var novaOferta = new OfertaViagem(rota,dataIda ,dataVolta , preco );
        //Act

        ofertasDAL.AdicionarOfertaViagem(novaOferta);
        var ofertas = ofertasDAL.ObterTodasOfertasViagem();

        //Assert
        Assert.Contains(novaOferta, ofertas);
    }

    [Fact]
    public void TestaAtualizacaoDoPrecoDaOferta()
    {
        //Arrange
        var ofertaAtualizada = ofertasDAL.ObterOfertaViagemPorId(2002);
        ofertaAtualizada.Preco = 400;

        //Act
        ofertasDAL.AtualizarOfertaViagem(ofertaAtualizada);
        var ofertas = ofertasDAL.ObterTodasOfertasViagem();

        //Assert
        Assert.Contains(ofertaAtualizada, ofertas);
    }

    [Fact]
    public void TestaExclusaoDaOferta()
    {
        //Arrange
        var ofertaExcluida = ofertasDAL.ObterOfertaViagemPorId(2002);

        //Act
        ofertasDAL.RemoverOfertaViagem(ofertaExcluida);
        var ofertas = ofertasDAL.ObterTodasOfertasViagem();

        //Assert
        Assert.DoesNotContain(ofertaExcluida, ofertas);
    }




    //Cleanup
    public void Dispose()
    {     

      context.Dispose();
    }
        
}