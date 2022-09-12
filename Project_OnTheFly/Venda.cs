using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; } //data atual
        public Passageiro Passageiro { get; set; }
        public float ValorTotal { get; set; }


        public void CadastrarVenda()
        {
            Console.WriteLine("Informe o CÓDIGO de IDENTIFICAÇÃO DA VENDA");
        }
        //Passageiro Deverá armazenar apenas o CPF do Passageiro, mas ao
        //ser informado, deverá trazer o nome e a data de
        //nascimento do cliente, para uma verificação junto ao
        //mesmo.
        //for each, comparar valor do cpf se for igual ao informado
        //var int id, começando em 1 e cada vez que , incrementar 1
    }
}
