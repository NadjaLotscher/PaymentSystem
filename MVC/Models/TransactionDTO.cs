using PaymentSystem.Models;

namespace MVC.Models
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } //either Payment or 
        public DateTime TransactionDate { get; set; }
    }
}
