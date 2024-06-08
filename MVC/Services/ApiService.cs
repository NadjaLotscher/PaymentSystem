using MVC.Models;
using System.Net.Http.Json;

namespace MVC.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["WebAPI:BaseUrl"];
        }

        public async Task<AccountDTO> PostAccountDTO(AccountDTO account)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/account", account);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AccountDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add account. Error: {error}");
            }
        }

        public async Task<StudentDTO> PostStudentDTO(StudentDTO student)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/student", student);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StudentDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add student. Error: {error}");
            }
        }

        public async Task<TransactionDTO> PostTransactionDTO(TransactionDTO transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/transaction", transaction);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TransactionDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add transaction. Error: {error}");
            }
        }

        public async Task<List<AccountDTO>> GetAccountDTOs()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/account");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<AccountDTO>>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to get accounts. Error: {error}");
            }
        }

        public async Task<AccountDTO> GetAccountDTO(int studentId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/account/{studentId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AccountDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to get account. Error: {error}");
            }
        }

        public async Task<List<TransactionDTO>> GetTransactionDTOs(int studentId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/transaction/{studentId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<TransactionDTO>>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to get transactions. Error: {error}");
            }
        }

        public async Task<AccountDTO> UpdateAccountDTO(AccountDTO account)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/account", account);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AccountDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to update account. Error: {error}");
            }
        }
   


        //public async Task<Account> GetAccountBalanceAsync(string userId)
        //{
        //    var response = await _httpClient.GetAsync($"{_baseUrl}account/{userId}");
        //    response.EnsureSuccessStatusCode();
        //    return JsonSerializer.Deserialize<Account>(await response.Content.ReadAsStringAsync());
        //}

        //public async Task<decimal> AddFundsAsync(AddFundsRequest request)
        //{
        //    var json = JsonSerializer.Serialize(request);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await _httpClient.PostAsync($"{_baseUrl}account/addFunds", content);
        //    response.EnsureSuccessStatusCode();
        //    return JsonSerializer.Deserialize<decimal>(await response.Content.ReadAsStringAsync());
        //}
    }
}
