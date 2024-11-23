using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controledeestoque
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoEAN { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }

        public Produto(int id, string nome, string codigoEAN, decimal valor, string descricao, int estoque)
        {
            Id = id;
            Nome = nome;
            CodigoEAN = codigoEAN;
            Valor = valor;
            Descricao = descricao;
            Estoque = estoque;
        }
    }

}
