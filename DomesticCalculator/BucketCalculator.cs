using System;

namespace DomesticCalculator
{
    public class BucketCalculator
    {
        public double CalculatePowerBill(int consumption, IPriceBuckets buckets)
        {
            if (consumption < 0)
            {
                throw new Exception($"Cannot calculate price of negative power consumption {consumption}");

            }

            var total = 0d;

            var rest = consumption;
            for (int i = 0; i < buckets.PriceBuckets.Count; i++)
            {
                var bucketConsumption = i > 0
                    ? buckets.PriceBuckets[i].Limit - buckets.PriceBuckets[i - 1].Limit
                    : buckets.PriceBuckets[i].Limit;

                if (rest <= bucketConsumption)
                {
                    total += rest * buckets.PriceBuckets[i].Price;
                    break;
                }

                total += bucketConsumption * buckets.PriceBuckets[i].Price;
                rest -= bucketConsumption;
            }

            return total;
        }
    }
}