﻿namespace PaymentSystem.MVC.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int StudentId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
