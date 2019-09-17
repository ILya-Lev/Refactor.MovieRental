namespace MovieRental.TraitCalculator
{
    public class NewReleaseTraitCalculator : ITraitCalculator
    {
        public double GetPayment(int daysRented) => daysRented * 3;
        public int GetRenterPoints(int daysRented) => daysRented > 1 ? 2 : 1;
    }
}