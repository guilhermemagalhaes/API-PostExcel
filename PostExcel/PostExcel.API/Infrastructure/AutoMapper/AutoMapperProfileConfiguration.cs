using AutoMapper;
using PostExcel.API.Message.Request;
using PostExcel.API.Message.Response;
using PostExcel.Application.InputModel;
using PostExcel.Application.ViewModels;
using PostExcel.Core.Entities;


namespace PostExcel.API.Infrastructure.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<ProdutoRequest, ProdutoInputModel>().ReverseMap();
            CreateMap<ProdutoInputModel, Produto>().ReverseMap();
            CreateMap<GetAllImportsViewModel, GetAllImportsResponse>().ReverseMap();
            CreateMap<GetImportByIdViewModel, GetImportByIdResponse>().ReverseMap();
        }
    }
}
