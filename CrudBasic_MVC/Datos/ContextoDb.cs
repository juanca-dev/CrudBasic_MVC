using CrudBasic_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudBasic_MVC.Datos
{
    public class ContextoDb : DbContext
    {
        // 2 .- Creación de la clase ContextoDB
        // 3 .- Creación del constructor
        public ContextoDb(DbContextOptions<ContextoDb> opciones) : base (opciones)
        {
            
        }
        // Agregar los modelos que representan  las tablas en la base de datos

        // 5 .- Genaramos la instancia al modelo de Contacto.
        
       public DbSet<MContacto> MContacto { get; set; }
    }
}
