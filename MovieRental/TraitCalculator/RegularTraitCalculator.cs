namespace MovieRental.TraitCalculator
{
    public class RegularTraitCalculator : ITraitCalculator
    {
        public double GetPayment(int daysRented)
        {
            if (daysRented > 3)
                return 1.5 + (daysRented - 3) * 1.5;
            return 1.5;
        }

        public int GetRenterPoints(int daysRented) => 1;
    }
}