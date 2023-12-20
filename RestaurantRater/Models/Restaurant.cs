namespace RestaurantRater.Models
{
    public class Restaurant
    {
         public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var Rating in Ratings)
                {
                    totalAverageRating += Rating.AverageRating;
                }

                var result = (Ratings.Count > 0)
                             ? totalAverageRating / Ratings.Count
                             : 0;

                return Math.Round(result, 2);
            }
        }

        public double FoodRating
        {
            get
            {
                var totalFoodRating = (Ratings.Count() > 0)
                                    ? Ratings.Sum(r => r.FoodScore) / Ratings.Count()
                                    : 0;
                return Math.Round(totalFoodRating, 2);
            }
        }

        public double CleanlinessRating
        {
            get
            {
                var totalCleanlinessRating = (Ratings.Count() > 0)
                                    ? Ratings.Sum(r => r.CleanlinessScore) / Ratings.Count()
                                    : 0;
                return Math.Round(totalCleanlinessRating, 2);
            }
        }

        public double EnvironmentRating
        {
            get
            {
                var totalEnvironmentRating = (Ratings.Count() > 0)
                                    ? Ratings.Sum(r => r.EnvironmentScore) / Ratings.Count()
                                    : 0;
                return Math.Round(totalEnvironmentRating, 2);
            }
        }

        public bool IsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }

    }
}