using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class ItemVenda
    {
        public string IdItemVenda { get; set; }
        public PassagemVoo PassagemVoo { get; set; }
        public float ValorUnit { get; set; }

        public void CadastrarItemVenda(List<PassagemVoo> listaPassagensVoos)
        {
            Console.WriteLine(">>>CADASTRO DE VENDA DE ITEM<<<");

            //Inserir ID Venda

            //Lista de Passagens
            Console.WriteLine("Lista de Passagens:");
            foreach (PassagemVoo item in listaPassagensVoos)
            {
                Console.WriteLine(item.ToString());
            }

            Console.Write("Informe qual ID da Passagem pertence a venda deste Item: ");
            string iditemvenda = Console.ReadLine();

            foreach (PassagemVoo item in listaPassagensVoos)
            {
                if (item.IdPassagem == iditemvenda)
                    this.PassagemVoo = item;
            }


        }

    }
}
