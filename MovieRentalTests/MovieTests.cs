using FluentAssertions;
using MovieRental;
using MovieRental.Movies;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace MovieRentalTests
{
    public class MovieTests : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _outputHelper;

        public MovieTests(TestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void SetMovieType_NewReleaseToChildrens_ChangePriceAndPoints()
        {
            var movie = MovieFactory.Create("Pkahontas", MovieType.NewRelease);
            var paymentsAsNew = Enumerable.Range(1, 10).Select(d => movie.GetPayment(d)).ToArray();
            var pointsAsNew = Enumerable.Range(1, 10).Select(d => movie.GetRenterPoints(d)).ToArray();

            _outputHelper.WriteLine(string.Join("; ", paymentsAsNew.Select(p => $"{p}")));
            _outputHelper.WriteLine(string.Join("; ", pointsAsNew.Select(p => $"{p}")));

            paymentsAsNew.Should().NotBeDescendingInOrder();
            pointsAsNew.Should().NotBeDescendingInOrder();



            movie.MovieType = MovieType.Childrens;



            var paymentsAsChild = Enumerable.Range(1, 10).Select(d => movie.GetPayment(d)).ToArray();
            var pointsAsChild = Enumerable.Range(1, 10).Select(d => movie.GetRenterPoints(d)).ToArray();

            _outputHelper.WriteLine(string.Join("; ", paymentsAsChild.Select(p => $"{p}")));
            _outputHelper.WriteLine(string.Join("; ", pointsAsChild.Select(p => $"{p}")));

            paymentsAsChild.Zip(paymentsAsNew, (c, n) => c - n).Should().OnlyContain(dif => dif < 0);
            pointsAsChild.Zip(pointsAsNew, (c, n) => c - n).Should().OnlyContain(dif => dif <= 0);
        }
    }
}