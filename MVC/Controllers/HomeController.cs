using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;
using System.Threading.Tasks;
using MVC.Models;
using MVC.Services;

public class HomeController : Controller
{
    private readonly ApiService _apiService;

    public HomeController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        //HttpContext.Session.SetString("UserId", "abcdef");
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddStudent()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(StudentDTO student)
    {
        if (!ModelState.IsValid)
        {
            await _apiService.PostStudentDTO(student);
            return RedirectToAction("Index");
     
        }
        return View(student);


    }
}



