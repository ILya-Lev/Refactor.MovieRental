namespace MovieRental.Movies
{
    public interface IMovie
    {
        MovieType MovieType { get; set; }
        string Title { get; }
        double GetPayment(int daysRented);
        int GetRenterPoints(int daysRented);
    }
}