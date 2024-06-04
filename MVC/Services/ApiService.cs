using Microsoft.Extensions.Options;
using MVC.Models;
using PaymentSystem.DAL.Models;
using PaymentSystem.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["WebAPI:BaseUrl"];
    }

    public async Task<Account> GetAccountBalanceAsync(string userId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}account/{userId}");
        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
    }

    public async Task<decimal> AddFundsAsync(AddFundsRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}account/addFunds", content);
        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<decimal>(await response.Content.ReadAsStringAsync());
    }
}
