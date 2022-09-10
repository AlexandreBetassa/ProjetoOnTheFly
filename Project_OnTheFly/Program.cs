using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project_OnTheFly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<String> listaIatas = new List<string>();
            //LerArquivoIatas(listaIatas);
            GravarArquivoPassageiro();


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
}