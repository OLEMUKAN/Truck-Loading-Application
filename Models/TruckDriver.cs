using System.ComponentModel.DataAnnotations;


namespace Truck_Loading_Application.Models
{
    public class TruckDriver : SoftDeleteEntity
    {
        [Key]
        public Guid DriverId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactInfo { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        // New properties
        public string LicenseNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime LicenseExpiryDate { get; set; }

        public DriverAvailabilityStatus AvailabilityStatus { get; set; } = DriverAvailabilityStatus.Available;

        public virtual List<Truck> Trucks { get; set; } = new List<Truck>();
    }

    public enum DriverAvailabilityStatus
    {
        Available,
        OnDuty,
        OnBreak,
        OnLeave
    }
}