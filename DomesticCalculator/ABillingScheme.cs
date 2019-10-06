using System.Collections.Generic;

namespace DomesticCalculator
{
    /// <summary>
    /// needed as contains duplicated (so far) code - PriceBuckets values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ABillingScheme<T> : IBillingScheme<T> where T : Customer
    {
        private readonly BucketCalculator _calculator;

        protected ABillingScheme(BucketCalculator calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// if monthly consumption is within the bucket each kWh cost given price
        /// </summary>
        public IReadOnlyList<(int Limit, double Price)> PriceBuckets { get; } = new (int, double)[]
        {
            (100, 0.91),
            (600, 1.68),
            (int.MaxValue, 2.50),
        };

        public virtual double GetPowerBill(T customer)
            => _calculator.CalculatePowerBill(customer.PowerConsumptionInLastMonth, this);
    }
}