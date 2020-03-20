using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using SPMigracao.Api.Infrastructure.Context;
using SPMigracao.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using CRUDWEB2.Api.Domain.Cidades;
using CRUDWEB2.Api.Infrastructure.Repositories;
using CRUDWEB2.Api.Application.Services;
using CRUDWEB2.Api.Domain.Clientes;

namespace SPMigracao.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Banco de dados
            services
                .AddDbContext<MainContext>((opt) => opt.UseSqlServer(GetConnectionString()));

            // Documentação
            services.AddSwaggerGen(cfg =>
            {
                var contact = new OpenApiContact
                {
                    Name = "CRUD ASPNET CORE",
                    Email = "crud@utfpr.edu.br",
                    Url = new Uri("http://portal.utfpr.edu.br")
                };

                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CRUD ASPNET CORE API 1.0",
                    Contact = contact
                });
            });

            // Configurações gerais da api
            services
                .Configure<ApiBehaviorOptions>(o =>
                {
                    o.InvalidModelStateResponseFactory = actionContext => new BadRequestObjectResult(new
                    {
                        ReasonOfFail = "Dados inválidos",
                        Errors = actionContext.ModelState.SelectMany(x => x.Value.Errors)
                    });
                })
                .AddControllers()
                .AddJsonOptions((opt) =>
                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            // Contratos e classes concretas da aplicação
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

        }

        private string GetConnectionString() => Configuration.GetConnectionString("MainDB") + "Password=" + Configuration["DbPassword"];

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });


            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app
              .UseSwagger()
              .UseSwaggerUI(s =>
              {
                  s.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                  s.DisplayRequestDuration();
                  s.DisplayOperationId();
                  s.EnableValidator();
                  s.DefaultModelExpandDepth(2);
                  s.DefaultModelRendering(ModelRendering.Model);
                  s.DefaultModelsExpandDepth(-1);
                  s.DocExpansion(DocExpansion.None);
                  s.EnableDeepLinking();
                //   s.MaxDisplayedTags(5);
                  s.ShowExtensions();

                  s.RoutePrefix = string.Empty;
                  s.DocumentTitle = "CRUD ASPNET CORE - Restful Api";
              });
        }
    }
}