using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Audi100.Services;
using Audi100.Models;
using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace Audi100.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddDevExpressBlazor(options =>
            {
                options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
                options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
                options.ShowValidationIcon = true;
            });

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Registrar el DelegatingHandler para manejar la autorización
            builder.Services.AddTransient<AuthenticatedHttpClientHandler>();

            builder.Services.AddScoped(sp =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7120/")
                };
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            });

            // Configurar HttpClient con el DelegatingHandler
            builder.Services.AddHttpClient("Audi100.Server", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7120");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();

            // Servicios
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<IService<User, int>, UserService>();

            #region Audit Services
            builder.Services.AddScoped<IService<AuditReport, int>, AuditReportService>();
            builder.Services.AddScoped<IService<AuditFinding, int>, AuditFindingService>();
            builder.Services.AddScoped<IService<AuditPrint, int>, AuditPrintService>();
            builder.Services.AddScoped<IService<AuditTrail, int>, AuditTrailService>();
            #endregion

            #region Catalogs Services
            builder.Services.AddScoped<IService<Bsc, int>, BscService>();
            builder.Services.AddScoped<IService<Classification, int>, ClassificationService>();
            builder.Services.AddScoped<IService<Weighing, int>, WeighingService>();
            builder.Services.AddScoped<IService<ShortF, int>, ShortFService>();
            #endregion

            builder.Services.AddScoped<IPhotoService<Photo, int>, PhotoService>();

            #region SQL Services
            builder.Services.AddScoped<SqlService>();
            builder.Services.AddScoped<SqlHomeService>();
            #endregion

            await builder.Build().RunAsync();
        }
    }
}
