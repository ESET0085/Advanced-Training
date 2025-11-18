namespace CS._1._012
{

    public class Tariff
    {
        public string Name;
        public double RatePerKwh;
        public double FixedCharge;

        public Tariff(string name)
        {
            this.Name = name;
            this.RatePerKwh = 6.0;
            this.FixedCharge = 50.0;
        }

        public Tariff(string name, double rate) : this(name, rate, 50.0)
        {

        }

        public Tariff(string name, double rate, double fixedCharge)
        {
            this.Name = name;
            this.RatePerKwh = rate;
            this.FixedCharge = fixedCharge;
        }
        public double ComputeBill(int units)
        {
            return (units * this.RatePerKwh) + this.FixedCharge;
        }



    }




    internal class Program
    {
        static void Main(string[] args)
        {
            int units = 120;

            
            Tariff residentialTariff = new Tariff("Residential");

            Tariff industrialTariff = new Tariff("Industrial", 8.2, 100.0);

            Tariff businessTariff = new Tariff("Business", 7.5);

            Console.WriteLine($"--- Computing bills for {units} units ---");

            
            Console.WriteLine($"{residentialTariff.Name}: {residentialTariff.ComputeBill(units)}");
            Console.WriteLine($"{industrialTariff.Name}: {industrialTariff.ComputeBill(units)}");
            Console.WriteLine($"{businessTariff.Name}: {businessTariff.ComputeBill(units)}");
              


            Console.ReadKey();
        }
    }
}
