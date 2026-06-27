using System.ComponentModel.DataAnnotations;

namespace MVCconBD2.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        public string? Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Anio { get; set; }

        public string? Genero { get; set; }

        public decimal Recaudacion { get; set; }

        // --- Mejoras añadidas a la Base de Datos ---
        public string? Director { get; set; }
        public string? Sinopsis { get; set; }
    }
}