using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models;


namespace Truck_Loading_Application.Models
{
    public class CargoRequest
    {
        [Key]
        public Guid RequestId { get; set; }
        public Guid ClientId { get; set; }
        public string TransportationNeeds { get; set; }
        public int Quantity { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PickupDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeliveryDateTime { get; set; }

        public string SpecialInstructions { get; set; }

        // New properties
        public CargoRequestStatus Status { get; set; } = CargoRequestStatus.Pending;
        public float TotalWeight { get; set; }

        public ApplicationUser Client { get; set; }
        public virtual List<CargoItem> CargoItems { get; set; }
        public virtual List<Trip> Trips { get; set; }

        // Method to calculate total weight
        public void CalculateTotalWeight()
        {
            TotalWeight = CargoItems?.Sum(item => item.Weight * item.Quantity) ?? 0;
        }
    }

    public enum CargoRequestStatus
    {
        Pending,
        Approved,
        InTransit,
        Completed,
        Cancelled
    }
}