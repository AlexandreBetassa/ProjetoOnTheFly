using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Passageiro
    {
        public String Cpf { get; set; } //prop chave com 11 dígitos
        public String Nome { get; set; } // < 50 digitos
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; } //M F N
        public DateTime UltimaCompra { get; set; } //no cadastro, data atual
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; } //A - Ativo I - Inativo

        public Passageiro()
        {

        }
        public Passageiro(string cpf, string nome, DateTime dataNascimento, char sexo, DateTime ultimaCompra, DateTime dataCadastro, char situacao)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            UltimaCompra = ultimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public char GetSexo()
        {
            return Sexo;
        }

        public void CadastrarPassageiro()
        {
            bool aux;

            Console.WriteLine(">>>CADASTRO DE PASSAGEIRO<<<");
            do
            {
                Console.WriteLine("Informe o número de seu Cadastro de Pessoas Físicas (CPF) : ");
                Cpf = Console.ReadLine().ToUpper();
                if (!ValidarCpf(Cpf))
                {
                    Console.WriteLine("NÚMERO DO CPF INVÁLIDO!");
                    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA INFORMAR NOVAMENTE!");
                    Console.ReadKey();
                }
            } while (!ValidarCpf(Cpf));

            do
            {
                Console.WriteLine("Informe o seu nome (Máximo 50 digítos) : ");
                Nome = Console.ReadLine();
                if (Nome.Length > 50) Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");
            } while (Nome.Length > 50 || String.IsNullOrWhiteSpace(Nome));

            //Fazer o tratamento de possíveis erros
            Console.WriteLine("Informe sua Data de Nascimento: ");
            DataNascimento = DateTime.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Informe seu genero: (M - Masculino, F - Feminino, N - Não desejo informar) : ");
                Sexo = Char.Parse(Console.ReadLine().ToUpper());
            } while (Sexo != 'M' && Sexo != 'F' && Sexo != 'N');

            Console.WriteLine("Informe a Data de sua última compra");
            Console.WriteLine("Caso nunca tenha comprado uma passagem antes, informe a data ATUAL: ");
            UltimaCompra = DateTime.Parse(Console.ReadLine());

            //Data ATUAL do sistema
            Console.WriteLine("Informe a Data de Cadastro: ");
            DataCadastro = DateTime.Parse(Console.ReadLine());

            //Situação, chamar um metodo p registrar a situação ?
            //Situação é A - Ativo e I - Inativo
        }
        public void MetodoTeste()
        {

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


        //Metodo para localizar um registro especifico, deixar aqui ou na Program?

        //Metodo para EDITAR as informações, desde que não seja o CPF, ?
        public void EditarPassageiro()
        {


        }


        public override string ToString()
        {
            return $"Nome: {Nome}\n{DataNascimento.ToShortDateString()}\n{DataCadastro.ToShortDateString()}n{Sexo}".ToString();
        }

    }
}


