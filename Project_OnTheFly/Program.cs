using System;
using System.Collections.Generic;
using System.IO;

namespace Project_OnTheFly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> listaIatas = new List<string>();
            LerArquivo(listaIatas);
            Console.WriteLine("Imprimir lista de iatas ");
            foreach (var item in listaIatas) Console.WriteLine(item);
            Console.ReadKey();


        }

        static void LerArquivo(List<String> lista)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Alexandre\\Desktop\\Aulas\\Aeroporto\\Project_OnTheFly\\Project_OnTheFly\\listaIatas.txt");//Instancia um Objeto StreamReader (Classe de Manipulação de Leitura de Arquivos)
                line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    lista.Add(line);
                }
                sr.Close();
                Console.WriteLine("Fim da Leitura do Arquivo");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comando - Sem Erros");
            }
            Console.ReadKey();
            Console.Clear();
            return;
        }
    }
}