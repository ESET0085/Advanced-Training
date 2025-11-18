using System;
using System.Collections.Generic;

public interface IReadable
{
    int ReadKwh();             
    string SourceId { get; }
}


public class DlmsMeter : IReadable
{
    private static Random random2 = new Random();
    public string SourceId { get; }

    public DlmsMeter(string id)
    {
        SourceId = id;
    }

    public int ReadKwh()
    {
        return random2.Next(1, 11);  
    }
}

public class ModemGateway : IReadable
{
    private static Random random1 = new Random();
    public string SourceId { get; }

    public ModemGateway(string id)
    {
        SourceId = id;
    }

    public int ReadKwh()
    {
        return random1.Next(0, 3);  
    }
}


public class Program
{
    public static void Main()
    {
        
        List<IReadable> devices = new List<IReadable>
        {
            new DlmsMeter("AP-0001"),
            new ModemGateway("GW-21")
        };

        
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($" Poll - {i} ");
            foreach (var device in devices)
            {
                int delta = device.ReadKwh();
                Console.WriteLine($"{device.SourceId} -> {delta}");
            }
            Console.ReadLine();
        }
    }
}