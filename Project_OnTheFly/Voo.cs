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
        //public string Aeronave { get; set; }
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }
        public Aeronave Aeronave { get; set; }

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

        public void CadastrarVoo(List<String> listaIatas)
        {
            // INSERIR idvoo 

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

            //Data e hora do voo - INSERIR FORMATAÇÃO PARA SAIR DATA E HORA
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

            //Situação do voo
            Console.WriteLine("Infome situação do voo:\nA - ativo OU C - Cancelado");
            char situacao = char.Parse(Console.ReadLine().ToUpper());
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

        public void AlterarSituacao()
        {
            Voo voo = new();

            Console.Write("Editar SITUAÇÃO");

            Console.Write("Infome a NOVA situação do voo:\nA - Ativo OU C - Cancelado: ");
            char situacao = char.Parse(Console.ReadLine());
            voo.Situacao = situacao;

        }

        public override string ToString()
        {
            //INSERIR ID DA AERONAVE
            return "\nID do Voo: " + IdVoo + "\nDestino: " + Destino + "\nData do voo: " + DataVoo + "\nData de Cadastro do Voo: " + DataCadastro + "\nSituação: " + Situacao;
        }
    }
}
