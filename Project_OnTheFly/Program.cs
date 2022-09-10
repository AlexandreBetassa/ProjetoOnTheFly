using System;
using System.Collections.Generic;

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
        }
    }
}

