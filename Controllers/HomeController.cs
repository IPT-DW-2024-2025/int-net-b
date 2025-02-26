using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aula1.Models;

namespace Aula1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Introducao()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Introducao(string num1, string num2, string op)
    {
        CalculadoraResponseModel response = new CalculadoraResponseModel();
        double aux1, aux2, resultado = 0;
        
        double.TryParse(num1, out aux1);
        double.TryParse(num2, out aux2);

        switch (op)
        {
            case "+":
                resultado = aux1 + aux2;
                break;
            
            case "-":
                resultado = aux1 - aux2;
                break;
            case "*":
                resultado = aux1 * aux2;
                break;
            case "/":
                if (aux2 == 0)
                {
                    ViewBag.erro = "Não pode dividir por zero (0)";
                }
                else
                {
                    resultado = aux1 / aux2;    
                }
                
                
                break;
            
            default:
                return BadRequest();
                break;    
        }
        
        response.resultado = resultado.ToString();
        response.descricaoOperacao = num1 + " "+op+" "+num2;
        return View(response);
    }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}