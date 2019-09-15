using System;
using FluentAssertions;
using MovieRental;
using MovieRental.Movies;
using Xunit;
using Xunit.Sdk;

namespace MovieRentalTests
{
    public class CustomerTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;
        private readonly Customer _customer;
        private readonly Rental[] _rentals;

        public CustomerTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _customer = new Customer("John");
            _rentals = new[]
            {
                new Rental(MovieFactory.CreateNewReleaseMovie("Star Wars III"), 5),
                new Rental(MovieFactory.CreateChildrensMovie("Star Wars II"), 3),
                new Rental(MovieFactory.CreateRegularMovie("Star Wars I"), 17),
            };
            foreach (var rental in _rentals)
            {
                _customer.AddRental(rental);
            }
        }

        [Fact]
        public void MakeStatement_AllTreeTypesOfMovie_StatementOfSixLines()
        {
            var statement = _customer.MakeStatement();

            _outputHelper.WriteLine(statement);
            statement.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Should().HaveCount(6);
        }

        [Fact]
        public void MakeHtmlStatement_AllTreeTypesOfMovie_StatementOfSixLines()
        {
            var statement = _customer.MakeHtmlStatement();

            _outputHelper.WriteLine(statement);
            statement.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Should().HaveCount(6);
        }
    }
}
