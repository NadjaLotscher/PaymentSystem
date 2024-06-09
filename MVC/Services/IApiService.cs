using MVC.Models;
using PaymentSystem.MVC.DTO;


namespace MVC.Services

//interface for ApiService with all methods
{
    public interface IApiService
    {
        public Task<List<StudentDTO>> GetStudentDTOs();
        public Task<StudentDTO> PostStudentDTO(StudentDTO student);

        public Task<List<TransactionDTO>> GetTransactionDTOs(string username);
        public Task<TransactionDTO> PostTransactionDTO(TransactionDTO transaction);
    }
}


