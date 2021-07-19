﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class Vendas
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public DateTime DataDaVenda { get; set; }

        internal void Cadastrar(int id, decimal valorTotal, decimal desconto, DateTime dataDaVenda)
        {
            Id = id;
            ValorTotal = valorTotal;
            Desconto = desconto;
            DataDaVenda = dataDaVenda;
        }
    }
}