using controledeestoque;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ServicoEstoque servicoEstoque = new ServicoEstoque();

        while (true)
        {
            Console.WriteLine("Controle de Estoque de Produtos");
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Exibir Produtos");
            Console.WriteLine("3. Atualizar Produto");
            Console.WriteLine("4. Remover Produto");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    {
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Código EAN: ");
                        string codigoEAN = Console.ReadLine();
                        Console.Write("Valor: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
                        {
                            Console.WriteLine("Valor inválido. Por favor, insira um número decimal.");
                            break;
                        }
                        Console.Write("Descrição: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Estoque: ");
                        if (!int.TryParse(Console.ReadLine(), out int estoque))
                        {
                            Console.WriteLine("Quantidade de estoque inválida. Por favor, insira um número inteiro.");
                            break;
                        }
                        Produto produto = new Produto(0, nome, codigoEAN, valor, descricao, estoque);
                        servicoEstoque.AdicionarProduto(produto);
                        break;
                    }

                case 2:
                    {
                        servicoEstoque.ExibirProdutos();
                        break;
                    }

                case 3:
                    {
                        Console.Write("ID do produto a atualizar: ");
                        if (!int.TryParse(Console.ReadLine(), out int idAtualizar))
                        {
                            Console.WriteLine("ID inválido. Por favor, insira um número inteiro.");
                            break;
                        }
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Código EAN: ");
                        string codigoEAN = Console.ReadLine();
                        Console.Write("Valor: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
                        {
                            Console.WriteLine("Valor inválido. Por favor, insira um número decimal.");
                            break;
                        }
                        Console.Write("Descrição: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Estoque: ");
                        if (!int.TryParse(Console.ReadLine(), out int estoque))
                        {
                            Console.WriteLine("Quantidade de estoque inválida. Por favor, insira um número inteiro.");
                            break;
                        }
                        servicoEstoque.AtualizarProduto(idAtualizar, nome, codigoEAN, valor, descricao, estoque);
                        break;
                    }

                case 4:
                    {
                        Console.Write("ID do produto a remover: ");
                        if (!int.TryParse(Console.ReadLine(), out int idRemover))
                        {
                            Console.WriteLine("ID inválido. Por favor, insira um número inteiro.");
                            break;
                        }
                        servicoEstoque.RemoverProduto(idRemover);
                        break;
                    }

                case 5:
                    {
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Opção inválida.");
                        break;
                    }
            }

            Console.WriteLine();
        }
    }
}




















