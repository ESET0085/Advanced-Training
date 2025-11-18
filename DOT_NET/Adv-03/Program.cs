namespace Adv_03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> food = new List<string>();
             food.Add("Apple");
            food.Add("Banana");
            food.Add("Carrot");

            food.Remove("Banana");
            food.ForEach(item => Console.WriteLine(item));



        }
    }






}
