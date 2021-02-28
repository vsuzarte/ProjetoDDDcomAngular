using CrossCutting.DependencyInjection;
using Domain.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Options;

namespace CRM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //adiciono as configuração de injeção de dependencia.
            ConfigureService.ConfigurarInjecaoDeDependencias(services);
            ConfigureRepository.ConfigurarInjecaoDeDependencias(services);

            //Adiciono as configuração do token, por injeção de dependencia.
            var signingConfiguration = new SigninConfigurations();
            //Adiciono como singleton porque ela deve ser uma estancia unica.
            services.AddSingleton(signingConfiguration);

            var tokenConfiguration = new TokenConfigurations();

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                     .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddControllers();

            //Adiciono middleware, swagger
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "S3 Soluções - CRMw",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Vitor Fraga Suzarte",
                        Email = "suzartevitor@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/suzartevitor/")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //habilitar swagger;
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "S3 Soluções - CRMw.");
                    c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
