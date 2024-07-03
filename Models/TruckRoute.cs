using System.ComponentModel.DataAnnotations;

namespace Truck_Loading_Application.Models
{
    public class TruckRoute
    {
        [Key]
        public int RouteId { get; set; }
        public int TruckId { get; set; }
        public string TravelRoute { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostingTime { get; set; }

        public string EstimatedTravelTime { get; set; }
        public int Distance { get; set; }

        public Truck Truck { get; set; }
        public virtual List<Trip> Trips { get; set; } = new List<Trip> { };
    }
}

