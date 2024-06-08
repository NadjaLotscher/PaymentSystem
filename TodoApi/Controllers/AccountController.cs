using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.DAL.Models;
using PaymentSystem.Models;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SystemContext _context;

        public AccountController(SystemContext context)
        {
            _context = context;
        }

        [HttpGet("{Username}")]
        public async Task<ActionResult<Account>> GetBalance(string username)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.Username == username);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        [HttpPost("addFunds")]
        public async Task<IActionResult> AddFunds([FromBody] AddFundsRequest request)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.Username == request.UserId);
            if (account == null)
            {
                return NotFound();
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                account.Balance += request.Amount;
                _context.Transactions.Add(new Transaction
                {
                    StudentId = account.StudentId,
                    Amount = request.Amount,
                    TransactionType = "Credit",
                    TransactionDate = DateTime.Now,
                    Status = "Success"
                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(account.Balance);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while adding funds.");
            }
        }
    }

    public class AddFundsRequest
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
