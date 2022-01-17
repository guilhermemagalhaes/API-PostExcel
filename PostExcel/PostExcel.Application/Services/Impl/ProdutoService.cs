using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostExcel.Application.InputModel;
using PostExcel.Application.Services.Contract;
using PostExcel.Application.ViewModels;
using PostExcel.Core.Entities;
using PostExcel.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostExcel.Application.Services.Impl
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllImportsViewModel>> GetAllImports()
        {
            return await _produtoRepository.GetAll()
                .OrderByDescending(x => x.DataEntrega)
                .Select(x => new GetAllImportsViewModel()
                {
                    Id = x.Id,
                    DataEntrega = x.DataEntrega,
                    Quantidade = x.Quantidade,
                    NomeProduto = x.NomeProduto,
                    ValorTotalImportacao = x.ValorUnitario * x.Quantidade
                }).ToListAsync();
        }

        public async Task<GetImportByIdViewModel> GetImportById(int id)
        {
            Expression<Func<Produto, bool>> predicate = p => p.Id == id;
            return await _produtoRepository.GetAll(predicate)                
                .Select(x => new GetImportByIdViewModel()
                {
                    DataEntrega = x.DataEntrega,
                    NomeProduto = x.NomeProduto,
                    Quantidade = x.Quantidade,
                    ValorTotal = x.ValorUnitario * x.Quantidade                    
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> Post(IList<ProdutoInputModel> models)
        {
            var requestMapeada = _mapper.Map<List<Produto>>(models);
            await _produtoRepository.CreateOrUpdate(requestMapeada);
            return true;
        }


    }
}
