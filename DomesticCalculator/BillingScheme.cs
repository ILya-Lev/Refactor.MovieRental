using System;
using System.Collections.Generic;

namespace DomesticCalculator
{
    public class BillingScheme
    {
        /// <summary>
        /// if monthly consumption is within the bucket each kWh cost given price
        /// </summary>
        protected virtual IReadOnlyList<(int Limit, double Price)> PriceBuckets { get; } = new (int, double)[]
        {
            (100, 0.91),
            (600, 1.68),
            (int.MaxValue, 2.50),
        };

        public virtual double GetPowerBill(Customer customer)
        {
            if (customer.PowerConsumptionInLastMonth < 0)
            {
                throw new Exception($"Cannot calculate price of negative power consumption {customer.PowerConsumptionInLastMonth}");
            }

            var total = 0d;

            var rest = customer.PowerConsumptionInLastMonth;
            for (int i = 0; i < PriceBuckets.Count; i++)
            {
                var bucketConsumption = i > 0
                    ? PriceBuckets[i].Limit - PriceBuckets[i - 1].Limit
                    : PriceBuckets[i].Limit;

                if (rest <= bucketConsumption)
                {
                    total += rest * PriceBuckets[i].Price;
                    break;
                }

                total += bucketConsumption * PriceBuckets[i].Price;
                rest -= bucketConsumption;
            }

            return total;
        }
    }
}