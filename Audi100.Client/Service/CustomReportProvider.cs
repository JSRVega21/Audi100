using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using System.Net.Http;

public class CustomReportProvider : IReportProviderAsync
{
    private readonly IHttpClientFactory _clientFactory;

    public CustomReportProvider(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public Task<XtraReport> GetReportAsync(string id, ReportProviderContext context)
    {
        var httpClient = _clientFactory.CreateClient("Audi100.Client");
        return ReportsFactory.GetReport(id, httpClient);
    }
}
