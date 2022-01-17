using System;

namespace PostExcel.Application.ViewModels
{
    public class GetAllImportsViewModel
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalImportacao { get; set; }

    }
}
