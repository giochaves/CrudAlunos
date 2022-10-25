using Microsoft.EntityFrameworkCore;
using RegistroAlunos.Models;

namespace RegistroAlunos.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    public DbSet<AlunoModel> Alunos { get; set; }


}
