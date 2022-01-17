using System;

namespace PostExcel.Application.ViewModels
{
    public class GetImportByIdViewModel
    {
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
