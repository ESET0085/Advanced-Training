namespace CS._3._017
{

    abstract class AlarmRule
    {
        public string Name { get; }
        protected AlarmRule(string name) => Name = name;
        public abstract bool IsTriggered(LoadProfileDay day);
        public virtual string Message(LoadProfileDay day)
            => $"{Name} triggered on {day.Date:yyyy-MM-dd}";
    }

    class PeakOveruseRule : AlarmRule
    {   
        private readonly int _threshold;
        public PeakOveruseRule(int threshold) : base("PeakOveruse") => _threshold = threshold;
        public override bool IsTriggered(LoadProfileDay day) => day.Total > _threshold;
    }

    class SustainedOutageRule : AlarmRule
    {   
        private readonly int _minConsecutive;
        public SustainedOutageRule(int min) : base("SustainedOutage") => _minConsecutive = min;
        public override bool IsTriggered(LoadProfileDay day) 
        { 
            int consecutive = 0;
            foreach (var usage in day.HourlyUsage)
            {
                if (usage == 0)
                {
                    consecutive++;
                    if (consecutive >= _minConsecutive)
                        return true;
                }
                else
                {
                    consecutive = 0;
                }
            }
            return false;
        }
    }

    public record LoadProfileDay(DateOnly Date, int[] HourlyUsage)
    {
        public int Total => HourlyUsage.Sum();
    }
     
    

     








    internal class Program
    {
        static void Main(string[] args)
        {
            var rules = new AlarmRule[]
            {
                new PeakOveruseRule(100),
                new SustainedOutageRule(3)
            };
            var days = new LoadProfileDay[]
            {
                new LoadProfileDay(new DateOnly(2023, 10, 1), new int[] { 10, 20, 30, 0, 0, 0, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210 }),
                new LoadProfileDay(new DateOnly(2023, 10, 2), new int[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240 })

            };
               foreach (var day in days)
            {
                foreach (var rule in rules)
                {
                    if (rule.IsTriggered(day))
                    {
                        Console.WriteLine(rule.Message(day));
                    }
                }
            }
        }
    }
}

