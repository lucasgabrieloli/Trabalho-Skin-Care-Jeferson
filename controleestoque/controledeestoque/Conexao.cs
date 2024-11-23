using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace controledeestoque
{
  
    public class Conexao
    {
        private readonly string connectionString;

        public Conexao()
        {
            connectionString = "server=localhost;database=sistemaBeG;user=root;password=";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }

}
