using DevExpress.Drawing;
using DevExpress.XtraReports.UI;

public static class ReportsFactory
{

    public static readonly Dictionary<string, XtraReport> Reports = new()
    {
        ["EmptyReport"] = new XtraReport()
    };

    public async static Task<XtraReport> GetReport(string reportName, HttpClient httpClient)
    {

        var url = $"{httpClient.BaseAddress}reports/{reportName}.repx";
        Console.WriteLine($"URL completa utilizada: {url}");

        var reportBytes = await httpClient.GetByteArrayAsync(url);
        MemoryStream reportStream = new MemoryStream(reportBytes);
        return XtraReport.FromXmlStream(reportStream);
    }

}