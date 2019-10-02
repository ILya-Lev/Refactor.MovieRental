namespace SampleRefactorings.Initial
{
    /// <summary>
    /// extract subclass sample
    /// </summary>
    public class JobItem
    {
        public int Quantity { get; }

        private readonly decimal _unitPrice;
        private readonly bool _isLabor;
        private readonly Employee _employee;

        public JobItem(decimal unitPrice, int quantity, bool isLabor, Employee employee)
        {
            _unitPrice = unitPrice;
            Quantity = quantity;
            _isLabor = isLabor;
            _employee = employee;
        }

        public decimal GetTotalPrice() => GetUnitPrice() * Quantity;

        private decimal GetUnitPrice() => _isLabor ? _employee.Rate : _unitPrice;
    }

    public class Employee
    {
        public decimal Rate { get; }
        public Employee(decimal rate) => Rate = rate;
    }
}