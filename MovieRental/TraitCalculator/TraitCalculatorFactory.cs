using System;

namespace MovieRental.TraitCalculator
{
    public class TraitCalculatorFactory
    {
        public static ITraitCalculator Create(MovieType type)
        {
            switch (type)
            {
                case MovieType.Regular: return new RegularTraitCalculator();
                case MovieType.Childrens: return new ChildrenTraitCalculator();
                case MovieType.NewRelease: return new NewReleaseTraitCalculator();
                default:
                    throw new NotImplementedException($"No {nameof(ITraitCalculator)} exists for {nameof(MovieType)} {type}");
            }
        }
    }
}