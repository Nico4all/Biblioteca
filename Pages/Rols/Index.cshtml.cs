using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Pages.Rols
{
    public class IndexModel : PageModel
    {
        private readonly BibliotecaContext _context;
        public IndexModel(BibliotecaContext context)
        {
            _context = context;
        }
        public List<Rol> Roles { get; set; }

        public async Task OngetAsync()
        {
            Roles = await _context.Roles.ToListAsync();
        }
    }
}
