using RaroLab.Teste.ViaCep.Model.Entidades;
using System;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.Service.Interfaces
{
    public interface IEnderecoService
    {
        public Task<Cep> ObterCep(String numCep);
    }
}
