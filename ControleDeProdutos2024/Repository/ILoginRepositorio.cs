using ControleDeProdutos2024.Models;

namespace ControleDeProdutos2024.Repository
{
    public interface ILoginRepositorio
    {
        List<LoginModel> BuscarTodos();
        LoginModel Adicionar(LoginModel login);
        LoginModel Login(string email);
        LoginModel Login(string email, string senha);



    }
}
