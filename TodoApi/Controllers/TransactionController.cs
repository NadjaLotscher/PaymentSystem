using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            try
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTransactions), new { studentId = transaction.StudentId }, transaction);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the transaction.");
            }
        }
    }
}
