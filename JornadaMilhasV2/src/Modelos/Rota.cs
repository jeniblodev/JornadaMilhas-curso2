﻿namespace JornadaMilhasV0.Modelos;
public class Rota
{
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }

    public Rota(string origem, string destino)
    {
        Origem = origem; 
        Destino = destino;
    }
}

//aqui na rota vale a pena deixar uma lista pronta de rotas e no cadastro somente informar qual a rota será utilizada?

