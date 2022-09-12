using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
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
            List<Aeronave> listaAeronaves = new List<Aeronave>();
            List<Voo> listaVoos = new List<Voo>();
            List<Passagem> listaPassagens = new List<Passagem>();
            List<Venda> listaVendas = new List<Venda>();
            List<ItemVenda> listaItemVendas = new List<ItemVenda>();

            LerArquivoPassageiros(listaPassageiros);

            LerArquivoIatas(listaIatas);
            LerArquivoAeronave(listaAeronaves);
            LerArquivoCompanhiaAerea(ListaCompanhiaAereas);


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
                        MenuCompanhia(ListaCompanhiaAereas);
                        break;
                    case 3:
                        MenuAeronave(listaAeronaves);
                        break;
                    case 4:
                        MenuVoo(listaVoos, listaIatas);

                        break;
                    case 5:
                        MenuPassagem(listaPassagens);
                        break;
                    case 6:
                        MenuVenda(listaVendas);
                        break;
                    case 7:
                        MenuItemVenda(listaItemVendas);
                        break;
                    case 0:
                        GravarArquivoPassageiro(listaPassageiros);
                        GravarArquivoCompanhiaAerea(ListaCompanhiaAereas);
                        GravarArquivoAeronave(listaAeronaves);
                        Environment.Exit(0);
                        break;
                }
            } while (true);

        }

        #region Menus
        #region MenuPrincipal
        public static int Menu()
        {
            int opc;

            Console.WriteLine("1 - Menu de Passageiros");
            Console.WriteLine("2 - Menu de Companhias Aéreas ");
            Console.WriteLine("3 - Menu de Aeronaves");
            Console.WriteLine("4 - Menu de Voos");
            Console.WriteLine("5 - Menu de Passagens ");
            Console.WriteLine("6 - Menu de Vendas ");
            Console.WriteLine("7 - Menu de Item Vendas ");
            Console.WriteLine("0 - Sair do Menu Principal");
            return opc = int.Parse(Console.ReadLine());
        }
        #endregion
        #region MenuPassageiro
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
        #endregion
        #region MenuCompanhia
        public static void MenuCompanhia(List<CompanhiaAerea> listaCompanhiaAereas)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Companhia");
                Console.WriteLine("2 - Buscar Companhia");
                Console.WriteLine("3 - Editar Companhia");
                Console.WriteLine("4 - Listar Companhias");
                Console.WriteLine("0 - Sair do Menu de Companhias");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaCompanhiaAereas.Add(AdicionarCompanhia());
                        break;
                    case 2:
                        Console.WriteLine(BuscarCompanhia(listaCompanhiaAereas).ToString());
                        break;
                    case 3:
                        EditarCompanhia(listaCompanhiaAereas);
                        break;
                    case 4:
                        foreach (CompanhiaAerea item in listaCompanhiaAereas)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Companhias!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }
        #endregion
        #region MenuAeronave
        public static void MenuAeronave(List<Aeronave> listaAeronaves)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Aeronave");
                Console.WriteLine("2 - Buscar Aeronave");
                Console.WriteLine("3 - Editar Aeronave");
                Console.WriteLine("4 - Listar Aeronaves");
                Console.WriteLine("0 - Sair do Menu de Aeronaves");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaAeronaves.Add(AdicionarAeronave());
                        break;
                    case 2:
                        Console.WriteLine(BuscarAeronave(listaAeronaves).ToString());
                        break;
                    case 3:
                        EditarAeronave(listaAeronaves);
                        break;
                    case 4:
                        foreach (Aeronave item in listaAeronaves)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Aeronaves!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }
        #endregion
        #region MenuVoo
        public static void MenuVoo(List<Voo> listaVoos, List<string> listaIatas)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Voo");
                Console.WriteLine("2 - Buscar Voo");
                Console.WriteLine("3 - Editar Voo");
                Console.WriteLine("4 - Listar Voos");
                Console.WriteLine("0 - Sair do Menu de Voos");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaVoos.Add(AdicionarVoo(listaIatas));
                        break;
                    case 2:
                        Console.WriteLine(BuscarVoo(listaVoos).ToString());
                        break;
                    case 3:
                        EditarVoo(listaVoos);
                        break;
                    case 4:
                        foreach (Voo item in listaVoos)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Voos!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }
        #endregion
        #region MenuPassagem
        public static void MenuPassagem(List<Passagem> listaPassagens)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Passagem");
                Console.WriteLine("2 - Buscar Passagem");
                Console.WriteLine("3 - Editar Passagem");
                Console.WriteLine("4 - Listar Passagens");
                Console.WriteLine("0 - Sair do Menu de Passagems");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaPassagens.Add(AdicionarPassagem());
                        break;
                    case 2:
                        Console.WriteLine(BuscarPassagem(listaPassagens).ToString());
                        break;
                    case 3:
                        EditarPassagem(listaPassagens);
                        break;
                    case 4:
                        foreach (Passagem item in listaPassagens)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Passagens!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }
        #endregion
        #region MenuVenda
        public static void MenuVenda(List<Venda> listaVendas)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Venda");
                Console.WriteLine("2 - Buscar Venda");
                Console.WriteLine("3 - Listar Vendas");
                Console.WriteLine("0 - Sair do Menu de Vendas");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaVendas.Add(AdicionarVenda());
                        break;
                    case 2:
                        Console.WriteLine(BuscarVenda(listaVendas).ToString());
                        break;
                    case 3:
                        foreach (Venda item in listaVendas)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Vendas!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }
        #endregion
        #region MenuItemVenda
        public static void MenuItemVenda(List<ItemVenda> listaItemVendas)
        {
            do
            {
                Console.WriteLine("1 - Cadastrar Venda de Item");
                Console.WriteLine("2 - Buscar Venda de Item");
                Console.WriteLine("3 - Listar Vendas de Itens");
                Console.WriteLine("0 - Sair do Menu de Venda de Itens");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        listaItemVendas.Add(AdicionarItemVenda());
                        break;
                    case 2:
                        Console.WriteLine(BuscarItemVenda(listaItemVendas).ToString());
                        break;
                    case 3:
                        foreach (ItemVenda item in listaItemVendas)
                            Console.WriteLine(item.ToString() + "\n");
                        break;
                    case 0:
                        Console.WriteLine("Você saiu do Menu de Venda de Itens!");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida! Favor selecionar uma das opções acima!");
                        break;
                }
            } while (true);
        }
        #endregion
        #endregion Menus

        //Chamada de funções
        #region Funcoes
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
                if (item.CPF == cpf)
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
        #region ManterCompanhia
        public static CompanhiaAerea AdicionarCompanhia()
        {
            CompanhiaAerea companhia = new CompanhiaAerea();

            companhia.CadCompAerea();

            return companhia;
        }
        public static void EditarCompanhia(List<CompanhiaAerea> listaCompanhiaAereas)
        {
            CompanhiaAerea companhia = BuscarCompanhia(listaCompanhiaAereas);

            if (companhia != null)
            {
                companhia.EditarCompanhia();
            }
        }
        public static CompanhiaAerea BuscarCompanhia(List<CompanhiaAerea> listaCompanhiaAerea)
        {
            bool achei = false;

            Console.Write("Informe o CNPJ da Companhia Aérea para busca: ");
            string cnpj = Console.ReadLine();
            CompanhiaAerea companhia = new CompanhiaAerea();

            foreach (CompanhiaAerea item in listaCompanhiaAerea)
            {
                if (item.CNPJ == cnpj)
                {
                    achei = true;
                    companhia = item;
                    return companhia;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhuma Companhia Aérea com este CNPJ!");
            }
            return null;
        }
        #endregion
        #region ManterAeronave
        public static Aeronave AdicionarAeronave()
        {
            Aeronave aeronave = new Aeronave();

            aeronave.CadastroAeronave();

            return aeronave;
        }
        public static void EditarAeronave(List<Aeronave> listaAeronaves)
        {
            Aeronave aeronave = BuscarAeronave(listaAeronaves);

            if (aeronave != null)
            {
                aeronave.EditarAeronave();
            }
        }
        public static Aeronave BuscarAeronave(List<Aeronave> listaAeronaves)
        {
            bool achei = false;

            Console.Write("Informe a Inscrição da Aeronave para busca: ");
            string inscricao = Console.ReadLine();
            Aeronave aeronave = new Aeronave();

            foreach (Aeronave item in listaAeronaves)
            {
                if (item.Inscricao == inscricao)
                {
                    achei = true;
                    aeronave = item;
                    return aeronave;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhuma Aeronave com esta Inscrição!");
            }
            return null;
        }
        #endregion
        #region ManterVoo
        public static Voo AdicionarVoo(List<string> listaIatas)
        {
            Voo voo = new Voo();

            voo.CadastrarVoo(listaIatas);

            return voo;
        }
        public static void EditarVoo(List<Voo> listaVoos)
        {
            Voo voo = BuscarVoo(listaVoos);

            if (voo != null)
            {
                voo.EditarVoo();
            }
        }
        public static Voo BuscarVoo(List<Voo> listaVoos)
        {
            bool achei = false;

            Console.Write("Informe o ID do Voo para busca: ");
            string idVoo = Console.ReadLine();
            Voo voo = new Voo();

            foreach (Voo item in listaVoos)
            {
                if (item.IdVoo == idVoo)
                {
                    achei = true;
                    voo = item;
                    return voo;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhum Voo com este ID informado!");
            }
            return null;
        }
        #endregion
        #region ManterPassagem
        public static Passagem AdicionarPassagem()
        {
            Passagem passagem = new Passagem();

            passagem.CadastrarPassagem();

            return passagem;
        }
        public static void EditarPassagem(List<Passagem> listaPassagens)
        {
            Passagem passagem = BuscarPassagem(listaPassagens);

            if (passagem != null)
            {
                passagem.EditarPassagem();
            }
        }
        public static Passagem BuscarPassagem(List<Passagem> listaPassagens)
        {
            bool achei = false;

            Console.Write("Informe o ID da Passagem para busca: ");
            string idPassagem = Console.ReadLine();
            Passagem passagem;

            foreach (Passagem item in listaPassagens)
            {
                if (item.IdPassagem == idPassagem)
                {
                    achei = true;
                    passagem = item;
                    return passagem;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhuma Passagem com este ID informado!");
            }
            return null;
        }
        #endregion
        #region ManterVenda
        public static Venda AdicionarVenda()
        {
            Venda venda = new Venda();

            venda.CadastrarVenda();

            return venda;
        }
        public static Venda BuscarVenda(List<Venda> listaVendas)
        {
            bool achei = false;

            Console.Write("Informe o ID da Venda para busca: ");
            String idVenda = Console.ReadLine();
            Venda venda;
            foreach (Venda item in listaVendas)
            {
                if (item.IdVenda == idVenda)
                {
                    achei = true;
                    venda = item;
                    return venda;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhuma Venda com este ID informado!");
            }
            return null;
        }
        #endregion
        #region ManterItemVenda
        public static ItemVenda AdicionarItemVenda()
        {
            ItemVenda itemVenda = new ItemVenda();

            itemVenda.CadastrarVenda();

            return itemVenda;
        }
        public static ItemVenda BuscarItemVenda(List<ItemVenda> listaItemVendas)
        {
            bool achei = false;

            Console.Write("Informe o ID do Item de Venda para busca: ");
            String idItemVenda = Console.ReadLine();
            ItemVenda itemVenda;

            foreach (ItemVenda item in listaItemVendas)
            {
                if (item.IdItemVenda == idItemVenda)
                {
                    achei = true;
                    itemVenda = item;
                    return itemVenda;
                }
            }

            if (achei == false)
            {
                Console.WriteLine("Não foi encontrado nenhuma Venda de Item com este ID informado!");
            }
            return null;
        }
        #endregion
        #endregion

        #region gravarArquivos
        #region ArquivoPassageiro
        //metodo de gravacao do arquivo passageiros
        static void GravarArquivoPassageiro(List<Passageiro> listaPassageiros)
        {
            try
            {
                StreamWriter passageiro = new StreamWriter("C:\\ArquivosAeroporto\\Passageiro.dat");
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
            return $"{passageiro.CPF}{passageiro.Nome.PadRight(50)}{FormatarData(passageiro.DataNascimento)}{passageiro.Sexo}{FormatarData(passageiro.UltimaCompra)}{FormatarData(passageiro.DataCadastro)}";
        }

        //metodo de leitura do arquivo de passageiros
        static void LerArquivoPassageiros(List<Passageiro> listaPassageiro)
        {
            String line;

            try
            {
                StreamReader sr = new StreamReader("C:\\ArquivosAeroporto\\Passageiro.dat");
                line = sr.ReadLine();
                Console.WriteLine(line.Length);
                do
                {
                    Passageiro passageiro = new Passageiro();
                    passageiro.CPF = line.Substring(0, 11);
                    passageiro.Nome = line.Substring(11, 50);
                    passageiro.DataNascimento = Convert.ToDateTime($"{line.Substring(61, 2)}/{line.Substring(63, 2)}/{line.Substring(65, 4)}");
                    passageiro.Sexo = line[69];
                    passageiro.UltimaCompra = Convert.ToDateTime($"{line.Substring(70, 2)}/{line.Substring(72, 2)}/{line.Substring(74, 4)}");
                    passageiro.DataCadastro = DateTime.Parse($"{line.Substring(78, 2)}/{line.Substring(80, 2)}/{line.Substring(82, 4)}");
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
                StreamReader sr = new StreamReader("C:\\ArquivosAeroporto\\listaIatas.dat");
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
                StreamWriter ArqCompanhia = new StreamWriter("C:\\ArquivosAeroporto\\CompanhiaAerea.dat");
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
            try
            {
                StreamReader companhiaTxt = new StreamReader("C:\\ArquivosAeroporto\\CompanhiaAerea.dat");
                do
                {
                    line = companhiaTxt.ReadLine();
                    CompanhiaAerea companhia = new CompanhiaAerea();
                    companhia.CNPJ = line.Substring(0, 14);
                    companhia.RazaoSocial = line.Substring(14, 50);
                    companhia.DataAbertura = DateTime.Parse($"{line.Substring(51, 2)}/{line.Substring(53, 2)}/{line.Substring(55, 4)}");
                    companhia.UltimoVoo = DateTime.Parse($"{line[72]}{line[73]}/{line[74]}{line[75]}/{line[76]}{line[77]}{line[78]}{line[79]}");
                    companhia.DataCadastro = DateTime.Parse($"{line[80]}{line[81]}/{line[82]}{line[83]}/{line[84]}{line[85]}{line[86]}{line[87]}");
                    companhia.SituacaoCA = line[88];
                    listaCompanhias.Add(companhia);
                } while (line != null);
                companhiaTxt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha no carregamento do arquivo de CompanhiaAerea.dat\n " + e.Message);
            }
        }


        #endregion ArquivoCompanhiaAerea

        #region ArquivoAeronave
        //metodo de gravacao do arquivo passageiros
        static void GravarArquivoAeronave(List<Aeronave> listaAeronave)
        {
            try
            {
                StreamWriter ArqAeronaves = new StreamWriter("C:\\ArquivosAeroporto\\Aeronave.dat");
                foreach (var item in listaAeronave)
                {
                    if (item != null)
                        ArqAeronaves.WriteLine(getAeronave(item));
                }
                ArqAeronaves.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao gravar o arquivo Aeronave.dat\n" + e.Message);
            }
            finally
            {
                Console.WriteLine("Gravação arquivo Aeronave.dat efetuada com sucesso!!!");
            }
        }

        //metodo para retornar aeronave para gravar em arquivo
        static String getAeronave(Aeronave aeronave)
        {
            return $"{aeronave.Inscricao.PadRight(6)}{aeronave.Capacidade:000}{aeronave.AcentosOcupados:000}{FormatarData(aeronave.UltimaVenda)}{FormatarData(aeronave.DataCadastro)}{aeronave.Situacao}";
        }

        static void LerArquivoAeronave(List<Aeronave> listaAeronaves)
        {
            string line;

            try
            {
                StreamReader aeronaveTxt = new StreamReader("C:\\ArquivosAeroporto\\Aeronave.dat");
                do
                {
                    line = aeronaveTxt.ReadLine();
                    Aeronave aeronave = new Aeronave();
                    aeronave.Inscricao = line.Substring(0, 6);
                    aeronave.Capacidade = int.Parse(line.Substring(7, 3));
                    aeronave.AcentosOcupados = int.Parse(line.Substring(10, 3));
                    aeronave.UltimaVenda = DateTime.Parse($"{line.Substring(13, 2)}/{line.Substring(15, 2)}/{line.Substring(17, 4)}");
                    aeronave.DataCadastro = DateTime.Parse($"{line.Substring(22, 2)}/{line.Substring(24, 2)}/{line.Substring(26, 4)}");
                    aeronave.Situacao = line[31];
                    listaAeronaves.Add(aeronave);
                } while (line != null);
                aeronaveTxt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao ler o arquivo Aeronave.dat: " + e.Message);
            }
        }

        #endregion ArquivoAeronave

        #region Restritos e bloqueados

        #region gravacao
        //cpf restritos gravacao
        static void GravarCpfRestritos(List<String> listaRestritos)
        {
            try
            {
                StreamWriter restritos = new StreamWriter("C:\\ArquivosAeroporto\\Restritos.dat");
                foreach (var item in listaRestritos)
                    if (item != null)
                        restritos.WriteLine(item);
                restritos.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na gravação do arquivo Restrito: " + e);
            }
        }
        //cnpjs restritos
        static void GravarCnpjRestritos(List<String> listaRestritos)
        {
            try
            {
                StreamWriter bloqueados = new StreamWriter("C:\\ArquivosAeroporto\\Restritos.dat");
                foreach (var item in listaRestritos)
                    if (item != null)
                        bloqueados.WriteLine(item);
                bloqueados.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na gravação do arquivo Restrito: " + e);
            }
        }
        #endregion gravacao

        #region leitura
        //metodo para carregar cpfs restritos
        static void LerCpfRestrito(List<String> listaCpfRestrito)
        {
            try
            {
                string line;
                StreamReader cpfRestritoTxt = new StreamReader("C:\\ArquivosAeroporto\\Restritos.dat");
                do
                {
                    line = cpfRestritoTxt.ReadLine();
                    listaCpfRestrito.Add(line);

                } while (line != null);
                cpfRestritoTxt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na leitura do arquivo Restritos.dat" + e);
            }
        }

        static void LerCnpjBloqueado(List<String> listaCnpjBloqueado)
        {
            try
            {
                string line;
                StreamReader cnpjBloqueadoTxt = new StreamReader("C:\\ArquivosAeroporto\\Restritos.dat");
                do
                {
                    line = cnpjBloqueadoTxt.ReadLine();
                    listaCnpjBloqueado.Add(line);

                } while (line != null);
                cnpjBloqueadoTxt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na leitura do arquivo Restritos.dat" + e);
            }

            Random r = new Random();
            string n = "V" + r.Next(000, 999).ToString("000");
        }


        #endregion leitura
        #endregion Restrito

        //formatar data sem barras, somente numeros 
        static String FormatarData(DateTime data)
        {
            return data.ToString("ddMMyyyy");
        }
        #endregion gravararquivos

    }
}



