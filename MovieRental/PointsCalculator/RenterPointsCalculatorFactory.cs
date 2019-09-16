using System;
using MovieRental.Movies;

namespace MovieRental.PointsCalculator
{
    public class RenterPointsCalculatorFactory
    {
        public static IRenterPointsCalculator Create(MovieType type)
        {
            switch (type)
            {
                case MovieType.Regular:
                case MovieType.Childrens:
                    return new PlainPoints();
                case MovieType.NewRelease:
                    return new NewReleasePoints();
                default:
                    throw new NotImplementedException($"No {nameof(IRenterPointsCalculator)} exists for {nameof(MovieType)} {type}");
            }
        }
    }
}