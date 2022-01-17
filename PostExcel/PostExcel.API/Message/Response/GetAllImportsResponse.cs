using System;

namespace PostExcel.API.Message.Response
{
    public class GetAllImportsResponse
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalImportacao { get; set; }
    }
}
