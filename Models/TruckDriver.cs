using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Truck_Loading_Application.Models
{
    public class TruckDriver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactInfo { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        public virtual List<Truck> Trucks { get; set; } = new List<Truck> { };

        public bool IsDeleted { get; set; } = false; // Soft delete
    }
}
