using System.ComponentModel.DataAnnotations;

namespace MVCconBD2.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Título es obligatorio.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El Año de estreno es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime Anio { get; set; }

        [Required(ErrorMessage = "El Género es obligatorio.")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Debe ingresar la recaudación.")]
        public decimal Recaudacion { get; set; }

        // --- Mejoras añadidas (Estos los dejamos opcionales, sin [Required]) ---
        public string? Director { get; set; }
        public string? Sinopsis { get; set; }
    }
}