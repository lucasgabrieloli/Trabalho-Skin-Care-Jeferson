using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controledeestoque
{
    public class Cep
    {
        public string NumCEP { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Cep(string numCEP, string rua, string cidade, string estado)
        {
            NumCEP = numCEP;
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
        }
    }

}
