using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Venda
    {
        public String IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public Passageiro Passageiro { get; set; }
        public float ValorTotal { get; set; }

        public Venda()
        {
        }

        public void CadastrarVenda()
        {

        }
    }
}
