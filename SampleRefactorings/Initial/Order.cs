using System.Collections.Generic;
using System.Linq;

namespace SampleRefactorings.Initial
{
    /// <summary>
    /// demonstrates: replace data value with object
    /// </summary>
    public class Order
    {
        public string Customer { get; }
        public Order(string customer)
        {
            Customer = customer;
        }

        public int NumberOfOrdersForCustomer(IEnumerable<Order> orders, string customer)
        {
            return orders.Count(ord => ord.Customer == customer);
        }
    }
}
