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
                var thisAmount = 0d;
            
                switch (rental.Movie.PriceCode)
                {
                    case Movie.Childrens:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.Regular:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                }

                frequentRenterPoints++;
                if (rental.Movie.PriceCode == Movie.NewRelease && rental.DaysRented > 1)
                    frequentRenterPoints++;

                report.AppendLine($"\t{rental.Movie.Title}\t{thisAmount}");
                totalAmount += thisAmount;
            }

            report.AppendLine($"Total dept is {totalAmount}");
            report.AppendLine($"You've earned {frequentRenterPoints} activity points");
            
            return report.ToString();
        }
    }
}