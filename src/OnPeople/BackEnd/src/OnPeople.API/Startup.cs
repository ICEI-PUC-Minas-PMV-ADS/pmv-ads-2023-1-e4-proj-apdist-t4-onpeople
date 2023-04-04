using System.Text;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using OnPeople.API.Controllers.Uploads;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Application.Services.Implementations.Users;
using OnPeople.Application.Services.Implementations.Empresas;
using OnPeople.Domain.Models.Users;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Users;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;
using OnPeople.Persistence.Interfaces.Implementations.Users;
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
            services
                .AddDbContext<OnPeopleContext>(
                    context => context.UseMySql(Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));

            // Injeção Identity
            services
                .AddIdentityCore<User>(options => {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 4;
                })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<OnPeopleContext>()
                .AddDefaultTokenProviders();
            
            //Injeção de autenticação
            services    
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokenkey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            
            //Injeção das controllers
            services
                .AddControllers()

                // Já leva os enum convertidos na query
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                
                // Eliminar loop infinito da estrutura
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //InjeÇão do mapeamento automático de canpos (DTO)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //InjeÇão dos serviços de persistencias
            services
                .AddScoped<IEmpresasServices, EmpresasServices>()
                .AddScoped<IUsersServices, UsersServices>()
                .AddScoped<ITokenServices, TokenServices>();

            //Injeção das interfaces de Persistencias
            services
                .AddScoped<ISharedPersistence, SharedPersistence>()
                .AddScoped<IEmpresasPersistence, EmpresasPersistence>()
                .AddScoped<IUsersPersistence, UsersPersistence>();

            //Injeção do Upload como serviço    
            services
                .AddScoped<IUploadService, UploadService>();

            services
                .AddCors();

            services
                .AddSwaggerGen(options =>
                {
                        options.SwaggerDoc("v1", new OpenApiInfo { Title = "OnPeople.API", Version = "v1" });
                        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                        Description = @"JWT Authorization header usando Beares. Entre com 'Bearer [espaço] em seguida coloque sei token.
                                        Exemplo: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
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
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnPeople.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Para autorizar, primeiramento temos que autenticar
            app.UseAuthentication();
            
            app.UseAuthorization();

            //Injeção cors ...
            app.UseCors(options => options
                                    .AllowAnyHeader()
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