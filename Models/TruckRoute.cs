using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models;


namespace Truck_Loading_Application.Models
{
    public class TruckRoute : AuditableEntity
    {
        [Key]
        public Guid RouteId { get; set; }
        public Guid TruckId { get; set; }
        public string TravelRoute { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostingTime { get; set; }

        public string EstimatedTravelTime { get; set; }
        public int EstimatedDistance { get; set; }

        // New properties
        public string ActualTravelTime { get; set; }
        public int? ActualDistance { get; set; }

        public Truck Truck { get; set; }
        public virtual List<Trip> Trips { get; set; } = new List<Trip>();
    }
}