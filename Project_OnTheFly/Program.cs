using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.IO;
using System.Text;
>>>>>>> Alexandre

namespace Project_OnTheFly
{
    internal class Program
    {
        public static int Menu()
        {
            int opc;

            Console.WriteLine("1 - Menu de Passageiros");
            Console.WriteLine("2 - Menu de Companhias Aéreas ");
            Console.WriteLine("3 - Menu de Aeronaves");
            Console.WriteLine("4 - Menu de Passagens ");
            Console.WriteLine("5 - Menu de Vendas ");
            return opc = int.Parse(Console.ReadLine());
        }

        public static Passageiro AdicionarPassageiro()
        {
            Passageiro passageiro = new Passageiro();
        }

        static void Main(string[] args)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            int op = 0;
            List<Passageiro> listaPassageiros = new List<Passageiro>();
            Passageiro passageiro = new Passageiro();
            do
            {
                op = Menu();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("1 - Cadastrar Passageiro");
                        Console.WriteLine("2 - Editar Passageiro");
                        Console.WriteLine("3 - Listar Passageiros");
                        Console.WriteLine("0 - Sair do Menu de Passageiros");
                        int opc = int.Parse(Console.ReadLine());
                        do
                        {
                            switch (opc)
                            {
                                case 1:
                                    passageiro = AdicionarPassageiro();
                                    listaPassageiros.Add(passageiro);
                                    break;
                                case 2:
                                    passageiro.EditarPassageiro(listaPassageiros);
                                    break;
                                case 3:
                                    foreach (Passageiro item in listaPassageiros)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("Você saiu do Menu de Passageiros!");
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                                    break;
                            }
                        } while (op != 0);

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 0:
                        break;
                }
            } while (true);
=======
            CompanhiaAerea comp = new();
            comp.CadCompAerea();
>>>>>>> DevThalya
=======
            //List<String> listaIatas = new List<string>();
            //LerArquivoIatas(listaIatas);
            GravarArquivoPassageiro();


>>>>>>> Alexandre
        }

        #region Iatas
        //metod para recuperação daa lista de iatas
        static void LerArquivoIatas(List<String> lista)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\listaIatas.dat");//Instancia um Objeto StreamReader (Classe de Manipulação de Leitura de Arquivos)
                line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    lista.Add(line);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha no carregamento do arquivo de Iatas\n " + e.Message);
            }
            finally
            {
                Console.WriteLine("Arquivos carregados com êxito!!!");
            }
            Console.ReadKey();
            Console.Clear();
            return;
        }

        static void ImprimirDestinos(List<String> lista)
        {
            Console.WriteLine("### LISTA DESTINOS ###");
            foreach (var item in lista) if (item != null) Console.WriteLine(item);
        }

        static String LocalizarIata(List<String> lista)
        {
            Console.WriteLine("Informe a iata do aeroporto destino: ");
            string iata = Console.ReadLine().ToUpper();
            foreach (var item in lista)
                if (item.Contains(iata) && item != null)
                {
                    Console.WriteLine(item);
                    return item;
                }
            return null;
        }
        #endregion Iatas

        #region gravarArquivos
        static void GravarArquivoPassageiro(/*List<Passageiro> listaPassageiros*/)
        {
            try
            {
                StreamWriter passageiro = new StreamWriter("C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\Passageiros.dat");
                //foreach (Passageiro passageiro in listaPassageiros) if (passageiro != null) passageiro.WriteLine(pessoa.getPassageiro);
                passageiro.WriteLine(getPassageiro());
                passageiro.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao gravar o arquivo Passageiros\n" + e.Message);
            }
            finally
            {
                Console.WriteLine("Gravação efetuada com sucesso!!!");
            }
        }


        static String getPassageiro()
        {
            String nome = "alexandre";
            int idade = 27;
            
            String Complete(String nome)
            {
            var n = new StringBuilder(50);

                for (int i = nome.Length; i < 50; i++) n[i] = ' ';
                return n.ToString();
            }

            return $"{nome}{Complete(nome)}{idade}";
        }

        #endregion greavararquivos



    }
<<<<<<< HEAD
}

=======
}
>>>>>>> Alexandre
