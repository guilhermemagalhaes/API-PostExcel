using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostExcel.API.Message.Response
{
    public class GetImportByIdResponse
    {       
        public DateTime DataEntrega { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
