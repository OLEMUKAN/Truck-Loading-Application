using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.TruckRoutes
{
    public class CreateModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public CreateModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CreatedByUserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        ViewData["TruckId"] = new SelectList(_context.Trucks, "TruckId", "RegistrationNumber");
        ViewData["UpdatedByUserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public TruckRoute TruckRoute { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TruckRoutes.Add(TruckRoute);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
