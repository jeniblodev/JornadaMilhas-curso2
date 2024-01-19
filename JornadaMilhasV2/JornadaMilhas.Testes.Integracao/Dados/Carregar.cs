using JornadaMilhasV0.Dados;
using JornadaMilhasV0.Modelos;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Testes.Integracao.Dados;

public static class Carregar
{
    public static JornadaMilhasContext InMemory()
    {
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
                .UseInMemoryDatabase(Guid
                .NewGuid().ToString()).Options;

        var contexto = new JornadaMilhasContext(options);

      
        var rota1 = new Rota("Salvador", "São Paulo");
        var rota2 = new Rota("Rio de Janeiro", "Belo Horizonte");
        var rota3 = new Rota("Vitória", "Belo Horizonte");

        var oferta1 = new OfertaViagem(rota1, DateTime.Now, DateTime.Now.AddDays(7), 1000.00);
        var oferta2 = new OfertaViagem(rota2, DateTime.Now, DateTime.Now.AddDays(14), 1500.00);
        var oferta3 = new OfertaViagem(rota3, DateTime.Now, DateTime.Now.AddDays(14), 2000.00);
        contexto.OfertasViagem.AddRange(oferta1, oferta2,oferta3);
        contexto.SaveChanges();
        

        return contexto;
    }
}
