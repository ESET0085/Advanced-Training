namespace CS._2._013
{

    public class Device
    {
        public string Id;
        public DateTime InstalledOn;



        public virtual void Describe()
        {
            Console.WriteLine($"Device ID: {Id}, Installed On: {InstalledOn}");
        }
    }

    public class Meter : Device
    {
        public int PhaseCount;
        public override void Describe()
        {
            base.Describe();
            Console.WriteLine($"Meter Reading: {PhaseCount}");
        }
    }
     public class Gateaway : Device
    {
               public string IPAddress;
        public override void Describe()
        {
            base.Describe();
            Console.WriteLine($"Gateway IP Address: {IPAddress}");
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {


            Device[] devices = new Device[2];
            devices[0] = new Meter { Id = "M001", InstalledOn = DateTime.Now, PhaseCount = 3 };
            devices[1] = new Gateaway { Id = "G001", InstalledOn = DateTime.Now, IPAddress = "10.0.5.12" };


            foreach (var device in devices)
            {
                device.Describe();
                Console.WriteLine();
            }
                //Device myDevice = new Device { Id = "D001", InstalledOn = DateTime.Now };
                //Meter myMeter = new Meter { Id = "M001", InstalledOn = DateTime.Now, PhaseCount = 3 };
                //Gateaway myGateway = new Gateaway { Id = "G001", InstalledOn = DateTime.Now, IPAddress = " 10.0.5.21" };


                //Console.WriteLine("Device Description:");
                //myDevice.Describe();
                //Console.WriteLine("\nMeter Description:");
                //myMeter.Describe();
                //Console.WriteLine("\nGateway Description:");
                //myGateway.Describe();

                //Console.ReadLine();



            }

     }
}
