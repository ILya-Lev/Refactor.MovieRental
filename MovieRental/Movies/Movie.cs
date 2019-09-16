using MovieRental.PointsCalculator;
using MovieRental.Prices;
using System;

namespace MovieRental.Movies
{
    internal class Movie : IMovie
    {
        private readonly Func<MovieType, IPrice> _priceFactory;
        private readonly Func<MovieType, IRenterPointsCalculator> _pointsFactory;
        public string Title { get; }

        private IPrice _price;
        private IRenterPointsCalculator _points;
        private MovieType? _movieType = null;
        public MovieType MovieType
        {
            get => _movieType.Value;
            set
            {
                if (value != _movieType)
                {
                    _price = _priceFactory(value);
                    _points = _pointsFactory(value);
                }
                _movieType = value;
            }
        }

        public Movie(string title, MovieType movieType, Func<MovieType, IPrice> priceFactory, Func<MovieType, IRenterPointsCalculator> pointsFactory)
        {
            _priceFactory = priceFactory;
            _pointsFactory = pointsFactory;

            Title = title;
            MovieType = movieType;
        }

        public double GetPayment(int daysRented) => _price.GetPayment(daysRented);

        public int GetRenterPoints(int daysRented) => _points.GetRenterPoints(daysRented);
    }
}
