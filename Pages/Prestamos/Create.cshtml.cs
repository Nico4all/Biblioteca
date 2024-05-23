using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Pages.Prestamos
{
    public class CreateModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public CreateModel(BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prestamo Prestamo { get; set; }

        public SelectList Books { get; set; }
        public SelectList Users { get; set; }

        public IActionResult OnGet()
        {
            Books = new SelectList(_context.Books, "Id", "Titulo");
            Users = new SelectList(_context.Users, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Books = new SelectList(_context.Books, "Id", "Titulo");
                Users = new SelectList(_context.Users, "Id", "Name");
                return Page();
            }

            _context.Prestamos.Add(Prestamo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
