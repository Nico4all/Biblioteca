using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using System.Threading.Tasks;

namespace Biblioteca.Pages.Generos
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public DeleteModel(BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Genero Genero { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genero = await _context.Generos.FirstOrDefaultAsync(m => m.Id == id);

            if (Genero == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genero = await _context.Generos.FindAsync(id);

            if (Genero != null)
            {
                _context.Generos.Remove(Genero);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
