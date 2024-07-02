using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Truck_Loading_Application.Models.enums;

namespace Truck_Loading_Application.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public int TruckId { get; set; }
        public int RouteId { get; set; }
        public int RequestId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public TripStatus Status { get; set; }

        public Truck Truck { get; set; }
        public TruckRoute TruckRoute { get; set; }
        public CargoRequest CargoRequest { get; set; }

    }
}
