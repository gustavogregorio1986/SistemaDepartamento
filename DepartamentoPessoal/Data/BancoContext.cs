using DepartamentoPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartamentoPessoal.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<PessoaModel> Pessoas { get; set; }
    }
}
