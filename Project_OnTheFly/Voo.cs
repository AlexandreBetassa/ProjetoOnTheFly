using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Voo
    {
        public string IdVoo { get; set; } //V0000
        public string Destino { get; set; }
        public DateTime DataVoo { get; set; } // Data 8 dígitos + 4 dígitos da hora
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; } //A Ativo ou C Cancelado
        public Aeronave Aeronave { get; set; }

        public Voo()
        {
            this.Situacao = 'A';
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

        public void CadastrarVoo(List<String> listaIatas, List<Aeronave> listaAeronaves, List<Voo> listaVoos)
        {
            // INSERIR idvoo 
            if (listaVoos.Count > 9999)
            {
                Console.WriteLine("Limite de Voos atingidos!");
                return;
            }

            this.IdVoo = "V" + (listaVoos.Count() + 1).ToString("0000");
            //Nome do Aeroporto
            do
            {
                Console.Write("Informe o AEROPORTO de destino do voo: [EX: GRU]");
                Destino = Console.ReadLine().ToUpper();

                if (ValidarIATA(listaIatas, Destino) == false)
                {
                    Console.WriteLine("\nDESTINO INVÁLIDO.");
                    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA INFORMAR NOVAMENTE!");
                    Console.ReadKey();
                }
            } while (ValidarIATA(listaIatas, Destino) == false);

            //INSERIR AERONAVE

            //Data e hora do voo
            Console.Write("Informe a data e hora do voo: ");
            DataVoo = DateTime.Parse(Console.ReadLine());

            bool aux;
            DateTime aux1;

            //data do cadastro
            do
            {
                Console.Write("Informe a Data de Cadastro: ");
                aux = DateTime.TryParse(Console.ReadLine(), out aux1);
            } while (!aux);
            DataCadastro = aux1;

            //Listar Aeronaves
            Console.WriteLine("Lista de Aeronaves Cadastradas:");
            foreach (Aeronave item in listaAeronaves)
            {
                if (item.Situacao == 'A')
                    Console.WriteLine(item.ToString());
            }

            Console.Write("Informe qual Aeronave pertence a este Voo: ");
            string insc = Console.ReadLine();

            foreach (Aeronave item in listaAeronaves)
            {
                if (item.Situacao == 'A')
                {
                    if (item.Inscricao == insc)
                    this.Aeronave = item;
                }
            }
        }

        #region Validar destino IATA
        public static bool ValidarIATA(List<String> listaIatas, string destino)
        {
            bool achei = false;

            foreach (string d in listaIatas)
            {
                if (destino == d)
                {
                    achei = true;

                }
                else
                {
                    if (achei == false)
                    {
                        Console.WriteLine("Destino não foi localizado. Informe novamente com o destino correto!");
                        Console.WriteLine("Aperte qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            return true;
        }
        #endregion 

        public void EditarVoo()
        {
            Voo voo = new();

            Console.Write("Editar SITUAÇÃO");

            Console.Write("Infome a NOVA situação do voo:\nA - Ativo OU C - Cancelado: ");
            char situacao = char.Parse(Console.ReadLine());
            voo.Situacao = situacao;
        }

        public void EditarVoo()
        {

        }
<<<<<<<<< Temporary merge branch 1
        public override string ToString()
=========
       public override string ToString()
>>>>>>>>> Temporary merge branch 2
        {
            return "\nIdVoo: " + IdVoo + "\nDestino: " + Destino + "\nData do Voo: " + DataVoo + "\nData do Cadastro: " + DataCadastro + "\nSituação: " + Situacao;
        }

    }
}
