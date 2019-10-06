using System;

namespace DomesticCalculator
{
    public class DisabilityCustomer : Customer
    {
        public int DisabilityGroup { get; }

        public DisabilityCustomer(int disabilityGroup)
        {
            if (1 <= disabilityGroup && disabilityGroup <= 4)
                DisabilityGroup = disabilityGroup;
            else
                throw new Exception($"Unknown disability group must be an integer between 1 and 4, provided {disabilityGroup}");
        }
    }
}