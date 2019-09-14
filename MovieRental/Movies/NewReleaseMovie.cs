namespace MovieRental.Movies
{
    internal class NewReleaseMovie : IMovie
    {
        public string Title { get; }

        public NewReleaseMovie(string title) => Title = title;

        public double GetPayment(int daysRented) => daysRented * 3;

        public int GetRenterPoints(int daysRented) => daysRented > 1 ? 2 : 1;
    }
}