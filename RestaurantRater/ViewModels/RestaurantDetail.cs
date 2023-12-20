namespace RestaurantRater.ViewModels
{
    public class RestaurantDetail
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double OverallScore { get; set; }
        public double FoodRating { get; set; }
        public double CleanlinessRating { get; set; }
        public double EnvironmentRating { get; set; }
        public bool IsRecommended { get; set; }
    }
}