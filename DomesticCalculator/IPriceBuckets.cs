using System.Collections.Generic;

namespace DomesticCalculator
{
    public interface IPriceBuckets
    {
        IReadOnlyList<(int Limit, double Price)> PriceBuckets { get; }
    }
}