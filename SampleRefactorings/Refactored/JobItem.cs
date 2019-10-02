namespace SampleRefactorings.Refactored
{
    /// <summary>
    /// extract subclass sample
    /// </summary>
    public abstract class JobItem
    {
        public int Quantity { get; }
        protected JobItem(int quantity) => Quantity = quantity;
        public abstract decimal GetTotalPrice();
    }

    internal class SpareItem : JobItem
    {
        public decimal UnitPrice { get; }
        public SpareItem(decimal unitPrice, int quantity) : base(quantity) => UnitPrice = unitPrice;
        public override decimal GetTotalPrice() => UnitPrice * Quantity;
    }

    public class LaborItem : JobItem
    {
        public Employee Employee { get; }
        public LaborItem(int quantity, Employee employee) : base(quantity) => Employee = employee;
        public override decimal GetTotalPrice() => Employee.Rate * Quantity;
    }

    public class Employee
    {
        public decimal Rate { get; }
        public Employee(decimal rate) => Rate = rate;
    }
}