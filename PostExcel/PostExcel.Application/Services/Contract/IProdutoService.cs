using PostExcel.Application.InputModel;
using PostExcel.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostExcel.Application.Services.Contract
{
    public interface IProdutoService
    {
        Task<bool> Post(IList<ProdutoInputModel> models);
        Task<IList<GetAllImportsViewModel>> GetAllImports();
        Task<GetImportByIdViewModel> GetImportById(int id);
    }
}
