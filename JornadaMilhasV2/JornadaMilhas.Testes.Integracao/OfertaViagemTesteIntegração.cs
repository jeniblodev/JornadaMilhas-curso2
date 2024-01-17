using JornadaMilhasV0.Dados;

namespace JornadaMilhas.Testes.Integracao;

public class OfertaViagemTesteIntegração:IDisposable
{
    //Setup
    private readonly JornadaMilhasContext context;
    private readonly DAL dal;

    public OfertaViagemTesteIntegração()
    {
        context = new JornadaMilhasContext();
        dal = new DAL(context);
    }

    [Fact]
    public void Test1()
    {

    }

    //Cleanup
    public void Dispose()
    {
        dal.Dispose();
        context.Dispose();
    }
        
}