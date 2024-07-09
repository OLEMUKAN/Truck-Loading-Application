using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Truck_Loading_Application.Models;


namespace Truck_Loading_Application.Models
{

    public class Report : AuditableEntity
    {
        [Key]
        public Guid ReportId { get; set; }
        public ReportType Type { get; set; }
        public string Content { get; set; } // Store as JSON
        public string Format { get; set; }

        public Guid? TruckId { get; set; }

        [ForeignKey("TruckId")]
        public virtual Truck Truck { get; set; }
    }

    public enum ReportType
    {
        TruckAssignments,
        LoadingStatus,
        TruckUtilization,
        PerformanceAnalysis
    }
}