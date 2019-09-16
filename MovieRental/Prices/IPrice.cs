namespace MovieRental.Prices
{
    public interface IPrice
    {
        double GetPayment(int daysRented);
    }
}