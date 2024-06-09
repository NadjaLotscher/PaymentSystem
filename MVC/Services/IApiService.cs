using MVC.Models;
using PaymentSystem.MVC.Models;

namespace MVC.Services

//interface for ApiService with all methods
{
    public interface IApiService
    {
        // public Task<AddFundsRequest> GetAccountBalanceAsync(string userId);


        public Task<StudentDTO> PostStudentDTO(StudentDTO student);
        public Task<List<StudentDTO>> GetStudentDTOAsync();
        public Task<List<TransactionDTO>> GetTransactionDTOs(string username);
        public Task<TransactionDTO> PostTransactionDTO(TransactionDTO transaction);


    }
}


