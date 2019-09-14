namespace MovieRental.Movies
{
    internal class ChildrenMovie : IMovie
    {
        public string Title { get; }

        public ChildrenMovie(string title) => Title = title;

        public double GetPayment(int daysRented)
        {
            if (daysRented > 2)
                return 2 + (daysRented - 2) * 1.5;
            return 2;
        }

        public int GetRenterPoints(int daysRented) => 1;
    }
}
