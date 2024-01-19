using JornadaMilhasV0.Modelos;

namespace JornadaMilhasV0.Dados;
public class DAL:IDisposable, IDAL
{
    private readonly JornadaMilhasContext _dbContext;

    public DAL(JornadaMilhasContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void InicializarDados()
    {
        if (!_dbContext.OfertasViagem.Any())
        {
            var rota1 = new Rota("Salvador", "São Paulo");
            var rota2 = new Rota("Rio de Janeiro", "Belo Horizonte");

            var oferta1 = new OfertaViagem(rota1, DateTime.Now, DateTime.Now.AddDays(7), 1000.00);
            var oferta2 = new OfertaViagem(rota2, DateTime.Now, DateTime.Now.AddDays(14), 1500.00);

            _dbContext.OfertasViagem.AddRange(oferta1, oferta2);
            _dbContext.SaveChanges();
        }
    }

    public List<OfertaViagem> ObterTodasOfertasViagem()
    {

        Console.WriteLine("\nTodas as ofertas cadastradas: ");

        return _dbContext.OfertasViagem.ToList(); 
    }

    public OfertaViagem ObterOfertaViagemPorId(int id)
    {
        return _dbContext.OfertasViagem.Find(id);
    }

    public void AdicionarOfertaViagem(OfertaViagem oferta)
    {
        _dbContext.OfertasViagem.Add(oferta);
        _dbContext.SaveChanges();
    }

    public void AtualizarOfertaViagem(OfertaViagem ofertaViagem)
    {
        var ofertaViagemAtualizado = _dbContext.OfertasViagem.Find(ofertaViagem.Id);

        if (ofertaViagemAtualizado != null)
        {
            _dbContext.OfertasViagem.Update(ofertaViagemAtualizado);
            _dbContext.SaveChanges();
        }
    }

    public void RemoverOfertaViagem(OfertaViagem oferta)
    {
        var ofertaViagem = _dbContext.OfertasViagem.Find(oferta.Id);
        if (ofertaViagem != null)
        {
            _dbContext.OfertasViagem.Remove(ofertaViagem);
            _dbContext.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException($"Oferta para exclusão com o ID= {oferta.Id} não encontrada.");
        }
    }

    public void Dispose()
    {
        this.Dispose();
    }
}
