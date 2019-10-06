using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DomesticCalculator.Tests")]

namespace DomesticCalculator
{
    public class DisabilityBillingScheme : ABillingScheme<DisabilityCustomer>
    {
        internal static readonly Dictionary<int, double> _factors = new Dictionary<int, double>()
        {
            [1] = 0.75,
            [2] = 0.50,
            [3] = 0.25,
            [4] = 0.15,
        };

        public DisabilityBillingScheme(BucketCalculator calculator) : base(calculator) { }

        public override double GetPowerBill(DisabilityCustomer customer)
        {
            return base.GetPowerBill(customer) * GetDisabilityFactor(customer.DisabilityGroup);
        }

        private double GetDisabilityFactor(int disabilityGroup) => _factors[disabilityGroup];
    }
}