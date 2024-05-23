using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public IndexModel(BibliotecaContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users
                .Include(b => b.Rol) // Incluir datos del género
                .ToListAsync();
        }


    }
}
