using ControleDeProdutos2024.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos2024.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {
        
        }

        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<LoginModel> Login { get; set; }

    }
}
