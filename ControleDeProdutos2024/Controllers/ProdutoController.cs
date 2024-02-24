using ControleDeProdutos2024.Models;
using ControleDeProdutos2024.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace ControleDeProdutos2024.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IWebHostEnvironment Environment;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, 
            IWebHostEnvironment _environment) 
        { 
            _produtoRepositorio = produtoRepositorio;   
            Environment = _environment;
        }

        public IActionResult Index()
        {
            // buscar produtos no banco de dados
            List<ProdutoModel> listagem = _produtoRepositorio.BuscarTodos();

            return View(listagem);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto, IFormFile? imagemCarregada)
        {
            // Validar o objeto produto
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(produto, null, null);

            bool isValid = Validator.TryValidateObject(produto, context, results, true);

            if (!isValid)
            {
                foreach(var validationResult in results) {
                    return View(produto);
                }
            }

            // Carregamento de imagem
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.GetFileName(imagemCarregada!.FileName);

            var caminhoCompleto = Path.Combine(path, fileName);

            using (FileStream stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                imagemCarregada.CopyTo(stream);
                produto.NomeDaFoto = caminhoCompleto;
            }

            produto.Foto = Util.ReadFully2(caminhoCompleto);
            produto.DataDeRegistro = DateTime.Now;

            // solicitar cadastrdo do produto
            _produtoRepositorio.Adicionar(produto);

            return RedirectToAction("Index");
        }
    }
}
