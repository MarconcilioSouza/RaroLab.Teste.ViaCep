using RaroLab.Teste.ViaCep.Model.Entidades;
using System;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.Model.Interfaces
{
    public interface IEnderecoService
    {
        public Task<Endereco> ObterCep(String numCep);
    }
}
