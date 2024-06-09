namespace WebApi.Models
{
    public class TransactionRequestDTO
    {
        public string Username { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
