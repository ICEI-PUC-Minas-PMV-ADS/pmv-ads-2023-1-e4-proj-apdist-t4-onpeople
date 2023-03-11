using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using OnPeople.API.Controllers.Uploads;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Application.Services.Implementations.Empresas;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;
using OnPeople.Persistence.Interfaces.Implementations.Empresas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.API
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
            // Injeção do DBCONTEXT no projeto
            services.AddDbContext<OnPeopleContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default")));

            //Injeção das controllers
            services.AddControllers()
                    // Eliminar loop infinito da estrutura
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //InjeÇão do mapeamento automático de canpos (DTO)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //InjeÇão dos serviços de persistencias
            services.AddScoped<IEmpresasServices, EmpresasServices>();
            services.AddScoped<ISharedPersistence, SharedPersistence>();
            services.AddScoped<IEmpresasPersistence, EmpresasPersistence>();
            services.AddScoped<IUploads, Uploads>();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnPeople.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnPeople.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Injeção cors ...
            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            //Injeção de diretivas para utilização de diretórios
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}