namespace CS._1._001
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Quick Bill from Two Readings

            string meterSerial = Console.ReadLine();
            int prevReading = Convert.ToInt32(Console.ReadLine());
            int currreading = Convert.ToInt32(Console.ReadLine());
            int units = currreading - prevReading;

            if (units <= 0)
            {
                Console.WriteLine("Invalid reading");


            }
            else
            {
                double energyCharge = units * 6.5;
                double tax = units * 0.5;
                double Total = energyCharge * tax;

                Console.WriteLine($" Meter: {meterSerial} | Units : {units} | Energy: {energyCharge} | Tax : {tax} | Total : {Total} ");

            }


           // Weekly Consumption Basics

            int[] daily = { 4, 5, 6, 0, 7, 8, 5 };
            int count = 0;

            foreach (int d in daily)
            {
                count = count + d;
            }
            double avg = count / 8;
            int max = daily.Max();

            Console.WriteLine($"Total :{count} ");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"avg: {avg}");



            //Parse Load Profile Lines (No Files)

            //string[] lines = { "2025-09-01,4.2,OK", "2025-09-02,5.0,OK", "2025-09-03,0.0,OUTAGE", "2025-09-04,3.8,OK", "2025-09-05,6.1,OK", "2025-09-06,2.5,TAMPER", "2025-09-07,5.4,OK" };

            double totalOK = 0;
            int countOutage = 0;
            int countTamper = 0;
            string[] lines = { "2025-09-01,4.2,OK", "2025-09-02,5.0,OK", "2025-09-03,0.0,OUTAGE", "2025-09-04,3.8,OK", "2025-09-05,6.1,OK", "2025-09-06,2.5,TAMPER", "2025-09-07,5.4,OK" };
            for (int i = 0; i < lines.Length; i++)
            {
                //lines[i] = Console.ReadLine();
                string[] words = new string[3];
                words = lines[i].Split(',');
                if (words[2] == "OK")
                    totalOK += Convert.ToDouble(words[1]);
                if (words[2] == "OUTAGE")
                    countOutage++;
                if (words[2] == "TAMPER")
                    countTamper++;
            }
            Console.WriteLine(totalOK);
            Console.WriteLine(countOutage);
            Console.WriteLine(countTamper);


            //Multi-Meter Weekly Health Report













        }
    }
}
