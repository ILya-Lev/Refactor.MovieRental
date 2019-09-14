using System.Collections.Generic;
using System.Text;

namespace MovieRental
{
    public class Customer
    {
        private readonly List<Rental> _rentals;

        public string Name { get; }
        public IReadOnlyList<Rental> Rentals => _rentals;

        public Customer(string name)
        {
            Name = name;
            _rentals = new List<Rental>();
        }

        public void AddRental(Rental rental) => _rentals.Add(rental);

        public string Statement()
        {
            var report = new StringBuilder();
            report.AppendLine($"Rent report for {Name}");
            
            int frequentRenterPoints = 0;
            double totalAmount = 0;

            foreach (var rental in Rentals)
            {
                var thisAmount = rental.Movie.GetPayment(rental.DaysRented);
                frequentRenterPoints += rental.Movie.GetRenterPoints(rental.DaysRented);

                report.AppendLine($"\t{rental.Movie.Title}\t{thisAmount}");
                totalAmount += thisAmount;
            }

            report.AppendLine($"Total debt is {totalAmount}");
            report.AppendLine($"You've earned {frequentRenterPoints} activity points");
            
            return report.ToString();
        }
    }
}