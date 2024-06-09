using MVC.Models;
using PaymentSystem.MVC.Models;

namespace MVC.Services

//interface for ApiService with all methods
{
    public interface IApiService
    {
        public Task<StudentDTO> PostStudentDTO(StudentDTO student);
        public Task<List<StudentDTO>> GetStudentDTOAsync();
        public Task DeleteStudentDTOAsync(int id);
        public Task<List<TransactionDTO>> GetTransactionDTOs(string username);
        public Task PostTransactionRequest(TransactionRequestDTO transactionRequest);
        Task PostPrintRequest(PrintRequestDTO printRequest);
    }
}


