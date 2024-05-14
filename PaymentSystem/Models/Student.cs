using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        // public float Balance { get; set; } /* is in account now */
        //public string Password { get; set; } /* Goal, but is not needed */
        //public string Class {  get; set; } /* Goal, but also not needed (if i want to add money to all people of one class */
    }
}
