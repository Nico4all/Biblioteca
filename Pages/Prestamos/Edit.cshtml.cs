using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Pages.Prestamos
{
    public class EditModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public EditModel(BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prestamo Prestamo { get; set; }

        public SelectList Users { get; set; }
        public SelectList Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prestamo = await _context.Prestamos
                                 .Include(b => b.User)
                                 .Include(b => b.Book)
                                 .FirstOrDefaultAsync(m => m.Id == id);

            if (Prestamo == null)
            {
                return NotFound();
            }

            Users = new SelectList(_context.Users, "Id", "Name");
            Books = new SelectList(_context.Books, "Id", "Titulo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Users = new SelectList(_context.Users, "Id", "Name");
                Books = new SelectList(_context.Books, "Id", "Titulo");
                return Page();
            }

            _context.Attach(Prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Prestamo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
