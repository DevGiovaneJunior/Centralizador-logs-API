using AutoMapper;
using LogElasticAPI.Domain.Entities;
using LogElasticAPI.Domain.Interfaces;
using LogElasticAPI.Infra.Data.Context;
using LogElasticAPI.Infra.Data.Repository;
using LogElasticAPI.Model;
using LogElasticAPI.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogElasticAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogElasticAPI", Version = "v1" });
            });
            var settings = Configuration.GetSection("ElastUrl").Value;
            services.AddSingleton<IElasticClient>(new ElasticClient(new Uri(settings)));
            //services.AddTransient<ILoggerService, LoggerService>();
            services.AddScoped<IBaseRepository<Log>, BaseRepository<Log>>();
            services.AddScoped<IBaseService<Log>, BaseService<Log>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateLogModel, Log>();
                config.CreateMap<Log, LogModel>();
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogElasticAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
