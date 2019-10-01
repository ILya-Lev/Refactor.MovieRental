using FluentAssertions;
using Xunit;

namespace SampleRefactoringTests
{
    public class ChargeCalculatorTests
    {
        [InlineData(0)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(200)]
        [InlineData(300)]
        [Theory]
        public void GetBaseCharge_Initial_Between100And200(int lastCharge)
        {
            var initCalc = new SampleRefactorings.Initial.ChargeCalculator();
            var refCalc = new SampleRefactorings.Refactored.ChargeCalculator();
            initCalc.LastCharge = lastCharge;
            refCalc.LastCharge = lastCharge;

            refCalc.GetBaseCharge().Should().Be(initCalc.GetBaseCharge());
        }
    }
}
