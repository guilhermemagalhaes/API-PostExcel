using System;
using System.ComponentModel.DataAnnotations;

namespace PostExcel.Core.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
