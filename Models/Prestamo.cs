using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime Inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fin { get; set; }

        //traer llaves de user
        public int UserId { get; set; }
        public User? User { get; set; }
        //traer llaves de Book
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
