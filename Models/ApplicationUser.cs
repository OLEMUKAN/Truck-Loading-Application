using System.ComponentModel.DataAnnotations;
using Truck_Loading_Application.Models.enums;


namespace Truck_Loading_Application.Models
{
    public class ApplicationUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole role { get; set; }

        public List<CargoRequest> CargoRequests { get; set; }
        public List<Report> Reports { get; set; }
    }
}
