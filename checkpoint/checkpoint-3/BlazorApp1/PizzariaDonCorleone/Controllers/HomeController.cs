using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzariaDonCorleone.Models;

namespace PizzariaDonCorleone.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza(
                "Pizza Margherita",
                35.00m,
                "https://s2-receitas.glbimg.com/wb7DIMyCpEyV07sTAtcDWD8HQjw=/0x0:1200x675/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_1f540e0b94d8437dbbc39d567a1dee68/internal_photos/bs/2024/h/r/EfCbvqTbeDRAD3Lzc5xA/pizza-margherita.jpg"
            ),
            new Pizza
            (
                "Pizza Pepperoni",
                40.00m,
                "https://assets-us-01.kc-usercontent.com/4353bced-f940-00d0-8c6e-13a0a4a7f5c2/2ac60829-5178-4a6e-80cf-6ca43d862cee/Quick-and-Easy-Pepperoni-Pizza-700x700.jpeg?w=1280&auto=format"
            )
        };
        return View(pizzas);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}