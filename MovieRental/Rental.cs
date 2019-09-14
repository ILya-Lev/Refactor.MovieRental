using MovieRental.Movies;

namespace MovieRental
{
    public class Rental
    {
        public IMovie Movie { get; }
        public int DaysRented { get; }

        public Rental(IMovie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }
    }
}