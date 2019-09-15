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

        private double? _charge = null;
        public double Charge => _charge ?? (_charge = Movie.GetPayment(DaysRented)).Value;

        private int? _points = null;
        public int Points => _points ?? (_points = Movie.GetRenterPoints(DaysRented)).Value;
    }
}