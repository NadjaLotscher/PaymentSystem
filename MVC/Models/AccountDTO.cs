using PaymentSystem.Models;

namespace MVC.Models
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public Boolean IsActive { get; set; }
        public decimal NumberOfCopies { get; set; }

    }
}
