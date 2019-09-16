namespace MovieRental.PointsCalculator
{
    public class NewReleasePoints : IRenterPointsCalculator
    {
        public int GetRenterPoints(int daysRented) => daysRented > 1 ? 2 : 1;
    }
}