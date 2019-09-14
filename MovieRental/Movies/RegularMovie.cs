namespace MovieRental.Movies
{
    internal class RegularMovie : IMovie
    {
        public string Title { get; }

        public RegularMovie(string title) => Title = title;

        public double GetPayment(int daysRented)
        {
            if (daysRented > 3)
                return 1.5 + (daysRented - 3) * 1.5;
            return 1.5;
        }

        public int GetRenterPoints(int daysRented) => 1;
    }
}