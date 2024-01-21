using JornadaMilhasV0.Modelos;

namespace JornadaMilhasV0.Dados;
public interface IDAL
{
    Task<bool> PodeConectarComBaseDeDadosAsync();
    List<OfertaViagem> ObterTodasOfertasViagem();
    OfertaViagem ObterOfertaViagemPorId(int id);
    void AdicionarOfertaViagem(OfertaViagem oferta);
     void AtualizarOfertaViagem(OfertaViagem oferta);
     void RemoverOfertaViagem(OfertaViagem oferta);

}
