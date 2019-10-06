namespace DomesticCalculator
{
    public class BillingScheme : ABillingScheme<Customer>
    {
        public BillingScheme(BucketCalculator calculator) : base(calculator) { }
    }
}