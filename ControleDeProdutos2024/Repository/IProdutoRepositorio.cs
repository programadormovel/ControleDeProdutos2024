using ControleDeProdutos2024.Models;

namespace ControleDeProdutos2024.Repository
{
    public interface IProdutoRepositorio
    {
        List<ProdutoModel> BuscarTodos();
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel ListarPorId(long id);
        ProdutoModel Atualizar(ProdutoModel produto);
        bool AtivarDesativar(long id);
        bool Apagar(long id);
    }
}
