using JornadaMilhasV0.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV0.Dados;
internal class DAL
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
        return _dbContext.OfertasViagem.ToList();
    }

    public OfertaViagem ObterOfertaViagemPorId(int id)
    {
        return _dbContext.OfertasViagem.Find(id);
    }

    public void AdicionarOfertaViagem()
    {
        Console.WriteLine("-- Cadastro de ofertas --");
        Console.WriteLine("Informe a cidade de origem: ");
        string origem = Console.ReadLine();

        Console.WriteLine("Informe a cidade de destino: ");
        string destino = Console.ReadLine();

        Console.WriteLine("Informe a data de ida (DD/MM/AAAA): ");
        DateTime dataIda;
        if (!DateTime.TryParse(Console.ReadLine(), out dataIda))
        {
            Console.WriteLine("Data de ida inválida.");
            return;
        }

        Console.WriteLine("Informe a data de volta (DD/MM/AAAA): ");
        DateTime dataVolta;
        if (!DateTime.TryParse(Console.ReadLine(), out dataVolta))
        {
            Console.WriteLine("Data de volta inválida.");
            return;
        }

        Console.WriteLine("Informe o preço: ");
        double preco;
        if (!double.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Formato de preço inválido.");
            return;
        }

        OfertaViagem ofertaCadastrada = new OfertaViagem(new Rota(origem, destino), dataIda, dataVolta, preco);
        
        Console.WriteLine("\nOferta cadastrada com sucesso.");


        _dbContext.OfertasViagem.Add(ofertaCadastrada);
        _dbContext.SaveChanges();
    }

    public void AtualizarOfertaViagem(OfertaViagem ofertaViagem)
    {
        _dbContext.OfertasViagem.Update(ofertaViagem);
        _dbContext.SaveChanges();
    }

    public void RemoverOfertaViagem(int id)
    {
        var ofertaViagem = _dbContext.OfertasViagem.Find(id);
        if (ofertaViagem != null)
        {
            _dbContext.OfertasViagem.Remove(ofertaViagem);
            _dbContext.SaveChanges();
        }
    }
}
