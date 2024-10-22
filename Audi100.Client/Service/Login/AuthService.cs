using Microsoft.JSInterop;
using System.Net.Http.Json;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<bool> Login(string identifier, string password)
    {
        var loginRequest = new { Identifier = identifier, Password = password };
        var response = await _httpClient.PostAsJsonAsync("api/Login", loginRequest);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (result != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", result.Token);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "role", result.user.UserRoleId.ToString());
                return true;
            }
        }

        return false;
    }

    public async Task Logout()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "token");
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "role");
    }


    public async Task<string?> GetToken()
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
    }

    public async Task<string?> GetRole()
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "role");
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public User user { get; set; }

        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public int UserRoleId { get; set; }
            public string UserRole { get; set; }
        }
    }
}
