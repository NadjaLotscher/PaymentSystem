namespace WebApi.Models
{
    public class TransactionValue
    {
        public int Id { get; set; }
        public List<TransactionDTO> TransactionDTOs { get; set; }
    }
}
