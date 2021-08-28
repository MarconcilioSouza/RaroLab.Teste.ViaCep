using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RaroLab.Teste.ViaCep.Model.Entidades;
using RaroLab.Teste.ViaCep.Model.Interfaces;
using System;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.WebApi.Controllers
{
    /// <summary>
    /// Api de endereços
    /// </summary>
    [ApiController]
    [Route("api/endereco")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMemoryCache _cache;

        public EnderecoController(IEnderecoService enderecoService, IMemoryCache cache)
        {
            _cache = cache;
            _enderecoService = enderecoService;
        }

        [HttpGet("{numCep}")]
        public async Task<IActionResult> Get(string numCep)
        {
            try
            {
                numCep = Endereco.ObterSomenteNumero(numCep);
                Endereco endereco = null;

                if (!string.IsNullOrEmpty(numCep))
                {
                    var cacheKey = string.Concat("getcep", numCep);
                    if (!_cache.TryGetValue(cacheKey, out endereco))
                    {
                        endereco = await _enderecoService.ObterCep(numCep);

                        if (endereco == null || string.IsNullOrEmpty(endereco.cep))
                            return NotFound("Endereço não localizado!");

                        var cacheOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

                        _cache.Set(cacheKey, endereco, cacheOptions);
                    }
                }
                else
                {
                    return ValidationProblem("Cep inválido!");
                }
                return Json(endereco);
            }
            catch
            {
                return BadRequest("Erro interno!");
            }
        }
    }
}
