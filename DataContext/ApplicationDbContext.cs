using gerenciamentoFuncionariosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoFuncionariosApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<CargoModel> Cargos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definindo as chave estrangeira (de cada classe)
            modelBuilder.Entity<FuncionarioModel>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<CargoModel>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Endereco>()
                .HasKey(o => o.Id);

            //relacionamento
            modelBuilder.Entity<CargoModel>()
                .HasMany(o => o.Funcionarios)
                .WithOne()
                .HasForeignKey(o => o.CargoId);

            modelBuilder.Entity<FuncionarioModel>()
                .HasOne(o => o.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(o => o.FuncionarioId);
        }
    }
}