namespace MovieRental.Prices
{
    public class RegularPrice : IPrice
    {
        public double GetPayment(int daysRented)
        {
            if (daysRented > 3)
                return 1.5 + (daysRented - 3) * 1.5;
            return 1.5;
        }
    }
}