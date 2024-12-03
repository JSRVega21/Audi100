using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Audi100.Services;
using Audi100.Models;
using System.Net.Http.Headers;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Blazor.Reporting;
using DevExpress.XtraReports.Services;
using DevExpress.DataAccess.Web;
using DevExpress.XtraCharts;

namespace Audi100.Client
{
    public class Program
    {
        #region conection server
        private const string BaseUrlServer = "https://auditifyserver.ffacsa.com";
        //private const string BaseUrlServer = "http://localhost:7120";

        #endregion

        #region conection client
        //private const string BaseUrlClient = "http://localhost:7182";
        private const string BaseUrlClient = "https://auditify.ffacsa.com";
        #endregion
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddDevExpressBlazor(options =>
            {
                options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
                options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
                options.ShowValidationIcon = true;
            });

            builder.Services.AddDevExpressBlazorReportingWebAssembly(configure => {
                configure.UseDevelopmentMode();
            });


            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

        
            // Registrar el DelegatingHandler para manejar la autorización
            builder.Services.AddTransient<AuthenticatedHttpClientHandler>();

            builder.Services.AddScoped(sp =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(BaseUrlServer)
                };
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            });

            // Configurar HttpClient con el DelegatingHandler
            builder.Services.AddHttpClient("Audi100.Server", client =>
            {
                client.BaseAddress = new Uri(BaseUrlServer);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();

            builder.Services.AddHttpClient<FontLoader>("Audi100.Client", client =>
            {
                client.BaseAddress = new Uri(BaseUrlClient);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<IService<User, int>, UserService>();
            builder.Services.AddSingleton<IReportProviderAsync, CustomReportProvider>();

            #region Audit Services
            builder.Services.AddScoped<IService<AuditReport, int>, AuditReportService>();
            builder.Services.AddScoped<IService<AuditFinding, int>, AuditFindingService>();
            builder.Services.AddScoped<IService<AuditPrint, int>, AuditPrintService>();

            builder.Services.AddScoped<IDataSourceWizardJsonConnectionStorage, CustomDataSourceWizardJsonDataConnectionStorage>();
            builder.Services.AddScoped<IJsonDataConnectionProviderFactory, CustomJsonDataConnectionProviderFactory>();
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
