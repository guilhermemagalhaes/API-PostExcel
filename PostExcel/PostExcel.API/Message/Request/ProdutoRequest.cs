using System;

namespace PostExcel.API.Message.Request
{
    public class ProdutoRequest
    {        
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
