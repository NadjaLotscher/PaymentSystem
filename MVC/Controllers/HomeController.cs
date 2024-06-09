using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;
using PaymentSystem.MVC.Models;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly IApiService _apiService;

    public HomeController(IApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddStudent()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(StudentDTO student)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _apiService.PostStudentDTO(student);
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }
        }
        return View(student);
    }

    [HttpGet]
    public IActionResult AddTransaction()
    {
        return View("AddMoney");
    }

    [HttpPost]
    public async Task<IActionResult> AddTransactionRequest(TransactionRequestDTO transactionRequest)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _apiService.PostTransactionRequest(transactionRequest);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }
        }
        return View("AddMoney", transactionRequest);
    }


    /*
    [HttpGet]
    public IActionResult addTransaction() { return View(); }

    [HttpPost]
    public async Task<IActionResult> addTransaction(TransactionDTO transaction)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _apiService.PostTransactionDTO(transaction);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }

        }
        return View(transaction);
    }
    */
}
