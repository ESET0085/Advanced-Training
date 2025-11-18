using System.Reflection;
using System.Runtime.CompilerServices;

var games = new List<Games>
{
    new Games { Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", ReleaseYear = 2017, Rating = 9.5, Price = 59 },
    new Games { Title = "God of War", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.3, Price = 49 },
    new Games { Title = "Red Dead Redemption 2", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.7, Price = 69 },
    new Games { Title = "The Witcher 3: Wild Hunt", Genre = "RPG", ReleaseYear = 2015, Rating = 9.4, Price = 39 },
    new Games { Title = "Minecraft", Genre = "Sandbox", ReleaseYear = 2011, Rating = 9.0, Price = 26 },
    new Games { Title = "Fortnite", Genre = "Battle Royale", ReleaseYear = 2017, Rating = 8.5, Price = 0 },
    new Games { Title = "Among Us", Genre = "Party", ReleaseYear = 2018, Rating = 8.0, Price = 5 },
    new Games { Title = "Cyberpunk 2077", Genre = "RPG", ReleaseYear = 2020, Rating = 7.5, Price = 59 },
    new Games { Title = "Hades", Genre = "Roguelike", ReleaseYear = 2020, Rating = 9.2, Price = 24 },
    new Games { Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseYear = 2020, Rating = 9.1, Price = 59 }
    

};


//var allGames = games.Select(g => g.Title);
//foreach (var title in games)
//{
//    Console.WriteLine(title);
//}

//Console.ReadLine();


//var Genregames = games.Where(g => g.Genre == "RPG");
//foreach (var item in Genregames)
//{
//    Console.WriteLine(item.Title);
//}

//Console.ReadLine();

//var moderngames = games.Any(g => g.ReleaseYear >= 2020);
//Console.WriteLine(moderngames);

//var modrngames = games.Where(g => g.ReleaseYear >= 2020);
//Console.WriteLine(modrngames);


//var sortbygames = games.OrderBy(g => g.ReleaseYear);
//foreach (var game in sortbygames)
//{
//    Console.WriteLine(sortbygames);
//}


//var avgprice = games.Average(g => g.Price);
//Console.WriteLine($"avg Games price :{avgprice}");


//var minvalues = games.Min(g => g.Price);
//Console.WriteLine($"min Games price :{minvalues}");


//var maxvalues = games.Max(g => g.Price);
//Console.WriteLine($"max Games price :{maxvalues}");



//var maxValue = games.Max(g => g.Rating);
//var first = games.First(g => g.Rating == maxValue);


//var groupbygenre = games.GroupBy(g => g.Genre);
//foreach (var group in groupbygenre)
//{
//    Console.WriteLine($"Genre: {group.Key}");
//    foreach (var game in group)
//    {
//        Console.WriteLine($" - {game.Title}");
//    }
//}

var multicondition = games.Where(g => g.Genre == "RPG" && g.ReleaseYear > 2011)
                          .OrderBy(n => n.ReleaseYear)
                          .Select(n => $" {n.Title} -- {n.Price} -- {n.Rating}");

foreach (var game in multicondition)
{
    Console.WriteLine(game);

}



 Console.ReadKey();
//namespace Linq
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//        }
//    }
//}
