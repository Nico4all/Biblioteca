using Biblioteca.Models;
using Biblioteca.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Pages.Books
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public IndexModel(BibliotecaContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get; set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Books
                .Include(b => b.Genero) // Incluir datos del género
                .ToListAsync();
        }
    }
}
