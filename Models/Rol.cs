using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set;}

        //llevar llave de rol a user
        public ICollection<User> Users { get; set; } = default!; // propiedad de navegacion 

    }
}
