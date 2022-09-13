using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Passageiro
    {
        public String CPF { get; set; } //prop CHAVE com 11 dígitos
        public String Nome { get; set; } // < 50 digitos
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; } //M F N
        public DateTime UltimaCompra { get; set; } //no cadastro, data atual
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; } //A - Ativo I - Inativo

        public Passageiro()
        {
            UltimaCompra = DateTime.Now; //data atual do sistema
            DataCadastro = DateTime.Now; //data atual do sistema
            Situacao = 'A';
        }
        public Passageiro(string cpf, string nome, DateTime dataNascimento, char sexo, DateTime ultimaCompra, DateTime dataCadastro, char situacao)
        {
            CPF = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }
        public void CadastrarPassageiro()
        {
            Console.WriteLine(">>>CADASTRO DE PASSAGEIRO<<<");
            do
            {
                Console.WriteLine("Informe o número de seu Cadastro de Pessoas Físicas (CPF) sem caracteres especiais: ");
                CPF = Console.ReadLine();
                if (ValidarCpf(CPF) == false)
                {
                    Console.WriteLine("NÚMERO DO CPF INVÁLIDO!");
                    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA INFORMAR NOVAMENTE!");
                    Console.ReadKey();
                }

            } while (ValidarCpf(CPF) == false);
            do
            {
                Console.WriteLine("Informe o seu nome (Máximo 50 digítos): ");
                Nome = Console.ReadLine();
                if (Nome.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Nome.Length > 50);

            //Fazer o tratamento de possíveis erros
            Console.WriteLine("Informe sua Data de Nascimento: ");
            DataNascimento = DateTime.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Informe seu genero: (M - Masculino, F - Feminino, N - Não desejo informar) : ");
                Sexo = char.Parse(Console.ReadLine().ToUpper());
                if (Sexo != 'M' && Sexo != 'F' && Sexo != 'N')
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA! INFORME (M, F OU N) ");
                }
            } while (Sexo != 'M' && Sexo != 'F' && Sexo != 'N');

            //A data de última compra já foi declarada no método construtor
            //Não há necessidade de ler as informações novamente
            //Data de cadastro e situação também já foram declaradas.                  

        }

        public static bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            //Formatando para deixar o CPF somente com os números, sem caracteres especiais
            cpf = cpf.ToLower().Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            cpf = cpf.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            cpf = cpf.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            cpf = cpf.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            cpf = cpf.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            cpf = cpf.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            cpf = cpf.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");


            //Se o CPF for informado vazio
            if (cpf.Length == 0)
                return false;

            //Se a quantidade de dígitos for diferente do permitido (11)
            if (cpf.Length != 11)
                return false;

            //Se os números informados forem todos iguais
            switch (cpf)
            {

                case "00000000000":

                    return false;

                case "11111111111":

                    return false;

                case "22222222222":

                    return false;

                case "33333333333":

                    return false;

                case "44444444444":

                    return false;

                case "55555555555":

                    return false;

                case "66666666666":

                    return false;

                case "77777777777":

                    return false;

                case "88888888888":

                    return false;

                case "99999999999":

                    return false;
            }

            tempCpf = cpf.Substring(0, 9);

            //Calculo para gerar um número de CPF válido
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        public void EditarPassageiro()
        {

            Console.WriteLine("Escolha entre as opções, o/os dados que deseja editar em seu cadastro: ");
            Console.WriteLine("1 - Editar NOME cadastrado");
            Console.WriteLine("2 - Editar DATA DE NASCIMENTO cadastrado");
            Console.WriteLine("3 - Editar SEXO cadastrado");
            Console.WriteLine("4 - Editar ÚLTIMA COMPRA cadastrada");
            Console.WriteLine("5 - Editar DATA DO CADASTRO");
            Console.WriteLine("6 - Editar SITUAÇÃO do CADASTRO ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine("Informe o NOME correto: ");
                    Nome = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Informe a DATA DE NASCIMENTO correta: ");
                    DataNascimento = DateTime.Parse(Console.ReadLine());

                    break;

                case 3:
                    Console.WriteLine("Informe o gênero correto (M- Masculino, F - Feminino, N - Não desejo informar) : ");
                    Sexo = char.Parse(Console.ReadLine());
                    break;

                case 4:
                    Console.WriteLine("Informe a DATA correta da ÚLTIMA COMPRA: ");
                    UltimaCompra = DateTime.Parse(Console.ReadLine());
                    break;

                case 5:
                    Console.WriteLine("Informe a DATA DO CADASTRO correta: ");
                    DataCadastro = DateTime.Parse(Console.ReadLine());
                    break;

                case 6:
                    do
                    {
                        Console.WriteLine("Informe a SITUAÇÃO do cadastro correta (A - Ativo, I - Inativo): ");
                        Situacao = char.Parse(Console.ReadLine());

                    } while (Situacao != 'A' && Situacao != 'I');
                    break;

                default:
                    break;
            }
        }
        public override string ToString()
        {
            return ($"CPF: {CPF}\nNOME: {Nome}\nDATA DE NASCIMENTO: {DataNascimento}\nSEXO: {Sexo}\nÚLTIMA COMPRA: {UltimaCompra}\nDATA EM QUE O CADASTRO FOI REALIZADO: {DataCadastro}\nSITUAÇÃO DO CADASTRO (A - ATIVO, I - INATIVO): {Situacao}").ToString();
        }

    }
}


