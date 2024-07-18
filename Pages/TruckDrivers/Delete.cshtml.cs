using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.TruckDrivers
{
    public class DeleteModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public DeleteModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TruckDriver TruckDriver { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckdriver = await _context.TruckDrivers.FirstOrDefaultAsync(m => m.DriverId == id);

            if (truckdriver == null)
            {
                return NotFound();
            }
            else
            {
                TruckDriver = truckdriver;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckdriver = await _context.TruckDrivers.FindAsync(id);
            if (truckdriver != null)
            {
                TruckDriver = truckdriver;
                _context.TruckDrivers.Remove(TruckDriver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
