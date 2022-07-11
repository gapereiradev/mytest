using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using mytest.API.Filters;
using mytest.Application.Commands.CreatePessoa;
using mytest.Application.Validators;
using mytest.Core.Repositories;
using mytest.Infra.CloudServices.Implementations;
using mytest.Infra.CloudServices.Interfaces;
using mytest.Infra.Persistence;
using mytest.Infra.Persistence.Repositories;

namespace mytest.API
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

            var connectionString = Configuration.GetConnectionString("mytestCs");
            services.AddDbContext<mytestDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IDapperRepository, DapperRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IEmailServices, EmailServices>();


            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePessoaCommandValidator>());


            services.AddMediatR(typeof(CreatePessoaCommand));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mytest.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mytest.API v1"));
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
