using MovieRental.TraitCalculator;
using System;

namespace MovieRental.Movies
{
    internal class Movie : IMovie
    {
        private readonly Func<MovieType, ITraitCalculator> _traitFactory;
        public string Title { get; }

        private ITraitCalculator _traitCalculator;
        private MovieType? _movieType = null;
        public MovieType MovieType
        {
            get => _movieType.Value;
            set
            {
                if (value != _movieType)
                {
                    _traitCalculator = _traitFactory(value);
                }
                _movieType = value;
            }
        }

        public Movie(string title, MovieType movieType, Func<MovieType, ITraitCalculator> traitFactory)
        {
            _traitFactory = traitFactory;

            Title = title;
            MovieType = movieType;
        }

        public double GetPayment(int daysRented) => _traitCalculator.GetPayment(daysRented);

        public int GetRenterPoints(int daysRented) => _traitCalculator.GetRenterPoints(daysRented);
    }
}
