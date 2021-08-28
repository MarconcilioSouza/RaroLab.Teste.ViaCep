﻿using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace RaroLab.Teste.ViaCep.Model.Entidades
{
    public class Cep
    {
        [JsonProperty("cep")]
        public string NumCep { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("ibge")]
        public string Ibge { get; set; }
        [JsonProperty("gia")]
        public string Gia { get; set; }
        [JsonProperty("ddd")]
        public string Ddd { get; set; }
        [JsonProperty("siafi")]
        public string Siafi { get; set; }

        public static bool ValidaCEP(string numCep)
        {
            Regex rgx = new Regex("^\\d{5}-?\\d{3}$");
            return rgx.IsMatch(numCep);
        }
    }
}
