namespace MovieRental.PointsCalculator
{
    public class PlainPoints : IRenterPointsCalculator
    {
        public int GetRenterPoints(int daysRented) => 1;
    }
}