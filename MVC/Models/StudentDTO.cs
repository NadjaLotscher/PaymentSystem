namespace PaymentSystem.MVC.Models
{
    public class StudentDTO
    {
        public int? StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string UID { get; set; }
        public decimal Balance { get; set; }
    }
}
