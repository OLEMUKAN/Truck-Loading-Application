using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models.enums;
using Truck_Loading_Application.Models;


namespace Truck_Loading_Application.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public Guid TruckId { get; set; }
        public Guid RouteId { get; set; }
        public Guid RequestId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PlannedStartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PlannedEndTime { get; set; }

        // New properties
        [DataType(DataType.DateTime)]
        public DateTime? ActualStartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ActualEndTime { get; set; }

        public TripStatus Status { get; set; }

        public int? Rating { get; set; }
        public string Feedback { get; set; }

        public Truck Truck { get; set; }
        public TruckRoute TruckRoute { get; set; }
        public CargoRequest CargoRequest { get; set; }
    }
}