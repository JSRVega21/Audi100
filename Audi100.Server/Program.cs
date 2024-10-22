global using Audi100.Models;
global using Microsoft.EntityFrameworkCore;

using Audi100.Server.Data;
using Audi100.Server.Repository;
using Audi100.Server.Repository.Login;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Audi100.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar Kestrel para manejar grandes archivos
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenLocalhost(7120, o => o.UseHttps());
                serverOptions.ListenLocalhost(5000);
                serverOptions.Limits.MaxRequestBodySize = null;
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

            // Configurar DbContext con SQL Server
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Configurar CORS con el origen del cliente
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Audi100.Server", policy =>
                {
                    policy.WithOrigins("https://localhost:7182", "http://localhost:7182")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()
                          .WithExposedHeaders("Authorization");
                });
            });


            // Configurar JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Audi100.Server",
                        ValidAudience = "Audi100.Client",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("aplicacion_FFACSA_AUDIT_100_ClaveSecreta"))
                    };
                });

            builder.Services.AddAuthorization();

            // Registrar controladores, servicios y Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLocalization();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            #region Repositorios

            #region Login
            builder.Services.AddScoped<IUserRepository<User, int>, UserRepository>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            #endregion

            #region SQL Repository
            builder.Services.AddScoped<ISqlRepository, SqlDataRepository>();
            builder.Services.AddScoped<ISqlHomeRepository, SqlDataHomeRepository>();
            #endregion

            #region Audit
            builder.Services.AddScoped<IRepository<AuditFinding, int>, AuditFindingRepository>();
            builder.Services.AddScoped<IRepository<AuditReport, int>, AuditReportRepository>();
            builder.Services.AddScoped<IRepository<AuditPrint, int>, AuditPrintRepository>();
            builder.Services.AddScoped<IRepository<AuditTrail, int>, AuditTrailRepository>();
            #endregion

            #region Catalogs
            builder.Services.AddScoped<IRepository<Bsc, int>, BscRepository>();
            builder.Services.AddScoped<IRepository<Classification, int>, ClassificationRepository>();
            builder.Services.AddScoped<IRepository<Weighing, int>, WeighingRepository>();
            builder.Services.AddScoped<IRepository<ShortF, int>, ShortFRepository>();
            builder.Services.AddScoped<IPhotoRepository<Photo, int>, PhotoRepository>();
            #endregion

            #endregion


            var app = builder.Build();

            // Habilitar Swagger solo en desarrollo
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aplicar redirección HTTPS
            app.UseHttpsRedirection();

            // Aplicar archivos estáticos
            app.UseStaticFiles();

            // **IMPORTANTE:** Aplicar el middleware de autorización en el lugar correcto
            app.UseRouting();  // Primero enrutamiento

            // Aplicar CORS antes de autenticación y autorización
            app.UseCors("Audi100.Server");

            // Aplicar el middleware de autenticación
            app.UseAuthentication();

            app.UseAuthorization();  // Después autorización

            // Configurar los endpoints de la aplicación
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    var token = context.Request.Headers["Authorization"].ToString();
                    Console.WriteLine($"Token recibido en el servidor: {token}");
                }
                else
                {
                    Console.WriteLine("No se recibió el encabezado Authorization.");
                }
                await next();
            });


            // Iniciar la aplicación
            app.Run();

        }
    }
}
