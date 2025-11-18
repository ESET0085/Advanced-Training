namespace CS._3._018
{

    public interface IDataIngestor
    {
        string Name { get; }
        IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }

    public class dlmsIngestor : IDataIngestor
    {
        public string Name => "DLMS Ingestor";
        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return (DateTime.Now.AddMinutes(-i), new Random().Next(100, 500));
            }
        }
    }


    public class CsvIngestor : IDataIngestor
    {
        public string Name => "CSV Ingestor";
        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return (DateTime.Now.AddMinutes(-i), new Random().Next(100, 500));
            }
        }
    }
    public class RandomOutageDecorator : IDataIngestor
    {
        private readonly IDataIngestor _innerIngestor;
        private readonly double _outageProbability;
        private readonly Random _random;
        public RandomOutageDecorator(IDataIngestor innerIngestor, double outageProbability)
        {
            _innerIngestor = innerIngestor;
            _outageProbability = outageProbability;
            _random = new Random();
        }
        public string Name => $"{_innerIngestor.Name} with Random Outages";
        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            foreach (var data in _innerIngestor.ReadBatch(count))
            {
                if (_random.NextDouble() >= _outageProbability)
                {
                    yield return data;
                }
                else
                {
                    // Simulate an outage by skipping this data point
                    Console.WriteLine($"Outage occurred at {data.ts}");
                }
            }
        }


















        internal class Program
        {
            static void Main(string[] args)
            {

                //Wrap new DlmsIngestor() with RandomOutageDecorator.
                IDataIngestor ingestor = new RandomOutageDecorator(new dlmsIngestor(), 0.3);
                foreach (var data in ingestor.ReadBatch(10))
                {
                   // Console.WriteLine($"{data.ts}: {data.kwh} kWh");
                }

                //Call ReadBatch(10) and print 10 lines ts -> kwh.
                ingestor = new RandomOutageDecorator(new CsvIngestor(), 0.2);
                foreach (var data in ingestor.ReadBatch(10))
                {
                    Console.WriteLine($"{data.ts}: {data.kwh} kWh");
                }








            }

        }
    }
}