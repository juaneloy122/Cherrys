using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using AppCherrys.Models;
using CommonLib.Models.Tablon;
using CommonLib.Models.Usuario;
using CommonLib.Models.Acta;
using CommonLib.Models.Calendario;
using CommonLib.Models.Tarea;
using ST_Utilidades.Log;

namespace AppCherrys.MobileAppService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IItemRepository<Anuncio>, AnuncioRepository>();
            services.AddSingleton<IItemRepository<Acta>, ActaRepository>();
            services.AddSingleton<IItemRepository<Usuario>, UsuarioRepository>();
            services.AddSingleton<IItemRepository<Evento>, CalendarioRepository>();
            services.AddSingleton<IItemRepository<Tarea>, TareaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API de acceso a datos Kumquat", Version = "v1", Description = "Loggin de usuarios, servidor de anuncios, eventos, actas..." });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Log.InitLog ("logs\\MobileAppService.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de acceso a datos Kumquat");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}