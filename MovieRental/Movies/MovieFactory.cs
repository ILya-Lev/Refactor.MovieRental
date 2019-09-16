using MovieRental.PointsCalculator;
using MovieRental.Prices;

namespace MovieRental.Movies
{
    public class MovieFactory
    {
        public static IMovie Create(string title, MovieType type)
        {
            return new Movie(title, type, PriceFactory.Create(type), RenterPointsCalculatorFactory.Create(type));
        }
    }
}