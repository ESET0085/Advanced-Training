var students = new List<Student>
{
                new Student{ Id=1, Name="Asha", Course="C#", Marks=92, City="Bangalore"},
                new Student{ Id=2, Name="Ravi", Course="Java", Marks=85, City="Pune"},
                new Student{ Id=3, Name="Sneha", Course="Python", Marks=78, City="Hyderabad"},
                new Student{ Id=4, Name="Kiran", Course="C#", Marks=88, City="Delhi"},
                new Student{ Id=5, Name="Meena", Course="Python", Marks=95, City="Bangalore"},
                new Student{ Id=6, Name="Vijay", Course="C#", Marks=82, City="Chennai"},
                new Student{ Id=7, Name="Deepa", Course="Java", Marks=91, City="Mumbai"},
                new Student{ Id=8, Name="Arjun", Course="Python", Marks=89, City="Hyderabad"},
                new Student{ Id=9, Name="Priya", Course="C#", Marks=97, City="Pune"},
                new Student{ Id=10, Name="Rohit", Course="Java", Marks=74, City="Delhi"}
};

//1.Find the highest scorer in each course.

var topScorers = students
    .GroupBy(s => s.Course)
    .Select(g => g.OrderByDescending(s => s.Marks).First());

Console.WriteLine("1️⃣ Highest Scorer in Each Course:");
foreach (var s in topScorers)
{
    Console.WriteLine($"{s.Course} → {s.Name} ({s.Marks})");
}
Console.WriteLine("---------------------------------\n");



//2.Display average marks of all students city-wise.

var avgMarksByCity = students
    .GroupBy(s => s.City)
    .Select(g => new { City = g.Key, AverageMarks = g.Average(s => s.Marks) });

Console.WriteLine("2️⃣ Average Marks City-wise:");
foreach (var item in avgMarksByCity)
{
    Console.WriteLine($"{item.City} => {item.AverageMarks:F2}");
}
Console.WriteLine("---------------------------------\n");


//3.Display names and marks of students ranked by marks.

var rankedStudents = students
    .OrderByDescending(s => s.Marks)
    .Select((s, index) => new { Rank = index + 1, s.Name, s.Marks });

Console.WriteLine("3️⃣ Students Ranked by Marks:");
foreach (var s in rankedStudents)
{
    Console.WriteLine($"Rank {s.Rank}: {s.Name} ({s.Marks})");
}
Console.WriteLine("---------------------------------\n");
