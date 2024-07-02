using System.ComponentModel.DataAnnotations;

namespace Truck_Loading_Application.Models
{
    public class CargoRequest
    {
        [Key]
        public int RequestId { get; set; }
        public int ClientId { get; set; }
        public string TransportationNeeds { get; set; }
        public int Quantity { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PickupDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeliveryDateTime { get; set; }

        public string SpecialInstructions { get; set; }

        public ApplicationUser Client { get; set; }
        public List<CargoItem> CargoItems { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
