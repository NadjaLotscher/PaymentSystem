using PaymentSystem.Models;
using System.Transactions;

namespace WebApi.Extension
{
    public static class ConverterExtensions
    {
        public static PaymentSystem.Models.Student ToDAL(this WebApi.Models.StudentDTO studentDTO)
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

        public static WebApi.Models.StudentDTO ToModel(this PaymentSystem.Models.Student student)
        {
            return new WebApi.Models.StudentDTO
            {
                StudentId = student.StudentId,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Username = student.Username,
                Balance = student.Balance,
                UID = student.UID,
                
            };
        }


        public static PaymentSystem.Models.Transaction ToDAL(this WebApi.Models.TransactionDTO transactionDTO)
        {
            return new PaymentSystem.Models.Transaction
            {
          
                StudentId = transactionDTO.Student.StudentId,
                Amount = transactionDTO.Amount,
                TransactionType = transactionDTO.TransactionType,
                TransactionDate = transactionDTO.TransactionDate

            };
        }

        public static WebApi.Models.TransactionDTO ToModel(this PaymentSystem.Models.Transaction transaction)
        {
            return new WebApi.Models.TransactionDTO
            {
                TransactionId = transaction.TransactionId,
                StudentId = transaction.Student.StudentId,
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType,
                TransactionDate = transaction.TransactionDate
            };
        }



    }
}