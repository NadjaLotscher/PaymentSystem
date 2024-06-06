using MVC.Models;

namespace MVC.Services

//interface for ApiService with all methods
{
    public interface IApiService
    {
       // public Task<AddFundsRequest> GetAccountBalanceAsync(string userId);
        
        public Task<List<AccountDTO>> GetAccountDTOs();
        public Task<AccountDTO> GetAccountDTO(int StudentId);
        public Task<AccountDTO> AddAccountDTO(AccountDTO account);
        public Task<AccountDTO> UpdateAccountDTO(AccountDTO account);

        public Task<StudentDTO> AddStudentDTO(StudentDTO student);

        public Task<List<TransactionDTO>> GetTransactionDTOs(int StudentId);
        public Task<TransactionDTO> AddtransactionDTO(TransactionDTO transaction);


    }
}


