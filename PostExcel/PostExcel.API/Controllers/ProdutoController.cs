using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostExcel.API.Message.Request;
using PostExcel.API.Message.Response;
using PostExcel.API.Message.Validator;
using PostExcel.Application.InputModel;
using PostExcel.Application.Services.Contract;
using PostExcel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PostExcel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile postedFile)
        {
            if (postedFile == null)
                return BadRequest();

            List<ProdutoRequest> requests = GetProdutosByPlanilha(postedFile);

            if (requests.Count() == 0)
                return BadRequest();

            var requestMapeada = _mapper.Map<List<ProdutoInputModel>>(requests);
            if (await _produtoService.Post(requestMapeada))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllImports")]
        public async Task<IActionResult> GetAllImports()
        {
            var request = await _produtoService.GetAllImports();

            if (request?.Count() == 0)
                return NotFound();

            var requestMapeada = _mapper.Map<List<GetAllImportsResponse>>(request);
            return Ok(requestMapeada);
        }

        [HttpGet]
        [Route("GetImportById/{id}")]
        public async Task<IActionResult> GetImportById([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var request = await _produtoService.GetImportById(id);

            if (request == null)
                return NotFound();

            var requestMapeada = _mapper.Map<GetImportByIdResponse>(request);
            return Ok(requestMapeada);
        }


        private List<ProdutoRequest> GetProdutosByPlanilha(IFormFile postedFile)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            FileInfo file = new FileInfo(filePath);
            string conexao = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml; HDR = YES';";

            DataTable dt = new DataTable();

            using (OleDbConnection conn = new(conexao))
            {
                conn.Open();

                DataTable dtExcelSchema;
                dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                string comando = string.Format(@"select * from[{0}]", sheetName);

                using (OleDbCommand cmd = new(comando, conn))
                {
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
                conn.Close();
            }

            var produtos = new List<ProdutoRequest>();
            foreach (DataRow valorLinha in dt.Rows)
            {
                var produto = new ProdutoRequest()
                {
                    DataEntrega = Convert.ToDateTime(valorLinha[0]),
                    NomeProduto = valorLinha[1].ToString(),
                    Quantidade = Convert.ToInt32(valorLinha[2]),
                    ValorUnitario = Convert.ToDecimal(valorLinha[3])
                };

                new ProdutorRequestValidator().ValidateAndThrow(produto);

                produtos.Add(produto);
            }
            return produtos;
        }
    }
}
