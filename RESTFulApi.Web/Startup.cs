using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RESTFulApi.Data.DbModels;
using RESTFulApi.Data.Repository;
using RESTFulApi.Logic.CQRS;
using RESTFulApi.Logic.Saga.Impl;
using RESTFulApi.Logic.Saga.Interface;
using RESTFulApi.Model.Request;
using RESTFulApi.Model.Response;

namespace RESTFulApi.Web
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
            services.AddControllers();

            services.AddDbContext<AdventureWorks2017Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMediatR(typeof(Startup));

            services.AddScoped<IRequestHandler<GetProductRequest, IEnumerable<GetProductResponse>>, SearchProduct>()
                    .AddScoped((x) => new Lazy<IRequestHandler<GetProductRequest, IEnumerable<GetProductResponse>>>(() => x.GetRequiredService<IRequestHandler<GetProductRequest, IEnumerable<GetProductResponse>>>()));

            services.AddScoped<ISagaHandler<GetProductRequest, GenericResponse<IEnumerable<GetProductResponse>>>, GetProductSaga>()
                    .AddScoped((x) => new Lazy<ISagaHandler<GetProductRequest, GenericResponse<IEnumerable<GetProductResponse>>>>(() => x.GetRequiredService<ISagaHandler<GetProductRequest, GenericResponse<IEnumerable<GetProductResponse>>>>()));

            services.AddScoped<Data.Repository.IRepository, Data.Repository.Repository>()
                    .AddScoped(x => new Lazy<IRepository>(() => x.GetRequiredService<IRepository>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            //app.UseMiddleware<CustomMddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });           
        }
    }
}
