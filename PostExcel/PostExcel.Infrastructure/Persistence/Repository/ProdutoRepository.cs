using PostExcel.Core.Entities;
using PostExcel.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostExcel.Infrastructure.Persistence.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly AppDbContext context;
        public ProdutoRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
