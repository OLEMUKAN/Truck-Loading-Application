using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

namespace Truck_Loading_Application.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public IndexModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        public IList<Report> Report { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Report = await _context.Reports
                .Include(r => r.CreatedByUser)
                .Include(r => r.Truck)
                .Include(r => r.UpdatedByUser).ToListAsync();
        }
    }
}
