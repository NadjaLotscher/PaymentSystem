using MVC.Models;

namespace MVC.Services

//interface for ApiService with all methods
{
    public interface IApiService
    {
        public Task<AddFundsRequest> GetAccountBalanceAsync(string userId);


    }
}


