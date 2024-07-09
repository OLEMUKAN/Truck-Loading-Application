using System.ComponentModel.DataAnnotations;

namespace Truck_Loading_Application.Models
{
    public abstract class SoftDeleteEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}