using Microsoft.EntityFrameworkCore;
using ServerCatalogStudio.Api.Auth;
using ServerCatalogStudio.Api.Maestros.SistemasOperativos;
using System.Configuration;
namespace ServerCatalogStudio.Api.Infraestructure
{
    public class CatalogoContext : DbContext
    {

        private string _stringConnection;
        public CatalogoContext(string stringConnection = "")
        {
            _stringConnection = stringConnection;
        }

        public DbSet<SistemaOperativo> SistemasOperativos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(_stringConnection))
            {
                _stringConnection = "Server=DESKTOP-DAD17PU;Database=CatalogoDeServidores;Trusted_Connection=True";
            }
            optionsBuilder.UseSqlServer(_stringConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
