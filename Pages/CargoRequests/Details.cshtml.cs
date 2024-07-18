using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.CargoRequests
{
    public class DetailsModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public DetailsModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        public CargoRequest CargoRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargorequest = await _context.CargoRequests.FirstOrDefaultAsync(m => m.RequestId == id);
            if (cargorequest == null)
            {
                return NotFound();
            }
            else
            {
                CargoRequest = cargorequest;
            }
            return Page();
        }
    }
}
