using ControleDeProdutos2024.Data;
using ControleDeProdutos2024.Models;
using Microsoft.EntityFrameworkCore;

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


        public async Task<LoginModel> Adicionar(LoginModel login)
        {
            await _bancoContext.Login.AddAsync(login);
            await _bancoContext.SaveChangesAsync();

            return await Task.FromResult(login);
        }

        public Task<List<LoginModel>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<LoginModel> Login(string email)
        {
            LoginModel login = new LoginModel();

            try
            {
                login = await _bancoContext.Login.FirstOrDefaultAsync(x => x.Email == email);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            return await Task.FromResult(login);
        }

        public Task<LoginModel> Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
