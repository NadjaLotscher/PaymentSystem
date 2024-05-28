using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.DAL.Models;
using System.Linq;
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

        [HttpGet("{userId}")]
        public async Task<ActionResult<Account>> GetBalance(string userId)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.Username == userId);
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
            account.Balance += request.Amount;
            await _context.SaveChangesAsync();
            return Ok(account.Balance);
        }
    }

    public class AddFundsRequest
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
