using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Usuario;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigurarInjecaoDeDependencias(IServiceCollection services)
        {
            //AddTransient: são sempre diferente. uma nova instância é fornecida para cada controlador e cada serviço.
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}
