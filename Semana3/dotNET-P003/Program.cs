using System;

namespace EstoqueProdutos
{
    class Program
    {
        static void Main()
        {
            Estoque estoque = new Estoque();

            while (true)
            {
                Console.WriteLine("\n===== Menu Principal =====");
                Console.WriteLine("1. Cadastrar Produto");
                Console.WriteLine("2. Consultar Produto");
                Console.WriteLine("3. Atualizar Estoque");
                Console.WriteLine("4. Gerar Relatórios");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Código: ");
                        int codigo = int.Parse(Console.ReadLine());

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Quantidade: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        Console.Write("Preço: ");
                        decimal preco = decimal.Parse(Console.ReadLine());

                        try
                        {
                            estoque.CadastrarProduto(codigo, nome, quantidade, preco);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.Write("Digite o código do produto: ");
                        int codigoConsulta = int.Parse(Console.ReadLine());

                        try
                        {
                            var produtoConsultado = estoque.ConsultarProduto(codigoConsulta);
                            Console.WriteLine($"Produto encontrado: {produtoConsultado.Nome}, Quantidade: {produtoConsultado.Quantidade}, Preço: {produtoConsultado.Preco:C}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "3":
                        Console.Write("Digite o código do produto: ");
                        int codigoAtualizacao = int.Parse(Console.ReadLine());

                        Console.Write("Digite a quantidade de entrada/saída: ");
                        int quantidadeAtualizacao = int.Parse(Console.ReadLine());

                        try
                        {
                            estoque.AtualizarEstoque(codigoAtualizacao, quantidadeAtualizacao);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "4":
                        estoque.GerarRelatorios();
                        break;

                    case "0":
                        Console.WriteLine("Saindo do programa.");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
