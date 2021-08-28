using Newtonsoft.Json;
using RaroLab.Teste.ViaCep.Model.Entidades;
using RaroLab.Teste.ViaCep.Model.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        public async Task<Endereco> ObterCep(String numCep)
        {
            Endereco endereco = new Endereco();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{numCep}/json/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    endereco = JsonConvert.DeserializeObject<Endereco>(apiResponse);
                }
            }

            return endereco;
        }
    }
}
