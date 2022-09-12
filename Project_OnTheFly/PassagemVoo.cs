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

        }

        public PassagemVoo(string id, Voo voo, DateTime dataUltimaOperacao, float valor, char situacao)
        {
            Id = id;
            Voo = voo;
            DataUltimaOperacao = dataUltimaOperacao;
            Valor = valor;
            Situacao = situacao; // L libre, R Reservada ou P paga
        }

        public void CadastrarPassagemVoo()
        {
            //Id

            //IdVoo

            bool aux;
            DateTime aux1;
            do
            {
                Console.Write("Informe a data da último operação: ");
                aux = DateTime.TryParse(Console.ReadLine(), out aux1);
            } while (!aux);
            DataUltimaOperacao = aux1;

            Console.Write("Informe o valor das passagens desse voo: ");
            Valor = float.Parse(Console.ReadLine());
            if(Valor > 9999.99 || Valor < 0)
            {
                Console.WriteLine("Valor das passagem excedeu o limite permitido.");
                break;
            }

            //FALTA SITUAÇÃO

            public void EditarPassagemVoo()
            {
                PassagemVoo passagem = new();

                Console.Write("Escolha o item que você deseja editar: ");
                Console.Write("1 - Valor");
                Console.Write("2 - Situação");
                Console.Write("0 - Sair");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    //case 0:
                    // break;
                    case 1:
                        Console.Write("Informe o NOVO valor da passagem: ");
                        Valor = float.Parse(Console.ReadLine());
                        if (valor > 9999.99 || valor < 0)
                        {
                            Console.WriteLine("Valor de Passagem excedeu o limite!");
                            break;
                        }
                        else
                        {
                            passagem.Valor = valor;
                            Console.WriteLine("Novo valor gerado com sucesso!");
                        }
                        break;
                    case 2:
                        Console.Write("Informe A NOVA Situação: );
                        char situacao = char.Parse(Console.ReadLine());
                        passagem.Situacao = situacao;
                        Console.WriteLine("Pasagem editada com sucesso");
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
