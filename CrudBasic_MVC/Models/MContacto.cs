using System.ComponentModel.DataAnnotations;

namespace CrudBasic_MVC.Models
{
    public class MContacto
    {
        // 4 .- Definir las propiedades que nos permita  crear los campos
        // de la tabla contacto  en la base de datos.
        // [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "EL nombre del usuario es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La direccion del usuario es obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo del usuario es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono del usuario es obligatorio")]
        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }
       
    }
}
