using Microsoft.AspNetCore.Mvc;
using RaroLab.Teste.ViaCep.Model.Entidades;
using RaroLab.Teste.ViaCep.Service.Services;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        public EnderecoController()
        {
        }

        [HttpGet("{numCep}")]
        public async Task<IActionResult> Get(string numCep)
        {
            if (Cep.ValidaCEP(numCep))
            {
                EnderecoService enderecoService = new EnderecoService();
                var cep = await enderecoService.ObterCep(numCep);
                if (cep == null)
                {
                    return NotFound("Dados do Cep não encontrado!");
                }
                return Json(cep);
            }
            else
            {
                return ValidationProblem("Cep inválido!");
            }
        }
    }
}
