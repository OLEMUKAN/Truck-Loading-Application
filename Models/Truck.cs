using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models.enums;

namespace Truck_Loading_Application.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        [EnumDataType(typeof(TruckType))]
        public TruckType Type { get; set; }
        public string AxleLoad { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        public string EmptyWeight { get; set; }
        public string MaxLoadWeight { get; set; }
        public string Size { get; set; }
        public string Capacity { get; set; }
        public bool Availability { get; set; }
        public string CurrentLocation { get; set; }

        [EnumDataType(typeof(MaintenanceStatus))]
        public MaintenanceStatus MaintenanceStatus { get; set; }

        public int DriverId { get; set; }
        public TruckDriver Driver { get; set; }
        public virtual List<TruckRoute> TruckRoutes { get; set; }
        public virtual List<Trip> Trips { get; set; } = new List<Trip> { };
        public virtual List<Report> Reports { get; set; } = new List<Report> { };

        public bool IsDeleted { get; set; } = false; // Soft delete
    }
}
