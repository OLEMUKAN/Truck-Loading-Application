using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.LoadPlans
{
    public class IndexModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public IndexModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        public IList<LoadPlan> LoadPlan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LoadPlan = await _context.LoadPlans
                .Include(l => l.Trip)
                .Include(l => l.Truck).ToListAsync();
        }
    }
}
