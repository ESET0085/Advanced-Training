namespace CS._2._015
{


    public interface IBillingRule
    {
        double Compute(int units);
    }

    public class DomesticRule : IBillingRule
    {
        private double unit;

        public double Compute(int units)
        {

            return 6.0 / units + 50  ;
        }
    }

    class CommercialRule : IBillingRule
    {
        public double Compute(int units)
        {
           return 8.5 / units + 150;
        }
    }

    class AgricultureRule : IBillingRule
    {
        public double Compute(int units)
        {
            return 3.0 / units + 0;
        }
    }

    class BillingEngine
    {
        public string IBillingRule_rule;
        public double CalculateBill(int units)
        {
            IBillingRule rule = IBillingRule_rule switch
            {
                "domestic" => new DomesticRule(),
                "commercial" => new CommercialRule(),
                "agriculture" => new AgricultureRule(),
                _ => throw new InvalidOperationException("Invalid rule")
            };
            return rule.Compute(units);
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {

            BillingEngine engine = new BillingEngine();
            engine.IBillingRule_rule = "domestic";
            double bill = engine.CalculateBill(100);
            Console.WriteLine($"domestic: {bill}");

            engine.IBillingRule_rule = "commercial";
            bill = engine.CalculateBill(200);
            Console.WriteLine($"commercial: {bill}");

            engine.IBillingRule_rule = "agriculture";
            bill = engine.CalculateBill(300);
            Console.WriteLine($"agriculture: {bill}");


        }
    }
}

