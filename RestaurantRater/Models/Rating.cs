using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantRater.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [ForeignKey(nameof(RestaurantID))]
        public Restaurant? Restaurant { get; set; }

        [Required]
        [Range(0, 10)]
        public double FoodScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double EnvironmentScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double CleanlinessScore { get; set; }

        public double AverageRating
        {
            get
            {
                var totalScore = (FoodScore + EnvironmentScore + CleanlinessScore) / 3;
                return Math.Round(totalScore, 2);
            }
        }
    }
}