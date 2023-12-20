using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.ViewModels
{
    public class RestaurantEdit
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150, ErrorMessage = "Address cannot exceed 150 characters")]
        public string Address { get; set; } = string.Empty;
    }
}