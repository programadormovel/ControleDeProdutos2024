using ControleDeProdutos2024.Models;
using ControleDeProdutos2024.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeProdutos2024.Controllers
{
    public class LoginController : Controller
    {
        // Injeção de Dependência - ILoginRepositorio (interface)
        private readonly ILoginRepositorio _loginRepositorio;

        // Construtor
        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(LoginModel login)
        {
            return View();
        }

    }
}
