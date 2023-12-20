using System.ComponentModel.DataAnnotations;

namespace RestaurantRater.ViewModels
{
    public class RatingEdit
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Value can only be from 0.0 to 10.0")]
        public double FoodScore { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Value can only be from 0.0 to 10.0")]
        public double EnvironmentScore { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Value can only be from 0.0 to 10.0")]
        public double CleanlinessScore { get; set; }
    }
}