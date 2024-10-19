using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Autor
    {
        public int AutorID { get; set; }  // Clave primaria
        public required string Nombre { get; set; }  // Nombre del autor
        public ICollection<Libro>? Libros { get; set; } // Relación inversa
    }
}
