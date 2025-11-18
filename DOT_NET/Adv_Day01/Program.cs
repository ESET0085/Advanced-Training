namespace Adv_Day01
{
    internal class Program
    {
        static void Main()
        {

            //Console.WriteLine("Enter your name :");
            //string StudentName = Console.ReadLine();
            //Console.WriteLine($"Hello, {StudentName}!");

            //int sub1 = 67;
            //int sub2 = 78;
            //int sub3 = 89;
            //int sub4 = 90;
            //int sub5 = 56;


            //int total = sub1 + sub2 + sub3 + sub4 + sub5;
            //Console.WriteLine($"Total Marks : {total}");

            //float percentage = (total / 500.0f) * 100;
            //Console.WriteLine($"Percentage : {percentage}%");

            //float average = total / 5.0f;
            //Console.WriteLine($"Average : {average}");




            //int BasicSalary = 80000;
            //float HRA = (BasicSalary * 20) / 100.0f;
            //float DA = (BasicSalary * 10) / 100.0f;
            //float GrossSalary = BasicSalary + HRA + DA;
            //float Tax = (GrossSalary * 8) / 100.0f;
            //float NetSalary = GrossSalary - Tax;


            //Console.WriteLine($"Basic Salary : {BasicSalary}");
            //Console.WriteLine($"HRA : {HRA}");
            //Console.WriteLine($"DA : {DA}");
            //Console.WriteLine($"Gross Salary : {GrossSalary}");
            //Console.WriteLine($"Net Salary : {NetSalary}");



            //double inr = 1000;
            //double usd = inr / 83.0;
            //double euro = inr / 90.5;
            //Console.WriteLine($"INR : {inr}");
            //double usdRounded = Math.Round(usd, 2);
            //Console.WriteLine($"USD : {usdRounded}");
            //double euroRounded = Math.Round(euro, 2);
            //Console.WriteLine($"EURO : {euroRounded}");



            //int minutes = 350;
            //int hours = minutes / 60;
            //int remainingMinutes = minutes % 60;
            //Console.WriteLine($"{minutes} minutes is {hours} hours and {remainingMinutes} minutes.");


            //for(int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(i*i);

            //}

            //for(int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(i*i*i);
            //}



            //for (int number = 1; number <= 1000; number++)
            //{
            //    int sumOfDivisors = 0;
            //    for (int i = 1; i < number; i++) 
            //    {
            //        if (number % i == 0)
            //        {
            //            sumOfDivisors += i;
            //        }
            //    }

            //    if (sumOfDivisors == number)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}





            //for (int number = 100; number <= 999; number++)
            //{

            //    int originalNumber = number;
            //    int sum = 0;
            //    int temp = number;

            //    while (temp > 0)
            //    {

            //        int digit = temp % 10;


            //        sum += (int)Math.Pow(digit, 3);


            //        temp /= 10;
            //    }


            //    if (sum == originalNumber)
            //    {
            //        Console.WriteLine(originalNumber);


            //    }

            //}



            //int i;
            //int j;
            //int k;
            //string symbol = "*";


            //for(i = 4; i >= 1; i--)
            //{
            //    for (j = 5; j > i; j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (k = 1; k <= (2 * i - 1); k++)
            //    {
            //        Console.Write(symbol);
            //    }
            //    Console.WriteLine();
            //}
            //for (i = 1; i <= 5; i++)
            //{
            //    for (j = 5; j > i; j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (k = 1; k <= (2 * i - 1); k++)
            //    {
            //        Console.Write(symbol);
            //    }
            //    Console.WriteLine();
            //}






            //int i;
            //int j;
            //int k;
            //int l;


            //for (i = 1; i <= 5; i++)
            //{
            //    for (j = 5; j > i; j--)
            //    {
            //        Console.Write("  ");
            //    }
            //    for (k = 1; k <= (2 * i - 1); k++)
            //    {
            //        Console.Write(k);
            //    }
            //    for (l = (2 * i - 2); l >= 1; l--)
            //    {
            //        Console.Write(l);
            //    }
            //    Console.WriteLine();

            //}




            


            

            int number = 109876;
            int Count = 0;

            while (number != 0)
            {
                Count++;
                number /= 10;
            }
            Console.WriteLine($"Count of digits in 109876 is : {Count}");
            
            Console.ReadKey();
        }
    }
}
