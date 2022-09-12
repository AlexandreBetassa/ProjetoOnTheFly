using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Aeronave
    {
        //CHAVE, PADRÃO ANAC, 6 DIGITOD ALFANUMERICOS
        public String Inscricao { get; set; }
        public int Capacidade { get; set; } //3 digitos numericos
        public int AssentosOcupados { get; set; } //3 digitos numericos
        public DateTime UltimaVenda { get; set; } //no cad, dt atual
        public DateTime DataCadastro { get; set; } //dt atual
        public char Situacao { get; set; }
        //associação da classe companhia aerea
        public CompanhiaAerea CompanhiaAerea { get; set; }

        public Aeronave()
        {

        }

        public Aeronave(string inscricao, int capacidade, int assentosOcupados, DateTime ultimaVenda, DateTime dataCadastro)
        {
            Inscricao = inscricao;
            Capacidade = capacidade;
            AssentosOcupados = assentosOcupados;
            UltimaVenda = DateTime.Now;
            DataCadastro = DateTime.Now;
            Situacao = 'A';
        }
        //Criar metodo para validar ID de AERONAVE ?
        //para cadastrar uma aeronave é necessário ela ser vinculada a uma compahia ?
        public void CadastroAeronave()
        {
            Console.WriteLine(">>>CADASTRO DE AERONAVE<<<");
            do
            {
                //não terá caracteres especiais (Delimitadores).
                Console.WriteLine("Informe o CÓDIGO de identificação da AERONAVE, segundo o padrão definido pela ANAC (XX-XXX): ");
                Inscricao = Console.ReadLine().ToUpper();
                //Fazer a tratativa de erros p nao digitar algo diferente de PP, PT, PR, PS
                //E de inserir 3 digitos numericos após o hífen
               //Fazer verificação de número
            } while (Inscricao.Length != 6);

            do
            {
                Console.WriteLine("Informe a capacidade de pessoas que a AERONAVE comporta: ");
                Capacidade = int.Parse(Console.ReadLine());
            } while (Capacidade < 0 || Capacidade > 999);

            //No momento do cadastro não há nenhum assento ocupado
            //então será inciado com 0
            // Numérico – Quantidade de assentos já vendidos. 3 Dígitos Numéricos
            AssentosOcupados = 0;

            //A data de última venda não será declarada no momento do cadastro
            //pois será atribuida e lida como a data atual do sistema
            //O mesmo para DATA DE CADASTRO

            //A SITAÇÃO DO CADASTRO também não será atribuida porque todo cadastro
            //quando gerado já esta ativo, para mudá-lo para inativo
            //vá ao metodo de editar cadastro

        }

        public void EditarAeronave()
        {
            Console.WriteLine("Escolha entre as opções, o/os dados que deseja editar em seu cadastro: ");
            Console.WriteLine("1 - Editar CAPACIDADE cadastrada");
            Console.WriteLine("2 - Editar ASSENTOS OCUPADOS cadastrado");
            Console.WriteLine("3 - Editar ÚLTIMA VENDA cadastrada");
            Console.WriteLine("4 - Editar DATA DO CADASTRO cadastrada");
            Console.WriteLine("5 - Editar SITUAÇÃO DO CADASTRO");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine("Informe a CAPACIDADE correta da aeronave: ");
                    Capacidade = int.Parse(Console.ReadLine());
                    break;

                case 2:
                    Console.WriteLine("Informe a quantidade de ASSENTOS OCUPADOS correta: ");
                    AssentosOcupados = int.Parse(Console.ReadLine());
                    break;

                case 3:
                    Console.WriteLine("Informe a DATA correta da ÚLTIMA VENDA: ");
                    UltimaVenda = DateTime.Parse(Console.ReadLine());
                    break;

                case 4:
                    Console.WriteLine("Informe a DATA DO CADASTRO correta: ");
                    DataCadastro = DateTime.Parse(Console.ReadLine());
                    break;

                case 5:
                    do
                    {
                        Console.WriteLine("Informe a SITUAÇÃO do cadastro correta (A - Ativo, I - Inativo): ");
                        Situacao = char.Parse(Console.ReadLine());
                        //fazer um filtro no metodo de lista p nao imprimir
                    } while (Situacao != 'A' && Situacao != 'I');
                    break;

                default:
                    break;
            }

        }
        public override string ToString()
        {
            return ($"INSCRIÇÃO: {Inscricao}\nCAPACIDADE: {Capacidade} passageiros\nASSENTOS OCUPADOS: {AssentosOcupados}\nDATA DA ÚLTIMA VENDA: {UltimaVenda}\nDATA EM QUE O CADASTRO FOI REALIZADO: {DataCadastro}\nSITUAÇÃO DO CADASTRO (A - ATIVO, I - INATIVO): {Situacao}").ToString();
        }


    }
}
