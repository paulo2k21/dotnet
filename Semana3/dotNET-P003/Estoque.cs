using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueProdutos
{
    public class Estoque
    {
        private List<Produto> produtos;

        public Estoque()
        {
            produtos = new List<Produto>();
        }

        public void CadastrarProduto(int codigo, string nome, int quantidade, decimal preco)
        {
            if (codigo <= 0 || quantidade < 0 || preco < 0)
            {
                throw new ArgumentException("Valores inválidos para o produto.");
            }

            if (produtos.Any(p => p.Codigo == codigo))
            {
                throw new InvalidOperationException("Código de produto já cadastrado.");
            }

            produtos.Add(new Produto { Codigo = codigo, Nome = nome, Quantidade = quantidade, Preco = preco });
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        public Produto ConsultarProduto(int codigo)
        {
            if (codigo <= 0)
            {
                throw new ArgumentException("Código de produto inválido.");
            }

            var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);

            if (produto == null)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }

            return produto;
        }

        public void AtualizarEstoque(int codigo, int quantidadeAtualizacao)
        {
            if (codigo <= 0 || quantidadeAtualizacao == 0)
            {
                throw new ArgumentException("Valores inválidos para atualização de estoque.");
            }

            var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);

            if (produto == null)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }

            if (quantidadeAtualizacao < 0 && Math.Abs(quantidadeAtualizacao) > produto.Quantidade)
            {
                throw new InvalidOperationException("Quantidade insuficiente para saída de estoque.");
            }

            produto.Quantidade += quantidadeAtualizacao;
            Console.WriteLine("Estoque atualizado com sucesso!");
        }

        public IEnumerable<Produto> ProdutosAbaixoLimite(int limite)
        {
            return produtos.Where(p => p.Quantidade < limite);
        }

        public IEnumerable<Produto> ProdutosEntreValores(decimal min, decimal max)
        {
            return produtos.Where(p => p.Preco >= min && p.Preco <= max);
        }

        public decimal ValorTotalEstoque()
        {
            return produtos.Sum(p => p.Quantidade * p.Preco);
        }

        public void GerarRelatorios()
        {
            try
            {
                // Relatório 1: Lista de produtos com quantidade em estoque abaixo de um limite informado pelo usuário.
                Console.Write("Informe o limite de quantidade para o relatório 1: ");
                int limiteRelatorio1 = int.Parse(Console.ReadLine());

                var relatorio1 = ProdutosAbaixoLimite(limiteRelatorio1);
                Console.WriteLine("Relatório - Produtos abaixo do limite:");
                foreach (var produto in relatorio1)
                {
                    Console.WriteLine($"{produto.Nome}: {produto.Quantidade} unidades");
                }

                // Relatório 2: Lista de produtos com valor entre um mínimo e um máximo informados pelo usuário.
                Console.Write("Informe o valor mínimo para o relatório 2: ");
                decimal minRelatorio2 = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o valor máximo para o relatório 2: ");
                decimal maxRelatorio2 = decimal.Parse(Console.ReadLine());

                var relatorio2 = ProdutosEntreValores(minRelatorio2, maxRelatorio2);
                Console.WriteLine("Relatório - Produtos entre valores:");
                foreach (var produto in relatorio2)
                {
                    Console.WriteLine($"{produto.Nome}: {produto.Preco:C}");
                }

                // Relatório 3: Informar o valor total do estoque e o valor total de cada produto de acordo com seu estoque.
                var valorTotalEstoqueRelatorio3 = ValorTotalEstoque();
                Console.WriteLine($"Relatório - Valor total do estoque: {valorTotalEstoqueRelatorio3:C}");

                Console.WriteLine("Relatório - Valor total de cada produto de acordo com seu estoque:");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"{produto.Nome}: {produto.Quantidade * produto.Preco:C}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir um formato válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatórios: {ex.Message}");
            }
        }
    }
}
