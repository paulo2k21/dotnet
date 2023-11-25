using System;
using System.Collections.Generic;
using System.Linq;

public record Produto(int Codigo, string Nome, int Quantidade, double Preco);

class Program
{
    private static List<Produto> estoque = new List<Produto>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto por Código");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    ConsultarProdutoPorCodigo();
                    break;
                case "3":
                    AtualizarEstoque();
                    break;
                case "4":
                    GerarRelatorios();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void CadastrarProduto()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço unitário: ");
            double preco = double.Parse(Console.ReadLine());

            estoque.Add(new Produto(codigo, nome, quantidade, preco));
            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir valores numéricos corretos.");
        }
    }

    private static void ConsultarProdutoPorCodigo()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.Find(p => p.Codigo == codigo);

            if (produto == null)
            {
                throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
            }

            Console.WriteLine($"Produto encontrado: {produto}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir um código numérico.");
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static void AtualizarEstoque()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.Find(p => p.Codigo == codigo);

            if (produto == null)
            {
                throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
            }

            Console.Write("Digite a quantidade a ser adicionada (negativa para saída): ");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade >= 0)
            {
                // Adição de produtos ao estoque
                produto = produto with { Quantidade = produto.Quantidade + quantidade };
                Console.WriteLine("Estoque atualizado com sucesso!");
            }
            else
            {
                // Saída de produtos do estoque
                if (produto.Quantidade + quantidade < 0)
                {
                    throw new EstoqueInsuficienteException("Quantidade em estoque insuficiente para essa saída.");
                }

                produto = produto with { Quantidade = produto.Quantidade + quantidade };
                Console.WriteLine("Estoque atualizado com sucesso!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir valores numéricos corretos.");
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (EstoqueInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static void GerarRelatorios()
    {
        try
        {
            Console.Write("Digite o limite de quantidade para o relatório 1: ");
            int limiteQuantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor mínimo para o relatório 2: ");
            double minValor = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor máximo para o relatório 2: ");
            double maxValor = double.Parse(Console.ReadLine());

            // Relatório 1: Lista de produtos com quantidade em estoque abaixo do limite
            var relatorio1 = estoque.Where(p => p.Quantidade < limiteQuantidade);
            Console.WriteLine("Relatório 1: Produtos com quantidade em estoque abaixo do limite:");
            ImprimirRelatorio(relatorio1);

            // Relatório 2: Lista de produtos com valor entre o mínimo e o máximo
            var relatorio2 = estoque.Where(p => p.Preco >= minValor && p.Preco <= maxValor);
            Console.WriteLine("Relatório 2: Produtos com valor entre o mínimo e o máximo:");
            ImprimirRelatorio(relatorio2);

            // Relatório 3: Valor total do estoque e valor total de cada produto
            double valorTotalEstoque = estoque.Sum(p => p.Quantidade * p.Preco);
            Console.WriteLine($"Relatório 3: Valor total do estoque: {valorTotalEstoque:C}");
            Console.WriteLine("Valor total de cada produto:");

            // Utilizando LINQ para calcular e imprimir o valor total de cada produto
            var relatorio3 = estoque.Select(p => new { Produto = p, ValorTotalProduto = p.Quantidade * p.Preco });
            foreach (var item in relatorio3)
            {
                Console.WriteLine($"{item.Produto.Nome}: {item.ValorTotalProduto:C}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir valores numéricos corretos.");
        }
    }

    private static void ImprimirRelatorio(IEnumerable<Produto> produtos)
    {
        foreach (var produto in produtos)
        {
            Console.WriteLine(produto);
        }
    }
}

class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string message) : base(message)
    {
    }
}

class EstoqueInsuficienteException : Exception
{
    public EstoqueInsuficienteException(string message) : base(message)
    {
    }
}
