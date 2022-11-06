using  Academia.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Models
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Treino> Treino { get; set; }
        public DbSet<Exercicio> Exercicio{ get; set; }

          public DbSet<Aula> Aula{ get; set; }

         public DbSet<Aparelho> Aparelhos{ get; set; }

         public DbSet<Academia.Models.TreinoExercicio> TreinoExercicio { get; set; }

    }
}