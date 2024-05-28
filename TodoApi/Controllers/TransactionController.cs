using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.DAL;
using PaymentSystem.DAL.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PaymentSystem;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly SystemContext _context;

        public TransactionController(SystemContext context)
        {
            _context = context;
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int studentId)
        {
            var transactions = await _context.Transactions.Where(t => t.StudentId == studentId).ToListAsync();
            if (!transactions.Any())
            {
                return NotFound();
            }
            return transactions;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransactions), new { studentId = transaction.StudentId }, transaction);
        }
    }
}
