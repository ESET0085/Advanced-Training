namespace CS._2._016
{

    class LoadProfileDay
    {
        public DateTime Date { get; }
        public int[] HourlyKwh { get; } 
        public LoadProfileDay(DateTime date, int[] hourly)
        {
            Date = date;
            HourlyKwh = hourly;
            Total = 0;
            PeakHour = 0;
            for (int i = 0; i < HourlyKwh.Length; i++)
            {
                Total += HourlyKwh[i];
                if (HourlyKwh[i] > HourlyKwh[PeakHour])
                {
                    PeakHour = i;
                }
            }




        }
        public int Total;
        public int PeakHour;


    }



    internal class Program
    {
        static void Main(string[] args)
        {

            var profile = new LoadProfileDay(new DateTime(2023, 1, 1), 
                          new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 });
            Console.WriteLine($"Date: {profile.Date.ToShortDateString()}," +
                              $" Total: {profile.Total}, Peak Hour: {profile.PeakHour}");

        }
    }
}

