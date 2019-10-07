using FluentAssertions;
using System;
using Xunit;
using Xunit.Sdk;

namespace DomesticCalculator.Tests
{
    public class BillingSchemeTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;

        public BillingSchemeTests(TestOutputHelper output)
        {
            _output = output;
        }

        [InlineData(0, 0)]
        [InlineData(50, 50 * 0.91)]
        [InlineData(100, 100 * 0.91)]
        [InlineData(150, 100 * 0.91 + 50 * 1.68)]
        [InlineData(600, 100 * 0.91 + 500 * 1.68)]
        [InlineData(700, 100 * 0.91 + 500 * 1.68 + 100 * 2.5)]
        [Theory]
        public void GetPowerBill_Customer_MatchExpectations(int consumption, double totalPrice)
        {
            var customer = new Customer() { PowerConsumptionInLastMonth = consumption };
            var scheme = new BillingScheme(new BucketCalculator());

            var powerBill = scheme.GetPowerBill(customer);

            powerBill.Should().Be(totalPrice);
            _output.WriteLine($"Plain customer consumed {customer.PowerConsumptionInLastMonth} and have to pay {powerBill} for electricity this month");
        }

        [Fact]
        public void GetPowerBill_CustomerNegative_Exception()
        {
            var customer = new Customer() { PowerConsumptionInLastMonth = -10 };
            var scheme = new BillingScheme(new BucketCalculator());

            Action billCalculation = () => scheme.GetPowerBill(customer);

            var exc = billCalculation.Should().Throw<Exception>().Which;
            _output.WriteLine(exc.Message);
        }

        [InlineData(0, 1, 0)]
        [InlineData(50, 2, 50 * 0.91)]
        [InlineData(100, 3, 100 * 0.91)]
        [InlineData(150, 4, 100 * 0.91 + 50 * 1.68)]
        [InlineData(600, 2, 100 * 0.91 + 500 * 1.68)]
        [InlineData(700, 3, 100 * 0.91 + 500 * 1.68 + 100 * 2.5)]
        [Theory]
        public void GetPowerBill_DisabledCustomer_MatchExpectations(int consumption, int disabilityGroup, double totalPrice)
        {
            var customer = new DisabilityCustomer(disabilityGroup) { PowerConsumptionInLastMonth = consumption };
            var scheme = new DisabilityBillingScheme(new BucketCalculator());

            var powerBill = scheme.GetPowerBill(customer);

            powerBill.Should().Be(totalPrice * DisabilityBillingScheme._factors[disabilityGroup]);
            _output.WriteLine($"Plain customer consumed {customer.PowerConsumptionInLastMonth} and have to pay {powerBill} for electricity this month");
        }

    }
}
