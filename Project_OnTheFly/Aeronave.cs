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
        public CompanhiaAerea CompanhiaAerea { get; set; }

        public Aeronave()
        {
            DataCadastro = DateTime.Now;
            UltimaVenda = DateTime.Now;
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
        public String SufixoAeronave()
        {
            string sufixo;
            bool aux;
            do
            {
                Console.Write("Informe as 3 últimas letras da inscrição da aeroave: ");
                sufixo = Console.ReadLine();
                aux = VerificarSufixo(sufixo);
                if (!aux) Console.WriteLine("SUFIXO INVÁLIDO");
            } while (sufixo.Length != 3 || !aux);
            return sufixo.ToUpper();
        }
        public bool VerificarSufixo(String sufixo)
        {
            for (int i = 0; i < 3; i++)
            {
                char aux = sufixo[i];
                if (Char.IsLetter(aux)) ;
                else return false;
            }
            return true;
        }
        public String SelecionarPrefixo()
        {
            int prefixo;
            do
            {
                Console.WriteLine("Informe o prefixo da aeronave\n1 - PP\n2 - PT\n3 - PR\n4 - PS\n5 - BR\n0 - Sair");
                int.TryParse(Console.ReadLine(), out prefixo);
                switch (prefixo)
                {
                    case 1:
                        return "PP";
                        break;
                    case 2:
                        return "PT";
                        break;
                    case 3:
                        return "PR";
                        break;
                    case 4:
                        return "PS";
                        break;
                    case 5:
                        return "BR";
                        break;
                    default:
                        Console.WriteLine("PREFIXO INVÁLIDO");
                        break;
                }
            } while (prefixo != 0);
            return "0";
        }
        public bool VerificarAeronaveCadastrada(string inscricao, List<Aeronave> listaAeronaves)
        {
            foreach (var item in listaAeronaves)
            {
                if (item.Inscricao == inscricao) return false;
            }
            return true;
        }
        public void CadastroAeronave(List<CompanhiaAerea> ListaCompanhiaAereas, List<Aeronave> listaAeronaves)
        {
            Console.WriteLine(">>>CADASTRO DE AERONAVE<<<");
            do
            {
                string prefixo = SelecionarPrefixo();
                if (prefixo == "0")
                {
                    Console.WriteLine("CADASTRAMENTO CANCELADO!!!\nPressione Enter para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                Inscricao = prefixo + "-" + SufixoAeronave();

                if (!VerificarAeronaveCadastrada(Inscricao, listaAeronaves)) Console.WriteLine("AERONAVE JÁ CADASTRADA");

            } while (!VerificarAeronaveCadastrada(Inscricao, listaAeronaves));

            do
            {
                Console.WriteLine("Informe a capacidade de pessoas que a AERONAVE comporta: ");
                Capacidade = int.Parse(Console.ReadLine());
            } while (Capacidade < 0 || Capacidade > 999);

            AssentosOcupados = 0;

            //Lista de Companhias
            Console.WriteLine("Lista de Companhias Aéreas:");
            foreach (CompanhiaAerea item in ListaCompanhiaAereas)
            {
                if (item.SituacaoCA == 'A')
                    Console.WriteLine(item.ToString());
            }

            Console.Write("Informe qual Companhia Aérea a Aeronave Pertence: ");
            string ca = Console.ReadLine();

            foreach (CompanhiaAerea item in ListaCompanhiaAereas)
            {
                if (item.SituacaoCA == 'A')
                {
                    if (item.CNPJ == ca)
                        this.CompanhiaAerea = item;
                }
            }
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
