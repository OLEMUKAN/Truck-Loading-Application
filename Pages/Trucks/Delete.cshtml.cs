using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.Trucks
{
    public class DeleteModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public DeleteModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Truck Truck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Truck.FirstOrDefaultAsync(m => m.TruckId == id);

            if (truck == null)
            {
                return NotFound();
            }
            else
            {
                Truck = truck;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Truck.FindAsync(id);
            if (truck != null)
            {
                Truck = truck;
                _context.Truck.Remove(Truck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
