﻿using JornadaMilhasV0.Dados;
using JornadaMilhasV0.Gerenciador;
using JornadaMilhasV0.Modelos;


List<OfertaViagem> listaOfertasViagem = new List<OfertaViagem>();
var gerenciador = new GerenciadorDeOfertas(listaOfertasViagem);
var context = new JornadaMilhasContext();
var ofertasDAL = new DAL(context);

/*gerenciador.CarregarOfertas();*/
ofertasDAL.InicializarDados();


while (true)
{
    ExibirMenu();

    Console.WriteLine("Boas vindas ao Jornada Milhas. Escolha uma opção:");
    string opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":
            /*gerenciador.CadastrarOferta();*/
            ofertasDAL.AdicionarOfertaViagem();
            break;
        case "2":
            ofertasDAL.ObterTodasOfertasViagem();
            break;
        case "3":
            Console.WriteLine("Obrigada por utilizar o Jornada Milhas. Até mais!");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

static void ExibirMenu()
{
    Console.WriteLine("-------- Painel Administrativo - Jornada Milhas --------");
    Console.WriteLine("1. Cadastrar Ofertas");
    Console.WriteLine("2. Mostrar Todas as Ofertas");
    Console.WriteLine("3. Sair");
}
