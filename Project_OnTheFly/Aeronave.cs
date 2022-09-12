using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class Aeronave
    {
        //CHAVE, PADRÃO ANAC, 6 DIGITOD ALFANUMERICOS
        public String Inscricao { get; set; }     
        public int Capacidade { get; set; } //3 digitos numericos
        public int AcentosOcupados { get; set; } //3 digitos numericos
        public DateTime UltimaVenda { get; set; } //no cad, dt atual
        public DateTime DataCadastro { get; set; } //dt atual
        public char Situacao { get; set; }
        //public CompahiaAerea compAerea - associação

        public Aeronave()
        {

        }

        public Aeronave(string inscricao, int capacidade, int acentosOcupados, DateTime ultimaVenda, DateTime dataCadastro)
        {
            Inscricao = inscricao;         
            Capacidade = capacidade;
            AcentosOcupados = acentosOcupados;
            UltimaVenda = ultimaVenda;
            DataCadastro = DateTime.Now;
            Situacao = 'A';
        }

        //para cadastrar uma aeronave é necessário ela ser vinculada a uma compahia ?
        public void CadastroAeronave()
        {
             Console.WriteLine(">>>CADASTRO DE AERONAVE<<<");
            do
            {
                //não terá caracteres especiais (Delimitadores).
                Console.WriteLine("Informe o CÓDIGO de identificação da AERONAVE, segundo o padrão definido pela ANAC: ");
                Inscricao = Console.ReadLine().ToUpper().Trim();
                Inscricao = Inscricao.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                Inscricao = Inscricao.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
                Inscricao = Inscricao.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
                Inscricao = Inscricao.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
                Inscricao = Inscricao.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
                Inscricao = Inscricao.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
                Inscricao = Inscricao.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");
            } while (Inscricao.Length != 6);

            Console.WriteLine("Informe a capacidade de pessoas que a AERONAVE comporta: ");
            Capacidade = int.Parse(Console.ReadLine());

        }



        //Os prefixos de nacionalidade do Brasil são

        //Permite 105.456 combinações
        //“Tradicionalmente, o Brasil usa para aeronaves comerciais e privadas as letras iniciais
        //fixar o PP ou PR - 
        //PP, PT, PR, PS.
        //gero um numero randomico e nao repito
        // Proibido: iniciadas com a letra Q ou que tenham W como segunda letra.
        //Os arranjos SOS, XXX, PAN, TTT, VFR, IFR, VMC e IMC não podem ser utilizados.
    }
}
