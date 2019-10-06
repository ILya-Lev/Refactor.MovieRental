using System;

namespace DomesticCalculator
{
    public class BucketCalculator
    {
        public double CalculatePowerBill<T>(int consumption, IBillingScheme<T> billingScheme) where T : Customer
        {
            if (consumption < 0)
            {
                throw new Exception($"Cannot calculate price of negative power consumption {consumption}");

            }

            var total = 0d;

            var rest = consumption;
            for (int i = 0; i < billingScheme.PriceBuckets.Count; i++)
            {
                var bucketConsumption = i > 0
                    ? billingScheme.PriceBuckets[i].Limit - billingScheme.PriceBuckets[i - 1].Limit
                    : billingScheme.PriceBuckets[i].Limit;

                if (rest <= bucketConsumption)
                {
                    total += rest * billingScheme.PriceBuckets[i].Price;
                    break;
                }

                total += bucketConsumption * billingScheme.PriceBuckets[i].Price;
                rest -= bucketConsumption;
            }

            return total;
        }
    }
}