namespace MVC.Models
{
    public class StudentDTO
    {
        public int? StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public double Balance { get; set; } = 0;
        public int? UID { get; set; }
        public List<TransactionDTO>? TransactionList { get; set; }
    }
}
