using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Backend.DBContext
{
    public class InventarioContext : DbContext
    {
        public InventarioContext()
        {

        }
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Localidad> Localidades { get; set; }

        //creamos el metodo onConfigurin para configurar la cadena de coneion a la base de datos postgreSQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configurar la cadena de conexión a PostgreSQL
                // string cadenaConexionLocal = "Host=localhost;Port=5432;Database=inventario;Username=postgres;Password=1234";
                //optionsBuilder.UseNpgsql(cadenaConexionLocal);
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                //string cadenaConexion = configuration.GetConnectionString("mysqlRemote");
                var cadenaConexion = configuration.GetConnectionString("postgreRemote");
            }
        }

        //creamos el metodo onModelCreating para insertar datos semillas en la tabla Clientes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Created_at = DateTime.Now, Firstname = "Juan", Lastname = "Perez", Dni = "12345678", Address = "Calle Falsa 123" },
                new Cliente { Id = 2, Created_at = DateTime.Now, Firstname = "Maria", Lastname = "Gomez", Dni = "87654321", Address = "Avenida Siempre Viva 456" },
                new Cliente { Id = 3, Firstname = "Pedro", Lastname = "López", Dni = "11223344", Address = "Callejón del Beso 789" }
            );

            //cargamos datos semilla para la tabla Localidades
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Id = 1, Name = "Buenos Aires"},
                new Localidad { Id = 2, Name = "Córdoba" },
                new Localidad { Id = 3, Name = "Rosario" },
                new Localidad { Id = 4, Name = "Mendoza" }
            );
            //configuramos la propiedad Created_at para que tenga un valor por defecto de la fecha y hora actual
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Created_at)
                .HasDefaultValueSql("NOW()");
            //configuramos los queries filters para que no se muestren los clientes y localidades eliminados 
            modelBuilder.Entity<Cliente>()
                .HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Localidad>()
                .HasQueryFilter(l => !l.IsDeleted);
        }

    }
}
