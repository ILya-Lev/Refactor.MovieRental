
using MovieRental.Movies;
using System;

namespace MovieRental.Prices
{
    public class PriceFactory
    {
        public static IPrice Create(MovieType type)
        {
            switch (type)
            {
                case MovieType.Regular: return new RegularPrice();
                case MovieType.Childrens: return new ChildrenPrice();
                case MovieType.NewRelease: return new NewReleasePrice();
                default:
                    throw new NotImplementedException($"No {nameof(IPrice)} exists for {nameof(MovieType)} {type}");
            }
        }
    }
}