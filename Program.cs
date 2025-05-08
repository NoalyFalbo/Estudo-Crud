﻿#region Variaveis globais
List<(int, string)> opcoesMenu = new List<(int, string)>
{
    (1, "Visualizar tarefa"),
    (2, "Cadastrar tarefa"),
    (3, "Atualizar tarefa"),
    (4, "Excluir tarefa"),
    (5, "Sair"),
};

List<string> tarefas = new List<string>();

bool continuar = true;
#endregion

#region Chamada do Programa
App();

void App()
{
    Console.Clear();
    Console.WriteLine("Bem vindo ao World Of Points! ");

    while (continuar)
    {
        ChamarMenu();
        EscolherOpcao();
    }
}
#endregion

#region Outros Metodos

void ChamarMenu()
{
    Console.Clear();
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
        case 3:
            AtualizarTarefa();
            break;
        case 4:
            ExcluirTarefa();
            break;
        case 5:
            Console.WriteLine("Ate logo!");
            continuar = false;
            break;

    }
}

void VisualizarTarefas()
{
    Console.Clear();
    Console.WriteLine("Voce escolheu visualizar tarefa ");

    if (tarefas.Count != 0)
    {
        Console.WriteLine("Segue abaixo as tarefas cadastradas:");
        foreach (string tarefa in tarefas)
            Console.WriteLine(tarefa);
    }
    else
    {
        Console.WriteLine("\nVoce nao possui tarefas cadastradas.");
    }
    Console.WriteLine("Aperte qualquer tecla para continuar.");
    Console.ReadKey();
    Console.Clear();
}


void CadastrarTarefa()
{
    Console.Clear();
    string resposta = "sim";

    while (resposta == "sim")
    {
        Console.WriteLine("Digite a tarefa que gostaria de cadastrar:");
        string nomeTarefa = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nomeTarefa))
        {
            tarefas.Add(nomeTarefa);
            Console.WriteLine("Tarefa cadastrada com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa inválida. Tente novamente.");
            continue;
        }

        Console.WriteLine("Deseja cadastrar outra tarefa? Digite sim para cadastrar ou nao para voltar ao menu");
        resposta = Console.ReadLine().Trim().ToLower();
    }

}

void AtualizarTarefa()
{
    Console.Clear();
    Console.WriteLine("Você escolheu atualizar uma tarefa.");

    if (tarefas.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa cadastrada para atualizar.");
        return;
    }

    Console.WriteLine("Tarefas cadastradas:");
    for (int i = 0; i < tarefas.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {tarefas[i]}");
    }

    Console.WriteLine("Digite o número da tarefa que deseja atualizar:");
    string entrada = Console.ReadLine();

    bool conversaoValida = int.TryParse(entrada, out int numeroTarefa);
    bool indiceValido = numeroTarefa >= 1 && numeroTarefa <= tarefas.Count;

    if (!conversaoValida || !indiceValido)
    {
        Console.WriteLine("Número inválido. Retornando ao menu.");
        return;
    }

    int indice = numeroTarefa - 1;

    Console.WriteLine($"Digite a nova descrição para a tarefa \"{tarefas[indice]}\":");
    string novaDescricao = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(novaDescricao))
    {
        Console.WriteLine("Descrição inválida. A tarefa não foi atualizada.");
        return;
    }

    tarefas[indice] = novaDescricao;
    Console.WriteLine("Tarefa atualizada com sucesso!");
}

void ExcluirTarefa()
{
     Console.Clear();
    Console.WriteLine("Você escolheu excluir uma tarefa.");

    if (!tarefas.Any())
    {
        Console.WriteLine("Nenhuma tarefa cadastrada para excluir.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("Tarefas cadastradas:");
    for (int i = 0; i < tarefas.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {tarefas[i]}");
    }

    Console.WriteLine("Digite o número da tarefa que deseja excluir:");
    string entrada = Console.ReadLine();

    bool numeroDigitadoValido = int.TryParse(entrada, out int numeroTarefa);
    bool indiceValido = numeroTarefa >= 1 && numeroTarefa <= tarefas.Count;

    if (!numeroDigitadoValido || !indiceValido)
    {
        Console.WriteLine("Número inválido. Retornando ao menu.");
        Console.ReadKey();
        return;
    }

    int ExcluirTarefa = numeroTarefa - 1;

    Console.WriteLine($"Tem certeza que deseja excluir a tarefa \"{tarefas[ExcluirTarefa]}\"? Digite sim para excluir ou nao para voltar ao menu");
    string confirmacao = Console.ReadLine()?.Trim().ToLower();

    if (confirmacao == "sim")
    {
        tarefas.RemoveAt(ExcluirTarefa);
        Console.WriteLine("Tarefa excluída com sucesso!");
    }
    else
    {
        Console.WriteLine("A tarefa não foi excluída.");
    }

    Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    Console.ReadKey();

}


#endregion