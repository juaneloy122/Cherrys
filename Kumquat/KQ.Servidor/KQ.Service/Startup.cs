using KQ.CommonLib.Models.Acta;
using KQ.CommonLib.Models.Calendario;
using KQ.CommonLib.Models.Tablon;
using KQ.CommonLib.Models.Tarea;
using KQ.CommonLib.Models.Usuario;
using KQ.Service.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ST.Utilidades.Log;
using Swashbuckle.AspNetCore.Swagger;

namespace KQ.Service
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IItemRepository<Anuncio>, AnuncioRepository>();
            services.AddSingleton<IItemRepository<Acta>, ActaRepository>();
            services.AddSingleton<IItemRepository<Usuario>, UsuarioRepository>();
            services.AddSingleton<IItemRepository<Evento>, CalendarioRepository>();
            services.AddSingleton<IItemRepository<Tarea>, TareaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de acceso a datos Kumquat", Version = "v1", Description = "Loggin de usuarios, servidor de anuncios, eventos, actas..." });
            });
        }
                

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Log.InitLog("logs\\MobileAppService.txt", "SERVICIO KUMQUAT");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de acceso a datos Kumquat");
                c.RoutePrefix = string.Empty;
            });
        }

    }
}