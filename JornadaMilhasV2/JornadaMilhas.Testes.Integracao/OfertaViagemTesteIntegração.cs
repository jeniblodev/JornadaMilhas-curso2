using Bogus;
using JornadaMilhas.Testes.Integracao.Dados;
using JornadaMilhas.Testes.Integracao.UtilExtension;
using JornadaMilhasV0.Dados;
using JornadaMilhasV0.Modelos;
using Moq;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegração:IDisposable
{
    //Setup
    private readonly JornadaMilhasContext context;
    private readonly DAL ofertasDAL;
    
    public OfertaViagemTesteIntegração()
    {

        context = Carregar.InMemory();  
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
        //Assert.Equal(2, listaDeOfertas.Count);
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
        var ofertaAtualizada = ofertasDAL.ObterOfertaViagemPorId(3);
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
        var ofertaExcluida = ofertasDAL.ObterOfertaViagemPorId(3);

        //Act
        ofertasDAL.RemoverOfertaViagem(ofertaExcluida);
        var ofertas = ofertasDAL.ObterTodasOfertasViagem();

        //Assert
        Assert.DoesNotContain(ofertaExcluida, ofertas);
    }

    [Fact]
    public void TestaExclusaoDeOfertaInexistenteDeveGerarExcecao()
    {
        //Arrange
        var novaOferta = new OfertaViagem(new Rota("TesteRotaOrigem", "TesteRotaDestino"), new DateTime(2024, 03, 20), new DateTime(2024, 03, 25), 2000) { Id=999};

        //Act+Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
           ofertasDAL.RemoverOfertaViagem(novaOferta);
        }).ExceptionMessage($"Oferta para exclusão com o ID= {novaOferta.Id} não encontrada.");
    }

    //Mock
    [Fact]
    public void TestaObterOfertasPorIdMock()
    {
        //Arrange                
        var mockDAL = new Mock<IDAL>();    //definindo o objeto que será mockado   

         mockDAL //configurando o objeto para execução do método que consulta por Id
            .Setup(_ => _.ObterOfertaViagemPorId(It.IsAny<int>()))
            .Returns(() => new OfertaViagem(new Rota("TesteRotaOrigem", "TesteRotaDestino"), new DateTime(2024, 03, 20), new DateTime(2024, 03, 25), 2000) { Id = 800 });

        //Act
        var retorno = mockDAL.Object.ObterOfertaViagemPorId(800);//Executa o co mportamento
        
        //Assert
        Assert.NotNull(retorno );
        Assert.Equal(800, retorno.Id );
        Assert.Equal("TesteRotaOrigem", retorno.Rota.Origem);
    
    }

    [Fact]
    public void TestaObterTodasOfertasViagemBogus()
    {
        //Arrange
        var faker = new Faker<OfertaViagem>()
            .RuleFor(o => o.Id, f => f.UniqueIndex + 1)
            .RuleFor(o => o.Rota, f => new Rota(f.Address.City(), f.Address.City()))
            .RuleFor(o => o.DataIda, f => f.Date.Future())
            .RuleFor(o => o.DataVolta, (f, o) => o.DataIda.AddDays(f.Random.Int(1, 7)))
            .RuleFor(o => o.Preco, f => f.Random.Double(1000, 5000));

        var mockDAL = new Mock<IDAL>();

        mockDAL.Setup(_ => _.ObterTodasOfertasViagem())
            .Returns(() => faker.Generate(2));
            

        //Act
        var retorno = mockDAL.Object.ObterTodasOfertasViagem();

        //Assert
        Assert.NotNull(retorno );
        Assert.Equal(2, retorno.Count );
        Assert.NotNull(retorno[0].Rota.Origem);
        Assert.NotNull(retorno[1].Rota.Destino);

    }


    //Cleanup
    public void Dispose()
    {     

      context.Dispose();
    }
        
}