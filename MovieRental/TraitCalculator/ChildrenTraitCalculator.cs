namespace MovieRental.TraitCalculator
{
    public class ChildrenTraitCalculator : ITraitCalculator
    {
        public double GetPayment(int daysRented)
        {
            if (daysRented > 2)
                return 2 + (daysRented - 2) * 1.5;
            return 2;
        }

        public int GetRenterPoints(int daysRented) => 1;
    }
}