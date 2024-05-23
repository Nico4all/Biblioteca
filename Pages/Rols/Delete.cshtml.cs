using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using System.Threading.Tasks;

namespace Biblioteca.Pages.Rols
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public DeleteModel(BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rol Rol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rol = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (Rol == null)
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

            Rol = await _context.Roles.FindAsync(id);

            if (Rol != null)
            {
                _context.Roles.Remove(Rol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
