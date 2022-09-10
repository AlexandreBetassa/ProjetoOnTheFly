using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.IO;
using System.Text;
=======
>>>>>>> origin/felipe

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
            Console.WriteLine("0 - Sair do Menu Principal");
            return opc = int.Parse(Console.ReadLine());
        }

        #region ManterPassageiro
        public static Passageiro AdicionarPassageiro()
        {
            Passageiro passageiro = new Passageiro();

            passageiro.CadastrarPassageiro();

            return passageiro;
        }
        public static void EditarPassageiro(List<Passageiro> listaPassageiros)
        {
            Passageiro passageiro = BuscarPassageiro(listaPassageiros);

            if (passageiro != null)
            {
                passageiro.EditarPassageiro();
            }
        }
        public static Passageiro BuscarPassageiro(List<Passageiro> listaPassageiros)
        {
            bool achei = false;

            Console.Write("Informe o CPF do Passageiro para busca: ");
            string cpf = Console.ReadLine();
            Passageiro passageiro = new Passageiro();

            foreach (Pasageiro item in listaPassageiros)
            {
                if (item.Cpf == cpf)
                {
                    achei = true;
                    passageiro = item;
                    return passageiro;
                }
            }

            if (achei = false)
            {
                Console.WriteLine("Não foi encontrado nenhum passageiro com este CPF!");
            }
            return null;
        }
        #endregion

        static void Main(string[] args)
        {
<<<<<<< HEAD
            //List<String> listaIatas = new List<string>();
            //LerArquivoIatas(listaIatas);
            GravarArquivoPassageiro();


=======
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
                        Console.WriteLine("2 - Buscar passageiro");
                        Console.WriteLine("3 - Editar Passageiro");
                        Console.WriteLine("4 - Listar Passageiros");
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
                                    passageiro = BuscarPassageiro(listaPassageiros);
                                    Console.WriteLine(passageiro.ToString());
                                    break;
                                case 3:
                                    EditarPassageiro(listaPassageiros);
                                    break;
                                case 4:
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
                        } while (opc != 0);
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
                        Environment.Exit(0);
                        break;
                }
            } while (true);
>>>>>>> origin/felipe
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

>>>>>>> origin/felipe
