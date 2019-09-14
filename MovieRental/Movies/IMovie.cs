namespace MovieRental.Movies
{
    public interface IMovie
    {
        string Title { get; }
        double GetPayment(int daysRented);
        int GetRenterPoints(int daysRented);
    }
}