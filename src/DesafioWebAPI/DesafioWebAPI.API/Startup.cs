using Autofac;
using DesafioWebAPI.Infra.CrossCutting.IoC;
using DesafioWebAPI.Infra.CrossCutting.IoC.Modules;
using DesafioWebAPI.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.API
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
            var connection = Configuration["ConnectionStrings:DesafioWebAPIDB"];
            services.AddDbContext<DesafioWebAPIContext>(option => option.UseSqlServer(connection));
            services.AddControllers();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Web API", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperAutofacModule>();
            builder.RegisterModule<RepositoryAutofacModule>();
            builder.RegisterModule<ApplicationAutofacModule>();
            builder.RegisterModule<ServiceAutofacModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Web API");
            });

            app.UseHttpsRedirection();

            var defaultDateCulture = "pt-BR";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.CurrencyDecimalSeparator = ",";

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
                {
                    ci,
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ci,
                }
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
