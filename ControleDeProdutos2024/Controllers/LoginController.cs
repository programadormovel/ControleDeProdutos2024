using ControleDeProdutos2024.Models;
using ControleDeProdutos2024.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeProdutos2024.Controllers
{
    public class LoginController : Controller
    {
        public const string SessionKeyUser = "_Usuario";
        public const string SessionKeyEmail = "_Email";
        public const string SessionKeyNivel = "_Nivel";
        public const string SessionKeyId = "_Id";

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
            LoginModel login = new LoginModel();

            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Index(string email, string senha)
        {
            LoginModel login = await _loginRepositorio.Login(email);
            var sucesso = false;

            if(senha != null && login != null)
            {
                sucesso = Util.Decriptografia(login, senha);
            }
            else
            {
                return await Task.FromResult(View());
            }

            if (sucesso)
            {
                HttpContext.Session.SetString(SessionKeyUser, login.Usuario);
                HttpContext.Session.SetString(SessionKeyEmail, login.Email);
                HttpContext.Session.SetInt32(SessionKeyNivel, login.NivelAcesso);
                HttpContext.Session.SetInt32(SessionKeyId, (int) login.Id);

            } else
            {
                return await Task.FromResult(View());
            }
           
            return await Task.FromResult(RedirectToAction("Index", "Produto"));

        } 

        [HttpPost]
        public async Task<IActionResult> Registro(LoginModel login, string? senha)
        {
            // verificar regras de senha
            login.Senha = Util.Criptografia(senha!);

            login.NivelAcesso = 1;
            login.DataDeRegistro = DateTime.Now;
            login.Ativo = 1;
            login.EmailConfirmacao = false;
            login.TelefoneConfirmacao = false;

            await _loginRepositorio.Adicionar(login);

            return await Task.FromResult(RedirectToAction("Index", "Login"));
        }

    }
}
