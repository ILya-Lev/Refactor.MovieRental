using System;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace DomesticCalculator.Tests
{
    public class TimerManagerTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;

        public TimerManagerTests(TestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Ctor_ExecuteAtGivenTimes_Only()
        {
            var intervals = new double[] { 100, 200, 300, 400, 500 };
            var manager = new TimerManager(intervals);
            while (manager.Results.Count < 5) { }
            //Thread.Sleep(10_000);

            manager.Results.Should().NotBeEmpty();
            _output.WriteLine(string.Join(Environment.NewLine, manager.Results.ToArray().Select(m => $"{m}")));
        }
    }
}