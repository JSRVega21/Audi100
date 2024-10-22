using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public class AuthenticatedHttpClientHandler : DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;

    public AuthenticatedHttpClientHandler(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Obtener el token de localStorage
        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

        if (!string.IsNullOrEmpty(token))
        {
            //Console.WriteLine($"Token cargado desde localStorage: {token}");

            // Añadir el token al encabezado Authorization
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
        }
        else
        {
            Console.WriteLine("No se encontró el token en localStorage.");
        }

        // Enviar la solicitud al servidor
        return await base.SendAsync(request, cancellationToken);
    }
}
