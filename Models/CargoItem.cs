using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models.enums;

namespace Truck_Loading_Application.Models
{
    public class CargoItem
    {
        [Key]
        public Guid ItemId { get; set; }
        public float Weight { get; set; }

        [EnumDataType(typeof(FragilityLevel))]
        public FragilityLevel Fragility { get; set; }

        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Dimensions { get; set; }
        public bool HazardousMaterial { get; set; }

        public Guid RequestId { get; set; } 
        public CargoRequest CargoRequest { get; set; }
    }
}
