using EcoEnergyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ContaLuzModel> ContasLuz { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<DispositivoModel> Dispositivos { get; set; }
    }
    

}
