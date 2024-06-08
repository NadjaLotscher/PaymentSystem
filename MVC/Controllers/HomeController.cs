using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;
using System.Threading.Tasks;
using PaymentSystem.MVC.DTO;

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
}
