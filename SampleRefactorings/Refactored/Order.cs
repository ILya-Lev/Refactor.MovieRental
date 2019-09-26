using System.Collections.Generic;
using System.Linq;

namespace SampleRefactorings.Refactored
{
    /// <summary>
    /// demonstrates: replace data value with object
    /// </summary>
    public class Order
    {
        public Customer Customer { get; }

        public Order(Customer customer) => Customer = customer;
        public Order(string customerName) => Customer = Customer.GetByName(customerName);

        public int NumberOfOrdersForCustomer(IEnumerable<Order> orders, Customer customer)
        {
            //return orders.Count(ord => ord.Customer.Equals(customer));
            return orders.Count(ord => ord.Customer == customer);
        }
    }

    //now it's a "reference object" as there is only one unique instance in the system
    //and compare by ref is enough - no need to override Equal and GetHashCode methods
    public class Customer
    {
        private static readonly Dictionary<string, Customer> _instances = new Dictionary<string, Customer>();

        public string Name { get; }

        public static Customer GetByName(string name)
        {
            if (_instances.Count == 0)
                LoadCustomers();

            return _instances[name];
        }

        private Customer(string name) => Name = name;

        //initializes in memory cache of unique objects
        private static void LoadCustomers()
        {
            new Customer("CBOE").Store();
            new Customer("CME").Store();
            new Customer("NYSE").Store();
        }

        private void Store()
        {
            _instances.Add(this.Name, this);
        }
    }
}