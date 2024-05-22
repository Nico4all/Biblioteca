using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Genero
    {

        public int Id { get; set; }
        public string Description { get; set; }

        //llevar llave de genero a libros 
        public ICollection<Book>? Books { get; set; } = default!;// propiedad de navegacion 
    }
}

