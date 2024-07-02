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

namespace Truck_Loading_Application.Pages.Reports
{
    public class EditModel : PageModel
    {
        private readonly Truck_Loading_Application.Data.Truck_Loading_ApplicationContext _context;

        public EditModel(Truck_Loading_Application.Data.Truck_Loading_ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Report Report { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report =  await _context.Report.FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }
            Report = report;
           ViewData["TruckId"] = new SelectList(_context.Set<Truck>(), "TruckId", "RegistrationNumber");
           ViewData["UserId"] = new SelectList(_context.ApplicationUser, "UserId", "Email");
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

            _context.Attach(Report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(Report.ReportId))
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

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.ReportId == id);
        }
    }
}
