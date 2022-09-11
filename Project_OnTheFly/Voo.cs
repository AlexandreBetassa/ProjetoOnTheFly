using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Voo
    {
        public string IdVoo { get; set; }
        public string Destino { get; set; }
        //IDAeronave
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Voo()
        {

        }

        public Voo(string idVoo, string destino, DateTime dataVoo, DateTime dataCadastro, char situacao)
        {
            IdVoo = idVoo;
            Destino = destino;
            //IdAeronave
            DataVoo = dataVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public void CadastrarVoo()
        {

        }
    }
}
