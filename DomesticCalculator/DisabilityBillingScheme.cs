using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("DomesticCalculator.Tests")]

namespace DomesticCalculator
{
    public class DisabilityBillingScheme : BillingScheme
    {
        internal static readonly Dictionary<int, double> _factors = new Dictionary<int, double>()
        {
            [1] = 0.75,
            [2] = 0.50,
            [3] = 0.25,
            [4] = 0.15,
        };

        public override double GetPowerBill(Customer customer)
        {
            if (customer is DisabilityCustomer disabilityCustomer)
            {
                return base.GetPowerBill(disabilityCustomer)
                       * GetDisabilityFactor(disabilityCustomer.DisabilityGroup);
            }

            throw new Exception($"{nameof(DisabilityBillingScheme)} cannot work with any type other than {nameof(DisabilityCustomer)}");
        }

        private double GetDisabilityFactor(int disabilityGroup) => _factors[disabilityGroup];

    }
}