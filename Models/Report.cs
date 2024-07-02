using System.ComponentModel.DataAnnotations;

namespace Truck_Loading_Application.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string TruckAssignments { get; set; }
        public string LoadingStatus { get; set; }
        public string TruckUtilization { get; set; }
        public string Format { get; set; }

        public int UserId { get; set; }
        public int TruckId { get; set; }

        public ApplicationUser User { get; set; }
        public Truck Truck { get; set; }
    }
    }

