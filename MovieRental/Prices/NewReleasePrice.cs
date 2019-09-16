namespace MovieRental.Prices
{
    public class NewReleasePrice : IPrice
    {
        public double GetPayment(int daysRented) => daysRented * 3;
    }
}