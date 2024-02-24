using ControleDeProdutos2024.Models;

namespace ControleDeProdutos2024.Repository
{
    public interface ILoginRepositorio
    {
        Task<List<LoginModel>> BuscarTodos();
        Task<LoginModel> Adicionar(LoginModel login);
        Task<LoginModel> Login(string email);
        Task<LoginModel> Login(string email, string senha);



    }
}
