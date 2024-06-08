using PaymentSystem.Models;
namespace MVC.Models
{
    public class AddFundsRequest
    {
        // public Account Account { get; set; }

        public Student Student { get; set; } 

        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
