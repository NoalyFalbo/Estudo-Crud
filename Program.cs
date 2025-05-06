var opcoesMenu = new List<(int, string)>
{
    (1, "Cadastrar tarefa"),
    (2, "Visualizar tarefa"),
    (3, "Atualizar tarefa"),
    (4, "Excluir tarefa"),
    (5, "Sair"),
};

var tarefas = new List<(int, string)>();

void ChamarMenu()
{
    foreach (var opcao in opcoesMenu)
        Console.WriteLine(opcao.Item1 + " - " + opcao.Item2);
}

void EscolherOpcao()
{
    //TODO obter input do usuario, 
    // validar se o input e valido
    // transformar o input em um inteiro
    //  utilizar o valor no switch para decidir a chamada

    // int teste = ;

    // switch(teste)
    // {

    // }
}

void CadastrarTarefa()
{
    Console.WriteLine("Digite a tarefa que gostaria de cadastrar");
    Console.ReadKey();
}

void VisualizarTarefa()
{
    Console.WriteLine("Voce escolheu visualizar tarefa ");


}
void AtualizarTarefa()
{

}
void ExcluirTarefa()
{

}

void App()
{    
    Console.Clear();
    Console.WriteLine("Bem vindo ao World Of Points! ");
    ChamarMenu();
    // VisualizarTarefa();
}

App();




// git add . 
// git stash -m "nomequalquer"
// 