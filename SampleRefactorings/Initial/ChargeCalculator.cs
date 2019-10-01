using System;

namespace SampleRefactorings.Initial
{
    public class ChargeCalculator
    {
        public double LastCharge { get; set; } = 0;

        public double GetBaseCharge()
        {
            var totalCharge = Math.Min(LastCharge, 100) * 0.03;

            if (LastCharge > 100)
                totalCharge += (Math.Min(LastCharge, 200) - 100) * 0.05;

            if (LastCharge > 200)
                totalCharge += (LastCharge - 200) * 0.07;

            return totalCharge;
        }
    }
}