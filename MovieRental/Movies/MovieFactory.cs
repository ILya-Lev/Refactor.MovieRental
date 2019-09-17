using MovieRental.TraitCalculator;

namespace MovieRental.Movies
{
    public class MovieFactory
    {
        public static IMovie Create(string title, MovieType type)
        {
            return new Movie(title, type, TraitCalculatorFactory.Create);
        }
    }
}