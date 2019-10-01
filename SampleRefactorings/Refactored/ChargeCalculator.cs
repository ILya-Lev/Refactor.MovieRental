using System;

namespace SampleRefactorings.Refactored
{
    public class ChargeCalculator
    {
        public double LastCharge { get; set; } = 0;

        public double GetBaseCharge()
        {
            var totalCharge = ChargeInRange(0, 100) * 0.03;
            totalCharge += ChargeInRange(100, 200) * 0.05;
            totalCharge += ChargeInRange(200, int.MaxValue) * 0.07;

            return totalCharge;
        }

        private double ChargeInRange(int start, int end)
        {
            return LastCharge > start ? Math.Min(LastCharge, end) - start : 0;
        }
    }
}