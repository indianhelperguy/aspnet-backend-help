using aspnet_backend_help.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_backend_help
{
    public class DatabaseContext : DbContext
    {
        public DbSet<VizsgazoModel> Vizsgazok { get; set; }
        public DbSet<VizsgatipusModel> Vizsgatipusok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=ecdl;Uid=root;Pwd=;", ServerVersion.AutoDetect("Server=localhost;Database=ecdl;Uid=root;Pwd=;"));
        }
    }
}
