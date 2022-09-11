using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project_OnTheFly
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Passageiro> listaPassageiros = new List<Passageiro>();
            List<String> listaIatas = new List<string>();
            List<CompanhiaAerea> ListaCompanhiaAereas = new List<CompanhiaAerea>();

            LerArquivoIatas(listaIatas);
            LerArquivoPassageiros(listaPassageiros);
            LerArquivoCompanhiaAerea(ListaCompanhiaAereas);
            foreach (var item in ListaCompanhiaAereas) Console.WriteLine(item + "\n");

            int op = 0;
            do
            {
                op = Menu();
                switch (op)
                {
                    case 1:
                        MenuPassageiro(listaPassageiros);
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
                        GravarArquivoPassageiro(listaPassageiros);
                        GravarArquivoCompanhiaAerea(ListaCompanhiaAereas);
                        Environment.Exit(0);
                        break;
                }
            } while (true);

        }

        public void metodoteste() { }

        #region Menus
        public static void MenuPassageiro(List<Passageiro> listaPassageiros)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Passageiro");
                Console.WriteLine("2 - Buscar passageiro");
                Console.WriteLine("3 - Editar Passageiro");
                Console.WriteLine("4 - Listar Passageiros");
                Console.WriteLine("0 - Sair do Menu de Passageiros");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaPassageiros.Add(AdicionarPassageiro());
                        break;
                    case 2:
                        Console.WriteLine(BuscarPassageiro(listaPassageiros).ToString());
                        break;
                    case 3:
                        EditarPassageiro(listaPassageiros);
                        break;
                    case 4:
                        foreach (Passageiro item in listaPassageiros)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Passageiros!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }

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

        #endregion Menus

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

            foreach (Passageiro item in listaPassageiros)
            {
                if (item.Cpf == cpf)
                {
                    achei = true;
                    passageiro = item;
                    return passageiro;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhum passageiro com este CPF!");
            }
            return null;
        }
        #endregion

        #region gravarArquivos
        #region ArquivoPassageiro
        //metodo de gravacao do arquivo passageiros
        static void GravarArquivoPassageiro(List<Passageiro> listaPassageiros)
        {
            try
            {
                StreamWriter passageiro = new StreamWriter($"C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\Passageiro.dat");
                foreach (Passageiro item in listaPassageiros)
                {
                    if (item != null)
                        passageiro.WriteLine(getPassageiro(item));
                }
                passageiro.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao gravar o arquivo Passageiros\n" + e.Message);
            }
            finally
            {
                Console.WriteLine("Gravação arquivo Passageiros.dat efetuada com sucesso!!!");
            }
        }

        //metodo para retornar passageiro como texto para efetuar gravacao em arquivo
        static String getPassageiro(Passageiro passageiro)
        {
            return $"{passageiro.Cpf}{passageiro.Nome.PadRight(50)}{FormatarData(passageiro.DataNascimento)}{passageiro.Sexo}{FormatarData(passageiro.UltimaCompra)}{FormatarData(passageiro.DataCadastro)}";
        }

        //metodo de leitura do arquivo de passageiros
        static void LerArquivoPassageiros(List<Passageiro> listaPassageiro)
        {
            String line;

            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\Passageiros.dat");
                line = sr.ReadLine();

                do
                {
                    Passageiro passageiro = new Passageiro();
                    passageiro.Cpf = line.Substring(0, 11);
                    passageiro.Nome = line.Substring(11, 50);
                    passageiro.DataNascimento = DateTime.Parse($"{line[61]}{line[62]}/{line[63]}{line[64]}/{line[65]}{line[66]}{line[67]}{line[68]}");
                    passageiro.Sexo = line[69];
                    passageiro.UltimaCompra = DateTime.Parse($"{line[70]}{line[71]}/{line[72]}{line[73]}/{line[74]}{line[75]}{line[76]}{line[77]}");
                    listaPassageiro.Add(passageiro);
                    line = sr.ReadLine();
                } while (line != null);

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha no carregamento do arquivo de Passageiros\n " + e.Message);
            }
            finally
            {
                Console.WriteLine("Arquivo Passageiros carregado com êxito!!!");
            }
            Console.ReadKey();
            Console.Clear();
            return;
        }
        #endregion ArquivoPassageiro

        #region ArquivoIatas
        //metod para recuperação da lista de iatas
        static void LerArquivoIatas(List<String> lista)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\listaIatas.dat");
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
                Console.WriteLine("Falha no carregamento do arquivo listaIatas\n " + e.Message);
            }
            finally
            {
                Console.WriteLine("Arquivo listaIatas carregados com êxito!!!");
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
        #endregion ArquivoIatas

        #region ArquivoCompanhiaAerea
        //metodo de gravacao do arquivo passageiros
        static void GravarArquivoCompanhiaAerea(List<CompanhiaAerea> listaCompanhias)
        {
            try
            {
                StreamWriter ArqCompanhia = new StreamWriter($"C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\CompanhiaAerea.dat");
                foreach (var item in listaCompanhias)
                {
                    if (item != null)
                        ArqCompanhia.WriteLine(getCompanhiaAerea(item));
                }
                ArqCompanhia.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao gravar o arquivo CompanhiaAerea\n" + e.Message);
            }
            finally
            {
                Console.WriteLine("Gravação arquivo CompanhiaAerea.dat efetuada com sucesso!!!");
            }
        }

        //metodo para retornar companhia aerea para gravacao
        static String getCompanhiaAerea(CompanhiaAerea companhia)
        {
            return $"{companhia.CNPJ}{companhia.RazaoSocial.PadRight(50)}{FormatarData(companhia.DataAbertura)}{FormatarData(companhia.UltimoVoo)}{FormatarData(companhia.DataCadastro)}{companhia.SituacaoCA}";
        }

        //metodo para recuperação do arquivo CompanhiaAerea
        static void LerArquivoCompanhiaAerea(List<CompanhiaAerea> listaCompanhias)
        {
            string line;

            StreamReader companhiaTxt = new StreamReader($"C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\CompanhiaAerea.dat");
            line = companhiaTxt.ReadLine();
            do
            {
                try
                {
                    Console.WriteLine(line.Length);
                    CompanhiaAerea companhia = new CompanhiaAerea();
                    companhia.CNPJ = line.Substring(0, 14);
                    companhia.RazaoSocial = line.Substring(14, 51);
                    companhia.DataAbertura = DateTime.Parse($"{line[64]}{line[65]}/{line[66]}{line[67]}/{line[68]}{line[69]}{line[70]}{line[71]}");
                    companhia.UltimoVoo = DateTime.Parse($"{line[72]}{line[73]}/{line[74]}{line[75]}/{line[76]}{line[77]}{line[78]}{line[79]}");
                    companhia.DataCadastro = DateTime.Parse($"{line[80]}{line[81]}/{line[82]}{line[83]}/{line[84]}{line[85]}{line[86]}{line[87]}");
                    companhia.SituacaoCA = line[88];
                    listaCompanhias.Add(companhia);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Falha no carregamento do arquivo de CompanhiaAerea.dat\n " + e.Message);

                }
                finally
                {
                    Console.WriteLine("Arquivo Passageiros carregado com êxito!!!");
                }
                line = companhiaTxt.ReadLine();
            } while (line != null);
        }
        #endregion ArquivoCompanhiaAerea

        //formatar data sem barras, somente numeros 
        static String FormatarData(DateTime data)
        {
            return data.ToString("ddMMyyyy");
        }
        #endregion gravararquivos

    }
}


