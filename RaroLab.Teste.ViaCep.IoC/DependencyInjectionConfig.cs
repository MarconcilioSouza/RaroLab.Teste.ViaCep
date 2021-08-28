using Microsoft.Extensions.DependencyInjection;
using RaroLab.Teste.ViaCep.Model.Interfaces;
using RaroLab.Teste.ViaCep.Service.Services;
using System;

namespace RaroLab.Teste.ViaCep.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddScoped<IEnderecoService, EnderecoService>();
        }
    }
}
