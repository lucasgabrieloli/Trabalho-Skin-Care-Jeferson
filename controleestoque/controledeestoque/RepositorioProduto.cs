using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace controledeestoque
{


    public class RepositorioProduto
    {
        private Conexao conexao = new Conexao();

        public void AdicionarProduto(Produto produto)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO produto (nome_prod, codigoEAN, val_prod, descricao_prod, estoque_prod) VALUES (@nome, @codigoEAN, @valor, @descricao, @estoque)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@codigoEAN", produto.CodigoEAN);
                    cmd.Parameters.AddWithValue("@valor", produto.Valor);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Produto adicionado com sucesso.");
        }

        public List<Produto> ObterProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM produto";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto(
                                reader.GetInt32("idProduto"),
                                reader.GetString("nome_prod"),
                                reader.GetString("codigoEAN"),
                                reader.GetDecimal("val_prod"),
                                reader.GetString("descricao_prod"),
                                reader.GetInt32("estoque_prod")
                            );
                            produtos.Add(produto);
                        }
                    }
                }
            }
            return produtos;
        }

        public Produto ObterProdutoPorId(int id)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM produto WHERE idProduto = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Produto(
                                reader.GetInt32("idProduto"),
                                reader.GetString("nome_prod"),
                                reader.GetString("codigoEAN"),
                                reader.GetDecimal("val_prod"),
                                reader.GetString("descricao_prod"),
                                reader.GetInt32("estoque_prod")
                            );
                        }
                    }
                }
            }
            return null;
        }

        public void AtualizarProduto(Produto produtoAtualizado)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "UPDATE produto SET nome_prod = @nome, codigoEAN = @codigoEAN, val_prod = @valor, descricao_prod = @descricao, estoque_prod = @estoque WHERE idProduto = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", produtoAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@codigoEAN", produtoAtualizado.CodigoEAN);
                    cmd.Parameters.AddWithValue("@valor", produtoAtualizado.Valor);
                    cmd.Parameters.AddWithValue("@descricao", produtoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@estoque", produtoAtualizado.Estoque);
                    cmd.Parameters.AddWithValue("@id", produtoAtualizado.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Produto atualizado com sucesso.");
        }

        public void RemoverProduto(int id)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM produto WHERE idProduto = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Produto removido com sucesso.");
        }
    }
}
