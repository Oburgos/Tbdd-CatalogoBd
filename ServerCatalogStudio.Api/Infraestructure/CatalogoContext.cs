using Microsoft.EntityFrameworkCore;
using ServerCatalogStudio.Api.Auth;
using ServerCatalogStudio.Api.Maestros.Ambientes;
using ServerCatalogStudio.Api.Maestros.MotoresDeBasesDeDatos;
using ServerCatalogStudio.Api.Maestros.SistemasOperativos;
using ServerCatalogStudio.Api.Servidores;

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
        public DbSet<MotorBaseDeDatos> MotoresDeBasesDeDatos { get; set; }
        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<ServidorConfiguracion> ServidoresConfiguraciones { get; set; }



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
            modelBuilder.Entity<MotorBaseDeDatos>()
                .ToTable("Servidores_MotoresBasesDeDatos")
                .HasKey(x => x.Id);

            modelBuilder.Entity<SistemaOperativo>()
                .ToTable("SistemaSOperativos")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Ambiente>()
                .ToTable("Ambientes")
                .HasKey(x => x.Id);

            var config = modelBuilder.Entity<ServidorConfiguracion>();
            config.ToTable("Servidores_Configuraciones_MotorBaseDeDatos")
            .HasKey(x => x.Id);

            var serv = modelBuilder.Entity<Servidor>();
            serv.ToTable("Servidores")
               .HasKey(x => x.Id);
            serv.HasOne(p => p.configuracion).WithMany(p => p.Servidores).HasForeignKey(x => x.ConfiguracionId);

            serv.Property(x => x.Descripcion).HasColumnName("Nombre");
            serv.Property(x => x.Cores).HasColumnName("Procesadores");
            serv.Property(x => x.Ram).HasColumnName("Memoria");
            serv.Property(x => x.ConfiguracionId).HasColumnName("Servidor_MotorBaseDeDatosConfiguracionId");
            serv.HasOne(p => p.SistemaOperativo).WithMany(p => p.Servidores).HasForeignKey(x => x.SistemaOperativoId);
            serv.HasOne(p => p.Ambiente).WithMany(p => p.Servidores).HasForeignKey(x => x.AmbienteId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
