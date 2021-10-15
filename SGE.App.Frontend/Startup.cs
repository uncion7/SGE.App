using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGE.App.Persistencia;

namespace SGE.App.Frontend
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
            services.AddRazorPages();
            services.AddDbContext<SGE.App.Persistencia.AppContext>();
            services.AddScoped<IRepositorioDepartamento, RepositorioDepartamento>();
            services.AddScoped<IRepositorioMunicipio, RepositorioMunicipio>();
            services.AddScoped<IRepositorioMatricula, RepositorioMatricula>();
            services.AddScoped<IRepositorioRol, RepositorioRol>();
            services.AddScoped<IRepositorioCiclo, RepositorioCiclo>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IRepositorioGrupo, RepositorioGrupo>();
            services.AddScoped<IRepositorioHorario, RepositorioHorario>();
            services.AddScoped<IRepositorioCalificacion, RepositorioCalificacion>();
            services.AddScoped<IRepositorioNota, RepositorioNota>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
