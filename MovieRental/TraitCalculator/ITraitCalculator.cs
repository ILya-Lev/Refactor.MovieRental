namespace MovieRental.TraitCalculator
{
    public interface ITraitCalculator
    {
        double GetPayment(int daysRented);
        int GetRenterPoints(int daysRented);
    }
}