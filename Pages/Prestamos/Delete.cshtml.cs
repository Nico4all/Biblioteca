using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Pages.Prestamos
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaContext _context;
        public DeleteModel(BibliotecaContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Prestamo Prestamo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prestamo = await _context.Prestamos.FirstOrDefaultAsync(m => m.Id == id);

            if (Prestamo == null)
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

            Prestamo = await _context.Prestamos.FindAsync(id);

            if (Prestamo != null)
            {
                _context.Prestamos.Remove(Prestamo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
