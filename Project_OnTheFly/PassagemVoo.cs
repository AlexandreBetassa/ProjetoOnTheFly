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
            this.Situacao = 'L';
            this.DataUltimaOperacao = DateTime.Now;
        }

        //CONFERIR SE A LISTA ESTA CERTA
        public void CadastrarPassagemVoo(List<Voo> listaVoos, List<PassagemVoo> listaPassagemVoo)
        {
            
            // INSERIR idvoo 

            //ID CHAVE
            if (listaPassagemVoo.Count > 9999)
            {
                Console.WriteLine("Limite de passagens atingido!");
                return;
            }
            //A passagem de voo é gerada na Venda
            this.IdPassagem = "PA" + (listaPassagemVoo.Count() + 1).ToString("0000");

            //Lista de Voos
            Console.WriteLine("Lista de Voos:");
            foreach (Voo item in listaVoos)
            {
                if (item.Situacao == 'A')
                    Console.WriteLine(item.ToString());
            }

            Console.Write("Informe qual Voo pertence esta Passagem (Ex: V0000): ");
            string idVoo = Console.ReadLine();

            foreach (Voo item in listaVoos)
            {
                if (item.Situacao == 'A')
                {
                    if (item.IdVoo == idVoo)
                        this.Voo = item;
                }
            }

            Console.Write("Informe o valor das passagens desse voo: ");
            Valor = float.Parse(Console.ReadLine());
            if (Valor > 9999.99 || Valor < 0)
            {
                Console.WriteLine("Valor das passagem excedeu o limite permitido.");
            }
        }

        public void EditarPassagemVoo()
        {
            
            int op;
            do
            {
                Console.Write("Escolha o item que você deseja editar: ");
                Console.Write("0 - Sair");
                Console.Write("1 - Valor");
                Console.Write("2 - Situação");              
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("SAINDO...");
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
                            Valor = Valor;
                            Console.WriteLine("Novo valor gerado com sucesso!");
                        }
                        break;

                    case 2:
                        Console.Write("Informe A NOVA Situação: ");
                        char situacao = char.Parse(Console.ReadLine());
                        Situacao = situacao;
                        Console.WriteLine("Passagem editada com sucesso!");
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } while (op != 0);
        }

        public override string ToString()
        {
            return $"IdPassagem: {IdPassagem} \nIdVoo:  {Voo.IdVoo} \nData da última operação: {DataUltimaOperacao} \nValor: {Valor} \nSituação da Passagem: {Situacao}";
        }
    }
}
