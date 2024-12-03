using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.Web;
using DevExpress.DataAccess.Wizard.Services;

public class CustomDataSourceWizardJsonDataConnectionStorage : IDataSourceWizardJsonConnectionStorage
{
    private static int _currentAuditPrintId;

    public static void SetAuditPrintId(int auditPrintId)
    {
        _currentAuditPrintId = auditPrintId;

    }

    public static List<JsonDataConnection> GetConnections()
    {
        return new List<JsonDataConnection>
    {
        GetConnectionByAuditPrintId(_currentAuditPrintId, "ReportPrint"),
        GetConnectionByAuditPrintId(_currentAuditPrintId, "ReportPrintShort")
    };
    }

    public static JsonDataConnection GetConnectionByAuditPrintId(int auditPrintId, string connectionName)
    {
        var uriJsonSource = new UriJsonSource
        {
            Uri = new Uri($"https://auditifyserver.ffacsa.com/api/SqlReportPrint/GetReportPrint?AuditPrintId={auditPrintId}")
        };

        return new JsonDataConnection(uriJsonSource)
        {
            StoreConnectionNameOnly = true,
            Name = connectionName
        };
    }

    bool IJsonConnectionStorageService.CanSaveConnection => false;

    bool IJsonConnectionStorageService.ContainsConnection(string connectionName)
    {
        return GetConnections().Any(x => x.Name == connectionName);
    }

    IEnumerable<JsonDataConnection> IJsonConnectionStorageService.GetConnections()
    {
        return GetConnections();
    }

    JsonDataConnection IJsonDataConnectionProviderService.GetJsonDataConnection(string name)
    {
        var connection = GetConnections().FirstOrDefault(x => x.Name == name);
        if (connection == null)
            throw new InvalidOperationException();
        return connection;
    }

    void IJsonConnectionStorageService.SaveConnection(string connectionName, JsonDataConnection connection, bool saveCredentials) { }
}
