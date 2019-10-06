using System.Collections.Generic;

namespace DomesticCalculator
{
    /// <summary>
    /// needed to tell outer world (e.g. BucketCalculator) it contains PriceBuckets
    /// another possibility - make dependency over Customer in billing scheme constructor
    /// => no need in generic parameter
    /// </summary>
    /// <typeparam name="TCustomer"></typeparam>
    public interface IBillingScheme<TCustomer> where TCustomer : Customer
    {
        IReadOnlyList<(int Limit, double Price)> PriceBuckets { get; }
        double GetPowerBill(TCustomer customer);
    }
}