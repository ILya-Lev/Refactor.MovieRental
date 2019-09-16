using MovieRental.PointsCalculator;
using MovieRental.Prices;

namespace MovieRental.Movies
{
    internal class Movie : IMovie
    {
        private readonly IPrice _price;
        private readonly IRenterPointsCalculator _points;
        public string Title { get; }
        public MovieType MovieType { get; set; }

        public Movie(string title, MovieType movieType, IPrice price, IRenterPointsCalculator points)
        {
            _price = price;
            _points = points;

            Title = title;
            MovieType = movieType;
        }

        public double GetPayment(int daysRented) => _price.GetPayment(daysRented);

        public int GetRenterPoints(int daysRented) => _points.GetRenterPoints(daysRented);
    }
}
