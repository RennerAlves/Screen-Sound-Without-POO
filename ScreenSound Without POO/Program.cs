// Projeto Screen Sound

using System.ComponentModel;
using System.Threading;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";
// List<string> listaDasBandas = new List<string>(); Essa é a forma de instanciar o objeto a lista sem conteúdo.
//List<string> listaDasBandas = new List<string> {"Black Sabbath", "The Beatles", "Metallica"}; Ficou obsoleto pois precisamos inserir notas.

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();


void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

");
    Console.WriteLine("\n" + mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MediaDeUmaBanda();
            break;
        case -1:
            Console.WriteLine("Obrigado pela preferência! \nPrograma Finalizado.");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

}

void RegistrarBanda()
{
    Console.Clear(); //Limpamos tudo que está sendo exibido no console.
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("\nDigite o nome da Banda que você deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Bandas registradas");

    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //Console.WriteLine($"Banda : {listaDasBandas[i]}");
    // }

    foreach (string bandas in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {bandas}");
    }


    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}


void AvaliarUmaBanda()
{
    // Digitar qual banda deseja avaliar;
    // Se a banda existir no dicionário, atribuir uma nota.
    // Se não, volta ao menu principal.

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma Banda\n");
    Console.Write("Digite a banda que você deseja avaliar: ");
    string nomeDigitado = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDigitado))
    {

        Console.WriteLine("Banda encontrada!");
        Console.Write("Digite a nota que deseja dar a esta banda: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDigitado].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"A banda {nomeDigitado} não foi encontrada!\n");
        Thread.Sleep(1000);
        Console.WriteLine("Aperte uma tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }


}

void MediaDeUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média de uma banda");

    Console.Write("Digite o nome da banda que deseja ver a média de notas: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        int media = (bandasRegistradas[nomeDaBanda].Sum()) / bandasRegistradas[nomeDaBanda].Count();
        // List<int> notasDasBandas = bandasRegistradas[nomeDaBanda];  --> Também era possível pegar as notas assim.
        // Console.WriteLine($"A média das notas dessa banda é: {notasDasBandas.Average()}); --> E assim mostraríamos a média.
        Console.WriteLine($"\nA média das notas da banda {nomeDaBanda} é: {media}");
        Thread.Sleep(1000);
        Console.WriteLine("Digite qualquer tecla para voltar ao programa principal...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("A banda não foi encontrada.");
        Thread.Sleep(1000);
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}



ExibirOpcoesDoMenu();