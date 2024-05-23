using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Pages.Prestamos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public IndexModel(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Prestamo> Prestamos { get; set; }

        public async Task OnGetAsync()
        {
            Prestamos = await _context.Prestamos
                .Include(b => b.Book) // Incluir datos del Libro
                .Include(b => b.User) // Incluir datos del Usuario
                .ToListAsync();
        }
    }
}