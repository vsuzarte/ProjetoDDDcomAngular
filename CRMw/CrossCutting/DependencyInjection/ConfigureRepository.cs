using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigurarInjecaoDeDependencias(IServiceCollection services)
        {
            //AddTransient: são iguais em uma solicitação, mas diferentes em diferentes solicitações.
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));

            services.AddDbContext<DBCtx>(
                options => options.UseSqlServer(DBCtx.ConecctionString)
            );
        }
    }
}
