namespace MovieRental.Prices
{
    public class ChildrenPrice : IPrice
    {
        public double GetPayment(int daysRented)
        {
            if (daysRented > 2)
                return 2 + (daysRented - 2) * 1.5;
            return 2;
        }
    }
}