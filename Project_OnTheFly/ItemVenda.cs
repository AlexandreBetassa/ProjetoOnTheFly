﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OnTheFly
{
    internal class ItemVenda
    {
        public String IdItemVenda { get; set; }
        public String IdPassagem { get; set; }
        public float ValorUnitario { get; set; }

        public ItemVenda(String idItemVenda, string idPassagem, float valorUnit)
        {
            IdPassagem = idItemVenda;
            IdPassagem = idPassagem;
            ValorUnitario = valorUnit;
        }

    }
}
