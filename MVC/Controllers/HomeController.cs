using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;
using System.Threading.Tasks;
using MVC.Models;

public class HomeController : Controller
{
    private readonly ApiService _apiService;

    public HomeController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var account = await _apiService.GetAccountBalanceAsync("someUserId");
        return View(account);
    }

    [HttpPost]
    public async Task<IActionResult> AddFunds(AddFundsRequest request)
    {
        var newBalance = await _apiService.AddFundsAsync(request);
        ViewBag.NewBalance = newBalance;
        return View();
    }
}
