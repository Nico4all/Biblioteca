using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
namespace Biblioteca.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ano { get; set; }

        //TRAER LLAVE DE GENERO
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }

        //LLEVAR LLAVE A PERSTAMO
        public ICollection<Prestamo>? Prestamos { get; set; } = default!; // propiedad de navegacion


    }
}
