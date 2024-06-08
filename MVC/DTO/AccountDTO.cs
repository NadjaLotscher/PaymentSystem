namespace PaymentSystem.MVC.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public int StudentId { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public decimal NumberOfCopies { get; set; }
    }
}
