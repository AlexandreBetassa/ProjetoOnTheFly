using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class PassagemVoo
    {
        public string Id { get; set; } //CHAVE PA0000 – Dois dígitos PA, seguidos de 4 dígitos numéricos.
        public Voo Voo { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public float Valor { get; set; } //maximo 9.999,99
        public char Situacao { get; set; }

        public PassagemVoo()
        {
            Console.WriteLine();
        }
        

        public PassagemVoo(string id, Voo voo, DateTime dataUltimaOperacao, float valor, char situacao)
        {
            Id = id;
            Voo = voo;
            DataUltimaOperacao = dataUltimaOperacao;
            Valor = valor;
            Situacao = situacao;
        }


    }
}
