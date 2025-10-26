﻿
namespace EstacionamentoTech.Models
{
    public class TabelaValores : IEntityModel
    {
        

        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public decimal ValorHoraInicial { get; set; }

        public decimal ValorHoraAdicional { get; set; }
    }
}
