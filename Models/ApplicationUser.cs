using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models.enums;


namespace Truck_Loading_Application.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {

        [Required]
        public string Name { get; set; }

        public UserRole Role { get; set; }

        public virtual List<CargoRequest> CargoRequests { get; set; } = new List<CargoRequest>();

        public virtual List<Report> CreatedReports { get; set; } = new List<Report>();
        public virtual List<Report> UpdatedReports { get; set; } = new List<Report>();
    }
}
