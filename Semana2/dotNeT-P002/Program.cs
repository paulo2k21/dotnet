/*Objetivo:
Desenvolver um sistema de gerenciamento de tarefas que permita aos usuários criar,
visualizar e gerenciar tarefas.
Requisitos do Projeto:
O sistema deve permitir a criação de tarefas, incluindo um título, descrição e data de
vencimento.
Deve ser possível listar todas as tarefas criadas.
Os usuários devem poder marcar tarefas como concluídas.
O sistema deve fornecer uma lista de tarefas pendentes e uma lista de tarefas
concluídas.
Os usuários devem ser capazes de excluir tarefas.
Implemente uma pesquisa que permita aos usuários encontrar tarefas com base em
palavras-chave.
O sistema deve fornecer estatísticas básicas, como o número de tarefas concluídas e
pendentes, a tarefa mais antiga e a tarefa mais recente.
Dicas:
Use um Array ou uma List para armazenar as tarefas.
Use estruturas de controle de fluxo (if, else, for, while, do-while, foreach) para
implementar as funcionalidades do sistema.
Use a classe DateTime para lidar com datas e prazos.
Solicite entradas do usuário para criar, editar e excluir tarefas.
Use strings para armazenar os títulos e descrições das tarefas. */


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            ShowMenu();

            int choice = GetChoice();

            ProcessChoice(choice);
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("==== Lista de Tarefas ====");
        Console.WriteLine("1. Adicionar Nova Tarefa");
        Console.WriteLine("2. Ver Todas as Tarefas");
        Console.WriteLine("3. Marcar Tarefa como Concluída");
        Console.WriteLine("4. Ver Tarefas Pendentes");
        Console.WriteLine("5. Ver Tarefas Concluídas");
        Console.WriteLine("6. Excluir Tarefa");
        Console.WriteLine("7. Pesquisar Tarefas por Palavra-chave");
        Console.WriteLine("8. Exibir Estatísticas");
        Console.WriteLine("9. Sair");
    }

    static int GetChoice()
    {
        Console.Write("Escolha uma opção: ");
        while (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.Write("Por favor, insira um número válido. Tente novamente: ");
        }
        return choice;
    }

    static void ProcessChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                CreateTask();
                break;
            case 2:
                ListAllTasks();
                break;
            case 3:
                MarkTaskAsCompleted();
                break;
            case 4:
                ListPendingTasks();
                break;
            case 5:
                ListCompletedTasks();
                break;
            case 6:
                DeleteTask();
                break;
            case 7:
                SearchTasksByKeyword();
                break;
            case 8:
                DisplayStatistics();
                break;
            case 9:
                Console.WriteLine("Obrigado por usar o Lista de Tarefas. Até logo!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                break;
        }
    }

    static void CreateTask()
    {
        Console.Write("Digite o título da nova tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Descreva a tarefa: ");
        string description = Console.ReadLine();

        Console.Write("Digite a data de vencimento (YYYY-MM-DD): ");
        DateTime dueDate;
        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            Console.Write("Formato de data inválido. Por favor, insira novamente: ");
        }

        Task task = new Task(title, description, dueDate);
        tasks.Add(task);

        Console.WriteLine($"Tarefa '{title}' adicionada com sucesso! (Número: {tasks.Count})");
    }

    static void ListAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Não há tarefas cadastradas.");
            return;
        }

        Console.WriteLine("=== Todas as Tarefas ===");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        int taskNumber = GetChoice();

        if (taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].MarkAsCompleted();
            Console.WriteLine($"Tarefa '{tasks[taskNumber - 1].Title}' marcada como concluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tente novamente.");
        }
    }

    static void ListPendingTasks()
    {
        var pendingTasks = tasks.FindAll(task => !task.IsCompleted);
        DisplayTasks("Tarefas Pendentes", pendingTasks);
    }

    static void ListCompletedTasks()
    {
        var completedTasks = tasks.FindAll(task => task.IsCompleted);
        DisplayTasks("Tarefas Concluídas", completedTasks);
    }

    static void DisplayTasks(string title, List<Task> taskList)
    {
        Console.WriteLine($"=== {title} ===");
        if (taskList.Count == 0)
        {
            Console.WriteLine($"Não há {title.ToLower()} no momento.");
            return;
        }

        foreach (var task in taskList)
        {
            Console.WriteLine(task);
        }
    }

    static void DeleteTask()
    {
        Console.Write("Digite o número da tarefa a ser excluída: ");
        int taskNumber = GetChoice();

        if (taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tente novamente.");
        }
    }

    static void SearchTasksByKeyword()
    {
        Console.Write("Digite uma palavra-chave para pesquisa: ");
        string keyword = Console.ReadLine().ToLower();

        var matchingTasks = tasks.FindAll(task => task.Title.ToLower().Contains(keyword) || task.Description.ToLower().Contains(keyword));
        DisplayTasks("Tarefas Encontradas", matchingTasks);
    }

    static void DisplayStatistics()
    {
        int totalTasks = tasks.Count;
        int completedTasks = tasks.Count(task => task.IsCompleted);
        int pendingTasks = totalTasks - completedTasks;

        Console.WriteLine($"Total de Tarefas: {totalTasks}");
        Console.WriteLine($"Tarefas Concluídas: {completedTasks}");
        Console.WriteLine($"Tarefas Pendentes: {pendingTasks}");

        if (completedTasks > 0)
        {
            var oldestTask = tasks.OrderBy(task => task.DueDate).FirstOrDefault();
            var newestTask = tasks.OrderByDescending(task => task.DueDate).FirstOrDefault();

            Console.WriteLine($"Tarefa Mais Antiga: {oldestTask}");
            Console.WriteLine($"Tarefa Mais Recente: {newestTask}");
        }
    }
}

class Task
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public bool IsCompleted { get; private set; }

    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public override string ToString()
    {
        return $"Tarefa: {Title}\nDescrição: {Description}\nData de Vencimento: {DueDate}\nStatus: {(IsCompleted ? "Concluída" : "Pendente")}\n";
    }
}

