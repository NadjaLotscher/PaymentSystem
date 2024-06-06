using Microsoft.Extensions.Options;
using MVC.Models;
using PaymentSystem.DAL.Models;
using PaymentSystem.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using MVC.Models;

namespace MVC.Services
{

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
  
       //// Use this constructor to be consistent with the Program.cs configuration
       // public ApiService(HttpClient httpClient, IOptions<MySettingsModel> settings)
       // {
       //     _httpClient = httpClient;
       //     _baseUrl = settings.Value.WebApiBaseUrl;
       // }

        // Optionally, you could keep this constructor if needed
        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["WebAPI:BaseUrl"];
        }

        //add methods for all DB entities
        public async Task<AccountDTO> PostAccountDTO(AccountDTO account)
        {
            var restponse = await _httpClient.PostAsJsonAsync(_baseUrl, account);
            if (restponse.IsSuccessStatusCode)
            {
                var accountReturned = await restponse.Content.ReadFromJsonAsync<AccountDTO>();
                return accountReturned;
            }
            else
            {
                throw new Exception("Failed to add account");
                return null;
            }

        }

        public async Task<StudentDTO> PostStudentDTO(StudentDTO student)
        {
            var restponse = await _httpClient.PostAsJsonAsync(_baseUrl, student);
            if (restponse.IsSuccessStatusCode)
            {
                var studentReturned = await restponse.Content.ReadFromJsonAsync<StudentDTO>();
                return studentReturned;
            }
            else
            {
                throw new Exception("Failed to add student");
                return null;
            }

        }

        public async Task<TransactionDTO> PostTransactionDTO(TransactionDTO transaction)
        {
           var restponse = await _httpClient.PostAsJsonAsync(_baseUrl, transaction);
            if (restponse.IsSuccessStatusCode)
            {
                var transactionReturned = await restponse.Content.ReadFromJsonAsync<TransactionDTO>();
                return transactionReturned;
            }
            else
            {
                throw new Exception("Failed to add transaction");
                return null;
            }
        }

        
        public async Task<List<AccountDTO>> GetAccountDTOs()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var accountList = await response.Content.ReadFromJsonAsync<List<AccountDTO>>();
                return accountList;
            }
            else
            {
                throw new Exception("Failed to get accounts");
                return null;
            }
        }   
        public async Task<AccountDTO> GetAccountDTO(int StudentId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{StudentId}");
            if (response.IsSuccessStatusCode)
            {
                var account = await response.Content.ReadFromJsonAsync<AccountDTO>();
                return account;
            }
            else
            {
                throw new Exception("Failed to get account");
                return null;
            }   



        }

        public async Task<List<TransactionDTO>> GetTransactionDTOs(int StudentId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{StudentId}");
            if (response.IsSuccessStatusCode)
            {
                var transactionList = await response.Content.ReadFromJsonAsync<List<TransactionDTO>>();
                return transactionList;
            }
            else
            {
                throw new Exception("Failed to get transactions");
                return null;
            }
        }

        public async Task<AccountDTO> UpdateAccountDTO(AccountDTO account)
        {
            var restponse = await _httpClient.PutAsJsonAsync(_baseUrl, account);
            if (restponse.IsSuccessStatusCode)
            {
                var accountReturned = await restponse.Content.ReadFromJsonAsync<AccountDTO>();
                return accountReturned;
            }
            else
            {
                throw new Exception("Failed to update account");
                return null;
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
