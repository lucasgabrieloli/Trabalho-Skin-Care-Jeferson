using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace controledeestoque
{

    using System.Collections.Generic;

    public class ServicoEstoque
    {
        private RepositorioProduto repositorioProduto = new RepositorioProduto();

        public void AdicionarProduto(Produto produto)
        {
            repositorioProduto.AdicionarProduto(produto);
            Console.WriteLine("Produto adicionado com sucesso.");
        }

        public void ExibirProdutos()
        {
            var produtos = repositorioProduto.ObterProdutos();
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto no estoque.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Código EAN: {produto.CodigoEAN}");
                Console.WriteLine($"Valor: {produto.Valor:C}");
                Console.WriteLine($"Descrição: {produto.Descricao}");
                Console.WriteLine($"Estoque: {produto.Estoque}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public void AtualizarProduto(int id, string nome, string codigoEAN, decimal valor, string descricao, int estoque)
        {
            var produto = repositorioProduto.ObterProdutoPorId(id);
            if (produto != null)
            {
                produto.Nome = nome;
                produto.CodigoEAN = codigoEAN;
                produto.Valor = valor;
                produto.Descricao = descricao;
                produto.Estoque = estoque;
                repositorioProduto.AtualizarProduto(produto);
                Console.WriteLine("Produto atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        public void RemoverProduto(int id)
        {
            repositorioProduto.RemoverProduto(id);
            Console.WriteLine("Produto removido com sucesso.");
        }
    }
}

