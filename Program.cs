#region Variaveis globais
List<(int, string)> opcoesMenu = new List<(int, string)>
{
    (1, "Visualizar tarefa"),
    (2, "Cadastrar tarefa"),
    (3, "Atualizar tarefa"),
    (4, "Excluir tarefa"),
    (5, "Sair"),
};

List<string> tarefas = new List<string>();
#endregion

#region Chamada do Programa
App();

void App()
{
    Console.Clear();
    Console.WriteLine("Bem vindo ao World Of Points! ");
    ChamarMenu();
    EscolherOpcao();
}
#endregion

#region Outros Metodos

void ChamarMenu()
{
    Console.WriteLine("Digite a opcao que deseja: ");
    foreach (var opcao in opcoesMenu)
        Console.WriteLine(opcao.Item1 + " - " + opcao.Item2);
}

void EscolherOpcao()
{
    List<int> opcoesValidas = opcoesMenu.Select(opcao => opcao.Item1).ToList();
    string opcaoDigitada = Console.ReadLine();

    bool opcaoDigitadaNulaOuVazia = string.IsNullOrWhiteSpace(opcaoDigitada);
    bool conseguiuConverterOpcaoDigitadaParaInt = int.TryParse(opcaoDigitada, out int opcaoEscolhida);
    bool opcoesValidasContemOpcaoEscolhida = opcoesValidas.Contains(opcaoEscolhida);

    if (opcaoDigitadaNulaOuVazia || !conseguiuConverterOpcaoDigitadaParaInt || !opcoesValidasContemOpcaoEscolhida)
        Console.WriteLine("Opcao invalida!");

    switch (opcaoEscolhida)
    {
        case 1:
            VisualizarTarefas();
            break;
        case 2:
            CadastrarTarefa();
            break;
        // case 3:
        //     AtualizarTarefa();
        //     break;
        // case 4:
        //     ExcluirTarefa();
        //     break;
        case 5:
            Console.WriteLine("Ate logo!");
            break;

    }
}

void VisualizarTarefas()
{
    Console.Clear();
    Console.WriteLine("Voce escolheu visualizar tarefa ");

    if (tarefas.Any())
    {
        Console.WriteLine("Segue abaixo as tarefas cadastradas:");
        foreach (string tarefa in tarefas)
            Console.WriteLine(tarefa);
    }
    else
        Console.WriteLine("\nVoce nao possui tarefas cadastradas.");
}

void CadastrarTarefa()
{
    Console.Clear();
    Console.WriteLine("Digite a tarefa que gostaria de cadastrar");
    string nomeTarefa = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Tarefa cadastrada com sucesso!");
    Console.WriteLine("Deseja cadastrar outra tarefa? Sim para cadastrar ou nao para voltar ao menu");

    if (Console.ReadLine() == "sim")
    {
        Console.WriteLine("Digite uma nova tarefa: ");
        Console.ReadLine();
    }




    if (string.IsNullOrWhiteSpace(nomeTarefa))
        Console.WriteLine("Opcao invalida");






    // aguardar o usuario digitar a tarefa
    // perguntar se o usuario deseja cadastrar outra tarefa
    // se sim informar ao usuario para digitar uma nova tarefa
    // se nao perguntar ao usuario se deseja sair ou voltar ao menu


}

// void AtualizarTarefa()
// {

// }
// void ExcluirTarefa()
// {

// }


#endregion

