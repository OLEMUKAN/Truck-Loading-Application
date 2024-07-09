using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Truck_Loading_Application.Models
{
    public abstract class AuditableEntity : SoftDeleteEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("CreatedByUser")]
        public Guid CreatedByUserId { get; set; }

        [ForeignKey("UpdatedByUser")]
        public Guid? UpdatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }
    }

}