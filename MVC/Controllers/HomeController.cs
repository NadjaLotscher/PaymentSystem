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

  

    public async Task<IActionResult> Index(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            // Handle the case when userId is null or empty
            return View();
        }
        var account = await _apiService.GetAccountBalanceAsync(userId);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddFunds(AddFundsRequest request)
    {
        var newBalance = await _apiService.AddFundsAsync(request);
        ViewBag.NewBalance = newBalance;
        return View();
    }
}
