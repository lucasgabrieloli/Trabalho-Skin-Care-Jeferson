using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace controledeestoque
{
    public class RepositorioCep
    {
        private Conexao conexao = new Conexao();

        public void AdicionarCep(Cep cep)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO cep (numCEP, rua_cep, cidade_cep, estado_cep) VALUES (@numCEP, @rua, @cidade, @estado)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numCEP", cep.NumCEP);
                    cmd.Parameters.AddWithValue("@rua", cep.Rua);
                    cmd.Parameters.AddWithValue("@cidade", cep.Cidade);
                    cmd.Parameters.AddWithValue("@estado", cep.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("CEP adicionado com sucesso.");
        }

        public List<Cep> ObterCeps()
        {
            List<Cep> ceps = new List<Cep>();
            using (var conn = conexao.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM cep";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cep cep = new Cep(
                                reader.GetString("numCEP"),
                                reader.GetString("rua_cep"),
                                reader.GetString("cidade_cep"),
                                reader.GetString("estado_cep")
                            );
                            ceps.Add(cep);
                        }
                    }
                }
            }
            return ceps;
        }
    }

}
