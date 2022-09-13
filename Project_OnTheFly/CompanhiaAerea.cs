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
            UltimoVoo = DateTime.Now;
            DataCadastro = DateTime.Now;
            SituacaoCA = situacaoCA; //A Ativo ou I Inativo
        }

        public void CadCompAerea()
        {
            bool aux;
            DateTime aux1;

            Console.WriteLine("CADASTRO DE COMPANHIA AEREA");

            //CNPJ
            do
            {
                Console.Write("\nInforme o seu Cadastro Nacional da Pessoa Jurídica - CNPJ:  ");
                CNPJ = Console.ReadLine();
                if (ValidarCnpj(CNPJ) == false)
                {
                    Console.WriteLine("\nNÚMERO DE CNPJ INVÁLIDO.");
                    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA INFORMAR NOVAMENTE!");
                    Console.ReadKey();
                }
            } while (ValidarCnpj(CNPJ) == false);

            //Razão Social
            do
            {
                Console.Write("\nInforme o nome da Razão Social (máximo 50 dígitos):  ");
                RazaoSocial = Console.ReadLine();

                if (RazaoSocial.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR.\nTENTE NOVAMENTE!");
                }
            } while (RazaoSocial.Length > 50);

            //Inserir ultimo voo. no momento do cadastro poderá ser usado a data atual
            do
            {
                Console.Write("Informe a Data do Último voo: ");
                aux = DateTime.TryParse(Console.ReadLine(), out aux1);
            } while (!aux);
            UltimoVoo = aux1;

            //Data de abertura
            TimeSpan result;
            do
            {
                Console.Write("\nInforme a data de abertura: (mês/dia/ano)");
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

            //Data do cadastro
            do
            {
                Console.Write("Informe a Data de Cadastro: ");
                aux = DateTime.TryParse(Console.ReadLine(), out aux1);
            } while (!aux);

            DataCadastro = aux1;

            SituacaoCA = char.Parse(Console.ReadLine());

        }

        public void EditarCompAerea()
        {
            CompanhiaAerea companhia = new();
            Console.Write("Escolha o dado que você deseja editar: ");
            Console.Write("1 - Editar CNPJ");
            Console.Write("2 - Editar RAZÃO SOCIAL");
            Console.Write("3 - Editar DATA DE ABERTURA");
            Console.Write("4 - Editar ÚLTIMO VOO");
            Console.Write("5 - Editar NOVA DATA CADASTRO (ALTERAÇÃO)");
            Console.WriteLine("0 - SAIR");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Write("Informe o CNPJ correto: ");
                    string cnpj = Console.ReadLine();
                    companhia.CNPJ = cnpj;
                    break;

                case 2:
                    Console.Write("Informe a RAZÃO SOCIAL correta: ");
                    string razaoSocial = Console.ReadLine();
                    companhia.RazaoSocial = razaoSocial;
                    break;

                case 3:
                    Console.Write("Informe a DATA DE ABERTURA correta: ");
                    DateTime dataAbertura = DateTime.Parse(Console.ReadLine());
                    companhia.DataAbertura = dataAbertura;
                    break;

                case 4:
                    Console.Write("Informe a DATA DO ÚLTIMO VOO correta: ");
                    DateTime ultimoVoo = DateTime.Parse(Console.ReadLine());
                    companhia.UltimoVoo = ultimoVoo;
                    break;

                case 5:
                    do
                    {
                        Console.WriteLine("Informe a SITUAÇÃO do cadastro correta (A - Ativo, I - Inativo): ");
                        char situacao = char.Parse(Console.ReadLine());
                        companhia.SituacaoCA = situacao;
                    } while (SituacaoCA != 'A' && SituacaoCA != 'I');
                    break;

                case 0:
                    break;
            }
        }

        public void EditarCompanhia()
        {

        }

        public override string ToString()
        {
            return "\nCNPJ: " + CNPJ + "\nRazão Social: " + RazaoSocial + "\nData de Abertura: " + DataAbertura + "\nÚltimo Voo: " + UltimoVoo + "\nData de Cadastro: " + DataCadastro + "\nSituação: " + SituacaoCA;
        }

        #region Validar cnpj
        public static bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;
            string digito, tempCnpj;

            //limpa caracteres especiais e deixa em minusculo
            cnpj = cnpj.ToLower().Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            //cnpj = cnpj.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            //cnpj = cnpj.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            //cnpj = cnpj.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            //cnpj = cnpj.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            //cnpj = cnpj.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            //cnpj = cnpj.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");

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
        #endregion Validar cnpj
        /*
        #region Data de Abertura
        public bool CadDataAbertura()
        {
            Console.Write("Digite a Data de Abertura da empresa (Mês/Dia/Ano): ");
            DateTime dataAbertura;
            while (!DateTime.TryParse(Console.ReadLine(), out dataAbertura))
            {
                Console.WriteLine("Formato de data incorreto!");
                Console.Write("Digite a data de abertura da empresa corretamente (Mês/Dia/Ano): ");
            }
            DateTime verData = dataAbertura;
            if (verData > DateTime.Now.AddMonths(-6))
            {
                Console.WriteLine("Não é possível cadastrar empresas com menos de 6 meses!");
                return false;
            }
            DataAbertura = dataAbertura.ToString("ddMMyyyy");
            if (DataAbertura == "0")
                return false;
            return true;

        colocar dentro de cadastrar 
        if (!CadDataAbertura())
                return;
        }
        */

    }
}
