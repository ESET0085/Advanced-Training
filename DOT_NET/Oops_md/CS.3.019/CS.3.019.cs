using System.Data;

namespace CS._3._019
{


    public interface IRebate
    {
        string Code { get; }
        double Apply(double currentTotal, int outageDays);
    }

    public interface IBillingRule
    {
        string Code { get; }
        double Compute(int units);
    }


    //NoOutageRebate → if outageDays==0 then -2%
    public class OutageRebate : IRebate
    {
        public string Code => "OUTAGE";
        public double Apply(double currentTotal, int outageDays)
        {
            return currentTotal - (20 * outageDays);
        }
    }

    // HighUsageRebate → if units>500 then -3%.

    public class HighUsageRebate : IRebate
    {
        public string Code => "HIGHUSAGE";
        public double Apply(double currentTotal, int outageDays)
        {
            return currentTotal * 0.97;
        }
    }

    class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; } = new();
        public BillingContext(IBillingRule rule) => Rule = rule;
        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);
            foreach (var r in Rebates) total += r.Apply(total, outageDays);
            return total;
        }
        public double Compute(int units)
        {
            return Rule.Compute(units);
        }

    }
    
    public class CommercialBillingRule : IBillingRule
    {
        public string Code => "COMMERCIAL";
        public double Compute(int units)
        {
            // Example logic: $0.25 per unit
            return units * 0.25;
        }
    }













    internal class Program
    {
        static void Main(string[] args)
        {

            //Rule = Commercial, units = 620, outageDays = 0.Apply both rebates.
            IBillingRule rule = new CommercialBillingRule();
            BillingContext context = new BillingContext(rule);
            context.Rebates.Add(new OutageRebate());
            context.Rebates.Add(new HighUsageRebate());
            Console.WriteLine($"Subtotal: {context.Compute(620)}");
            Console.WriteLine("Applying Rebates:");
            Console.WriteLine(" - NO_OUTAGE");
            Console.WriteLine(" - HIGH_USAGE");
           

            double finalAmount = context.Finalize(620, 0);
            Console.WriteLine($"Final Amount: {finalAmount}");

            






        }
    }

}


