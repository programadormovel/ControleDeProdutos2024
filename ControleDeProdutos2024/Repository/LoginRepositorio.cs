using ControleDeProdutos2024.Data;
using ControleDeProdutos2024.Models;

namespace ControleDeProdutos2024.Repository
{
    public class LoginRepositorio : ILoginRepositorio
    {
        // Injeção de dependência
        private readonly BancoContext _bancoContext;

        // Construtor - método que possui o mesmo nome da classe
        public LoginRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public LoginModel Adicionar(LoginModel login)
        {
            _bancoContext.Login.Add(login);
            _bancoContext.SaveChanges();
            return login;
        }

        public List<LoginModel> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public LoginModel Login(string email)
        {
            throw new NotImplementedException();
        }

        public LoginModel Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
