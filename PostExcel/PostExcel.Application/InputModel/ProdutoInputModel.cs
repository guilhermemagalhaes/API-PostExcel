using System;

namespace PostExcel.Application.InputModel
{
    public class ProdutoInputModel
    {
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
