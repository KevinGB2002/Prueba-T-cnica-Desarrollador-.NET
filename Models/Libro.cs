using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Libro
    {
        public int ID { get; set; }

        public required string Titulo { get; set; }

        public int? AutorID { get; set; }

        public Autor? Autor { get; set; }
    }
}
