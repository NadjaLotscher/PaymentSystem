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

    public async Task<IActionResult> Index()
    {
        try
        {
            var students = await _apiService.GetStudentDTOAsync();
            return View(students);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Error loading students: " + ex.Message;
            return View(new List<StudentDTO>());
        }
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

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _apiService.DeleteStudentDTOAsync(id);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
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
