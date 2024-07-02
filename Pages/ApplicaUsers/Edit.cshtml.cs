using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.ApplicaUsers
{
    public class EditModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public EditModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationuser =  await _context.ApplicationUser.FirstOrDefaultAsync(m => m.UserId == id);
            if (applicationuser == null)
            {
                return NotFound();
            }
            ApplicationUser = applicationuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(ApplicationUser.UserId))
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

        private bool ApplicationUserExists(int id)
        {
            return _context.ApplicationUser.Any(e => e.UserId == id);
        }
    }
}
