using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class LibroAutorViewModel
    {
        public int LibroID { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un autor")]
        public int AutorID { get; set; }

        public Autor Autor { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        public IEnumerable<Autor> AutoresDisponibles { get; set; }
        public IEnumerable<Libro> LibrosDisponibles { get; set; }
    }
}
