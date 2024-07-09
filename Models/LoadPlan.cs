using System.ComponentModel.DataAnnotations;

namespace Truck_Loading_Application.Models
{
    public class LoadPlan
    {
        public Guid LoadPlanId { get; set; }

        public Guid TripId { get; set; }
        public Trip Trip { get; set; }

        public Guid TruckId { get; set; }
        public Truck Truck { get; set; }
        public List<CargoItem> AssignedItems { get; set; } = new List<CargoItem>();

        public float TotalWeight { get; set; }
        public float UsedCapacity { get; set; }

        public string LoadingInstructions { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PlannedLoadingTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ActualLoadingTime { get; set; }

        public LoadPlanStatus Status { get; set; }

        public void CalculateTotalWeight()
        {
            TotalWeight = AssignedItems.Sum(item => item.Weight * item.Quantity);
        }

        public void CalculateUsedCapacity()
        {
            // Assuming Truck.Capacity is in the same unit as TotalWeight
            UsedCapacity = (TotalWeight / float.Parse(Truck.Capacity)) * 100;
        }
    }

    public enum LoadPlanStatus
    {
        Planned,
        InProgress,
        Completed,
        Cancelled
    }


}
