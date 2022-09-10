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
            return opc = int.Parse(Console.ReadLine());
        }

        public static Passageiro AdicionarPassageiro()
        {
            Passageiro passageiro = new Passageiro();
        }

        static void Main(string[] args)
        {
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
        }
    }
}

