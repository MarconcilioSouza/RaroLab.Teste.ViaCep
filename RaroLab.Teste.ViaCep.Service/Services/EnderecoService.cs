using Newtonsoft.Json;
using RaroLab.Teste.ViaCep.Model.Entidades;
using RaroLab.Teste.ViaCep.Service.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaroLab.Teste.ViaCep.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        public async Task<Cep> ObterCep(String numCep)
        {
            Cep cepResult = new Cep();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{numCep}/json/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cepResult = JsonConvert.DeserializeObject<Cep>(apiResponse);
                }
            }

            return cepResult;
        }
    }
}
