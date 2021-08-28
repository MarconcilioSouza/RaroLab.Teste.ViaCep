using Microsoft.AspNetCore.Mvc;
using RaroLab.Teste.ViaCep.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        public EnderecoController()
        {
        }

        [HttpGet]
        public Cep Get()
        {
        }
    }
}
