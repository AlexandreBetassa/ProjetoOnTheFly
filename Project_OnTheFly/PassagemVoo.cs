using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class PassagemVoo
    {
        public string IdPassagem { get; set; } //CHAVE PA0000 – Dois dígitos PA, seguidos de 4 dígitos numéricos.
        public Voo Voo { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public float Valor { get; set; } //maximo 9.999,99
        public char Situacao { get; set; }

        public PassagemVoo()
        {

        }

        public PassagemVoo(string id, Voo voo, DateTime dataUltimaOperacao, float valor, char situacao)
        {
            IdPassagem = id;
            Voo = voo;
            DataUltimaOperacao = dataUltimaOperacao;
            Valor = valor;
            Situacao = situacao; // L libre, R Reservada ou P paga
        }

        public void CadastrarPassagemVoo(List<Voo> listaVoos)
        {
            //Id

            //Lista de Voos
            Console.WriteLine("Lista de Voos:");
            foreach (Voo item in listaVoos)
            {
                if (item.Situacao == 'A')
                    Console.WriteLine(item.ToString());
            }

            Console.Write("Informe qual Voo pertence esta Passagem: ");
            string idVoo = Console.ReadLine();

            foreach (Voo item in listaVoos)
            {
                if (item.Situacao == 'A')
                {
                    if (item.IdVoo == idVoo)
                        this.Voo = item;
                }
            }

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
            if (Valor > 9999.99 || Valor < 0)
            {
                Console.WriteLine("Valor das passagem excedeu o limite permitido.");
            }
        }

        //FALTA SITUAÇÃO

        public void EditarPassagemVoo()
        {
            PassagemVoo passagem = new();
            int op;
            do
            {
                Console.Write("Escolha o item que você deseja editar: ");
                Console.Write("1 - Valor");
                Console.Write("2 - Situação");
                Console.Write("0 - Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("Informe o NOVO valor da passagem: ");
                        Valor = float.Parse(Console.ReadLine());
                        if (Valor > 9999.99 || Valor < 0)
                        {
                            Console.WriteLine("Valor de Passagem excedeu o limite!");
                            break;
                        }
                        else
                        {
                            passagem.Valor = Valor;
                            Console.WriteLine("Novo valor gerado com sucesso!");
                        }
                        break;
                    case 2:
                        Console.Write("Informe A NOVA Situação: ");
                        char situacao = char.Parse(Console.ReadLine());
                        passagem.Situacao = situacao;
                        Console.WriteLine("Passagem editada com sucesso");
                        break;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;

                }
            } while (op != 0);
        }
    }
}
