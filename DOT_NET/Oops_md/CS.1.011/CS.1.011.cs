using System.Diagnostics.Metrics;

namespace CS._1._011
{


    public class meter
    {

        public string MeterSerial;
        public string Location;
        public DateTime InstalledOn;
        public int LastReadingKwh;




        public void AddReading(int deltaKwh)
        {
            if (deltaKwh > 0)
            {
                LastReadingKwh += deltaKwh;
            }
        }

        public string Summary()
        {
            return $"{MeterSerial} Location: {Location} | Reading: {LastReadingKwh} kWh";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            
            meter meter1 = new meter
            {
                MeterSerial = "MTR001",
                Location = "Main Building",
                InstalledOn = new DateTime(2023, 1, 15),
                LastReadingKwh = 1500
            };


            meter meter2 = new meter
            {
                MeterSerial = "MTR002",
                Location = "Basement",
                InstalledOn = new DateTime(2023,1,24),
                LastReadingKwh = 1000

            };


            meter1.AddReading(100); 
            meter1.AddReading(-50); 
            meter1.AddReading(25); 

           
            meter2.AddReading(50);  
            meter2.AddReading(0);   
            meter2.AddReading(120); 

            
            Console.WriteLine(meter1.Summary());
            Console.WriteLine(meter2.Summary());

            Console.ReadKey();

        }
    }
}
