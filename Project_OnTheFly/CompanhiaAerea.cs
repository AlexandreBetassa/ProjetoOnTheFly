using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class CompanhiaAerea
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimoVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char SituacaoCA { get; set; }

        public CompanhiaAerea()
        {

        }

        public CompanhiaAerea(string cnpj, string razaoSocial, DateTime dataAbertura, DateTime ultimoVoo, DateTime dataCadastro, char situacaoCA)
        {
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
            UltimoVoo = ultimoVoo;
            DataCadastro = dataCadastro;
            SituacaoCA = situacaoCA;
        }
              
        public void CadCompAerea()
        {
            Console.WriteLine("CADASTRO DE COMPANHIA AEREA");

            do
            {
                Console.WriteLine("\nInforme o seu Cadastro Nacional da Pessoa Jurídica - CNPJ:  ");
                CNPJ = Console.ReadLine();
                if (ValidarCnpj(CNPJ) == false)
                {
                    Console.WriteLine("\nNÚMERO DE CNPJ INVÁLIDO.");
                    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA INFORMAR NOVAMENTE!");
                    Console.ReadKey();
                }
            } while (ValidarCnpj(CNPJ) == false);

            do
            {
                Console.WriteLine("\nInforme o nome da Razão Social (máximo 50 dígitos):  ");
                RazaoSocial = Console.ReadLine();

                if (RazaoSocial.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR.\nTENTE NOVAMENTE!");
                }
            } while (RazaoSocial.Length > 50);

            //inserir ultimo voo

            TimeSpan result;
            do
            {
                //ValidarData(DataAbertura);

                Console.WriteLine("\nInforme a data de abertura: ");
                DataAbertura = DateTime.Parse(Console.ReadLine());

                result = DateTime.Now - DataAbertura;

                if (result.Days / 30 < 6)
                {
                    Console.WriteLine($"\nA companhia tem {result.Days / 30} meses");
                    Console.WriteLine("\nO tempo é insufiente para finalizar o cadastro.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                

            } while (result.Days / 30 < 6);

            //data do cadastro
            Console.WriteLine($"A data do seu cadastro: {DataCadastro.ToShortDateString()}");

        }

        public void EditarCompAerea(string cnpj, string razaoSocial, DateTime dataAbertura, DateTime ultimoVoo)
        {
            CompanhiaAerea companhia = new();
            Console.WriteLine("Escolha o dado que você deseja editar: ");
            Console.WriteLine("1 - Editar CNPJ");
            Console.WriteLine("2 - Editar RAZÃO SOCIAL");
            Console.WriteLine("3 - Editar DATA DE ABERTURA");
            Console.WriteLine("4 - Editar ÚLTIMO VOO");
           // Console.WriteLine("5 - Editar NOVA DATA CADASTRO (ALTERAÇÃO)");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.WriteLine("Informe o CNPJ correto: ");
                    cnpj = Console.ReadLine();
                    companhia.CNPJ = cnpj;
                    break;

                case 2:
                    Console.WriteLine("Informe a RAZÃO SOCIAL correta: ");
                    razaoSocial = Console.ReadLine();
                    companhia.RazaoSocial = razaoSocial;
                    break;

                case 3:
                    Console.WriteLine("Informe a DATA DE ABERTURA correta: ");
                    dataAbertura = DateTime.Parse(Console.ReadLine());
                    companhia.DataAbertura = dataAbertura;
                    break;

                case 4:
                    Console.WriteLine("Informe a DATA DO ÚLTIMO VOO correta: ");
                    ultimoVoo = DateTime.Parse(Console.ReadLine());
                    companhia.UltimoVoo = ultimoVoo;
                    break;

                //case 5:
                   // Console.WriteLine("Informe a DATA DO CADASTRO ALTERADO: ");
                    //dataCadastro = Console.ReadLine();
                    //companhia.DataCadastro = dataCadastro;
                    //break;
            }
        }

        public override string ToString()
        {
            return "\nCNPJ: " + CNPJ + "\nRazão Social: " + RazaoSocial + "\nData de Abertura: " + DataAbertura + "\nÚltimo Voo: " + UltimoVoo + "\nData de Cadastro: " + DataCadastro + "\nSituação: " + SituacaoCA;
        }

        //método para validar cnpj
        public static bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;
            string digito, tempCnpj;

            //limpa caracteres especiais e deixa em minusculo
            cnpj = cnpj.ToLower().Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            cnpj = cnpj.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            cnpj = cnpj.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            cnpj = cnpj.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            cnpj = cnpj.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            cnpj = cnpj.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            cnpj = cnpj.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");

            // Se vazio
            if (cnpj.Length == 0)
                return false;

            //Se o tamanho for < 14 então retorna como falso
            if (cnpj.Length != 14)
                return false;

            // Caso coloque todos os numeros iguais
            switch (cnpj)
            {

                case "00000000000000":

                    return false;

                case "11111111111111":

                    return false;

                case "22222222222222":

                    return false;

                case "33333333333333":

                    return false;

                case "44444444444444":

                    return false;

                case "55555555555555":

                    return false;

                case "66666666666666":

                    return false;

                case "77777777777777":

                    return false;

                case "88888888888888":

                    return false;

                case "99999999999999":

                    return false;
            }

            tempCnpj = cnpj.Substring(0, 12);

            //cnpj é gerado a partir de uma função matemática, logo para validar, sempre irá utilizar esse calculo 
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);

        }

        //teste para validar tempo de abertura
        /*
        private static void ValidarData(DateTime dataAbertura)
        {
            TimeSpan result;
            
            Console.WriteLine("\nInforme a data de abertura: ");
            dataAbertura = DateTime.Parse(Console.ReadLine());
            result = DateTime.Now - dataAbertura;

            if(result.Days/30 < 6)
            {
                Console.WriteLine($"\nA companhia tem {result.Days / 30} meses");
                Console.WriteLine("\nO tempo é insufiente para finalizar o cadastro.");
            }
            

            
            Console.WriteLine("\nInforme a data de abertura: ");
            dataAbertura = DateTime.Parse(Console.ReadLine());

            result = DateTime.Now - dataAbertura;

            if (result.Days / 30 < 6)
            {
                Console.WriteLine($"\nA companhia tem {result.Days / 30} meses");
                Console.WriteLine("\nO tempo é insufiente para finalizar o cadastro.");
            }
            
            do
            {
                Console.WriteLine("\nInforme a data de abertura: ");
                dataAbertura = DateTime.Parse(Console.ReadLine());

                result = DateTime.Now - dataAbertura;

                if (result.Days/30 < 6)
                {
                    Console.WriteLine($"\nA companhia tem {result.Days / 30} meses");
                    Console.WriteLine("\nO tempo é insufiente para finalizar o cadastro.");
                }
                else
                {
                    return; 
                }

            } while (result.Days/30 < 6);
            
        }
            */
    }
}
