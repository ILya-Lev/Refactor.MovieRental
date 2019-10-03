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

        public string MakeStatement() => new TextStatement().Make(this);

        public string MakeHtmlStatement() => new HtmlStatement().Make(this);

        internal int GetFrequentRenterPoints() => Rentals.Sum(r => r.Points);

        internal double GetTotalCharge() => Rentals.Sum(r => r.Charge);
    }

    internal abstract class Statement
    {
        internal string Make(Customer customer)
        {
            var report = new StringBuilder();
            report.AppendLine(CreateCaption(customer));

            foreach (var rental in customer.Rentals)
            {
                report.AppendLine(CreateOneRentalMessage(rental));
            }

            report.AppendLine(CreateChargeMessage(customer));
            report.AppendLine(CreatePointsMessage(customer));

            return report.ToString();
        }

        private protected abstract string CreateCaption(Customer customer);
        private protected abstract string CreateOneRentalMessage(Rental rental);
        private protected abstract string CreateChargeMessage(Customer customer);
        private protected abstract string CreatePointsMessage(Customer customer);
    }

    internal class TextStatement : Statement
    {
        private protected override string CreateCaption(Customer customer)
            => $"Rent report for {customer.Name}";

        private protected override string CreateOneRentalMessage(Rental rental)
            => $"\t{rental.Movie.Title}\t{rental.Charge}";

        private protected override string CreateChargeMessage(Customer customer)
            => $"Total debt is {customer.GetTotalCharge()}";

        private protected override string CreatePointsMessage(Customer customer)
            => $"You've earned {customer.GetFrequentRenterPoints()} activity points";
    }

    internal class HtmlStatement : Statement
    {
        private protected override string CreateCaption(Customer customer)
            => $"<H1>Rent report for <EM>{customer.Name}</EM></H1><P>";

        private protected override string CreateOneRentalMessage(Rental rental)
            => $"{rental.Movie.Title}: {rental.Charge}<BR/>";

        private protected override string CreateChargeMessage(Customer customer)
            => $"<P>Total debt is <EM>{customer.GetTotalCharge()}</EM><P>";

        private protected override string CreatePointsMessage(Customer customer)
            => $"You've earned <EM>{customer.GetFrequentRenterPoints()}</EM> activity points<P>";
    }
}