using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.CargoItems
{
    public class DeleteModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public DeleteModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CargoItem CargoItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoitem = await _context.CargoItem.FirstOrDefaultAsync(m => m.ItemId == id);

            if (cargoitem == null)
            {
                return NotFound();
            }
            else
            {
                CargoItem = cargoitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoitem = await _context.CargoItem.FindAsync(id);
            if (cargoitem != null)
            {
                CargoItem = cargoitem;
                _context.CargoItem.Remove(CargoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
