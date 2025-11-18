namespace Adv_Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TASK 1

            Console.WriteLine("Enter your name :");
            string StudentName = Console.ReadLine();
            Console.WriteLine($"Hello, {StudentName}");

            int sub1 = 67;
            int sub2 = 78;
            int sub3 = 89;
            int sub4 = 90;
            int sub5 = 56;


            int total = sub1 + sub2 + sub3 + sub4 + sub5;
            Console.WriteLine($"Total Marks : {total}");

            float percentage = (total / 500.0f) * 100;
            Console.WriteLine($"Percentage : {percentage}%");

            float average = total / 5.0f;
            Console.WriteLine($"Average : {average}");



            // TASK 2


            int BasicSalary = 80000;
            float HRA = (BasicSalary * 20) / 100.0f;
            float DA = (BasicSalary * 10) / 100.0f;
            float GrossSalary = BasicSalary + HRA + DA;
            float Tax = (GrossSalary * 8) / 100.0f;
            float NetSalary = GrossSalary - Tax;

            Console.WriteLine($"Basic Salary : {BasicSalary}");
            Console.WriteLine($"HRA : {HRA}");
            Console.WriteLine($"DA : {DA}");
            Console.WriteLine($"Gross Salary : {GrossSalary}");
            Console.WriteLine($"Net Salary : {NetSalary}");



            // TASK 3

            double inr = 1000;
            double usd = inr / 83.0;
            double euro = inr / 90.5;
            Console.WriteLine($"INR : {inr}");
            double usdRounded = Math.Round(usd, 2);
            Console.WriteLine($"USD : {usdRounded}");
            double euroRounded = Math.Round(euro, 2);
            Console.WriteLine($"EURO : {euroRounded}");


            // TASK 4

            int minutes = 350;
            int hours = minutes / 60;
            int remainingMinutes = minutes % 60;
            Console.WriteLine($"{minutes} minutes is {hours} hours and {remainingMinutes} minutes.");



        }
    }
}
