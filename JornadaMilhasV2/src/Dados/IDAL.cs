using JornadaMilhasV0.Modelos;

namespace JornadaMilhasV0.Dados;
public interface IDAL
{
    List<OfertaViagem> ObterTodasOfertasViagem();
    OfertaViagem ObterOfertaViagemPorId(int id);
    void AdicionarOfertaViagem(OfertaViagem oferta);
     void AtualizarOfertaViagem(OfertaViagem ofertaViagem);
     void RemoverOfertaViagem(OfertaViagem oferta);

}
