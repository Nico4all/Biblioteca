using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //traer llave de ROl
        public int RolID { get; set; }
        public Rol? Rol { get; set; }

        //llevar llave a prestamo
        public ICollection<Prestamo>? Prestamos { get; set; } = default!; // propiedad de navegacion
    }
}
