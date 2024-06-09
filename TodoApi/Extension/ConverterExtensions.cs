using WebApi.DTO;

namespace WebApi.Extension
{
    public static class ConverterExtensions
    {
        
    public static PaymentSystem.Models.Student ToDAL(this WebApi.DTO.StudentDTO studentDTO)
        {
            return new PaymentSystem.Models.Student
            {
                Firstname = studentDTO.Firstname,
                Lastname = studentDTO.Lastname,
                Username = studentDTO.Username,
                Balance = studentDTO.Balance,
                UID = studentDTO.UID,

            };
        }
         
        public static WebApi.DTO.StudentDTO ToModel(this PaymentSystem.Models.Student student)
        {
            return new WebApi.DTO.StudentDTO
            {
                StudentId = student.StudentId,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Username = student.Username,
                Balance = student.Balance,
                UID = student.UID,
            };
        }

        public static PaymentSystem.Models.Transaction ToDAL(this WebApi.DTO.TransactionDTO transactionDTO)
        {
            return new PaymentSystem.Models.Transaction
            {

                StudentId = transactionDTO.Student.StudentId,
                Amount = transactionDTO.Amount,
                TransactionDate = transactionDTO.TransactionDate

            };
        }

        public static WebApi.DTO.TransactionDTO ToModel(this PaymentSystem.Models.Transaction transaction)
        {
            return new WebApi.DTO.TransactionDTO
            {
                TransactionId = transaction.TransactionId,
                StudentId = transaction.Student.StudentId,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate
            };
        }

    }
}