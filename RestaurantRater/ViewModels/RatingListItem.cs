namespace RestaurantRater.ViewModels
{
    public class RatingListItem
    {
        public int ID { get; set; }

        public string RestaurantName { get; set; } = string.Empty;

        public double FoodScore { get; set; }

        public double EnvironmentScore { get; set; }

        public double CleanlinessScore { get; set; }
    }
}