using ControleDeProdutos2024.Data;
using ControleDeProdutos2024.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos2024.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;    

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            // inserir produto no banco de dados
            _bancoContext.Produto.Add(produto);
            _bancoContext.SaveChanges();  
            
            return produto;
        }

        public bool Apagar(long id)
        {
            throw new NotImplementedException();
        }

        public bool AtivarDesativar(long id)
        {
            throw new NotImplementedException();
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produto.ToList();
        }

        public ProdutoModel ListarPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
