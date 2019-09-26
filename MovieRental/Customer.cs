using System.Collections.Generic;
using System.Linq;
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

        public string MakeStatement()
        {
            var report = new StringBuilder();
            report.AppendLine($"Rent report for {Name}");

            foreach (var rental in Rentals)
            {
                report.AppendLine($"\t{rental.Movie.Title}\t{rental.Charge}");
            }

            report.AppendLine($"Total debt is {GetTotalCharge()}");
            report.AppendLine($"You've earned {GetFrequentRenterPoints()} activity points");

            return report.ToString();
        }

        public string MakeHtmlStatement()
        {
            var report = new StringBuilder();
            report.AppendLine($"<H1>Rent report for <EM>{Name}</EM></H1><P>");

            foreach (var rental in Rentals)
            {
                report.AppendLine($"{rental.Movie.Title}: {rental.Charge}<BR/>");
            }

            report.AppendLine($"<P>Total debt is <EM>{GetTotalCharge()}</EM><P>");
            report.AppendLine($"You've earned <EM>{GetFrequentRenterPoints()}</EM> activity points<P>");

            return report.ToString();
        }

        private int GetFrequentRenterPoints() => Rentals.Sum(r => r.Points);

        private double GetTotalCharge() => Rentals.Sum(r => r.Charge);
    }
}