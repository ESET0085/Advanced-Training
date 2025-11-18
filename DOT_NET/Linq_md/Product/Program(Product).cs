using System.Security.Cryptography.X509Certificates;

var products = new List<Product>
            {
                new Product{ Id=1, Name="Laptop", Category="Electronics", Price=75000, Stock=15 },
                new Product{ Id=2, Name="Smartphone", Category="Electronics", Price=55000, Stock=25 },
                new Product{ Id=3, Name="Tablet", Category="Electronics", Price=30000, Stock=10 },
                new Product{ Id=4, Name="Headphones", Category="Accessories", Price=2000, Stock=100 },
                new Product{ Id=5, Name="Shirt", Category="Fashion", Price=1500, Stock=50 },
                new Product{ Id=6, Name="Jeans", Category="Fashion", Price=2200, Stock=30 },
                new Product{ Id=7, Name="Shoes", Category="Fashion", Price=3500, Stock=20 },
                new Product{ Id=8, Name="Refrigerator", Category="Appliances", Price=45000, Stock=8 },
                new Product{ Id=9, Name="Washing Machine", Category="Appliances", Price=38000, Stock=6 },
                new Product{ Id=10, Name="Microwave", Category="Appliances", Price=12000, Stock=12 }
 };


//1.Display all products with stock less than 20.
var list1 = products.Where(x => x.Stock < 20);
foreach (var item in list1)
{
    Console.WriteLine(item.Name);
}




Console.ReadLine();
 
//2. Show all products belonging to the “Fashion” category.

var list2 = products.Where(x =>x.Category == "Fashion");
foreach(var item in list2)
{
    Console.WriteLine(item.Name);
}

Console.ReadLine();

//3. Display product names and prices where price is greater than 10,000.

var list3 = products.Where(x => x.Price > 10000);
foreach (var item in list3)
{
    Console.WriteLine($"{item.Name} -- {item.Price}");
}

Console.ReadLine();

//4. List all product names sorted by price (descending).

var list4 = products.OrderByDescending(x => x.Name);
foreach (var item in list4)
{ 
    Console.WriteLine(item.Name); 
}

Console.ReadLine();

//5.Find the most expensive product in each category.

var list5 = products
    .GroupBy(x => x.Category)
    .Select(g => g.OrderByDescending(x => x.Price).First());

foreach (var item in list5)
{
    Console.WriteLine($"{item.Category} → {item.Name} ({item.Price})");
}

Console.ReadLine();


//6.Show total stock per category.
var list6 = products
    .GroupBy(x => x.Category)
    .Select(g => new { Category = g.Key, TotalStock = g.Sum(x => x.Stock) });

foreach (var item in list6)
{
    Console.WriteLine($"{item.Category} → Total Stock: {item.TotalStock}");
}

Console.ReadLine();


//7.Display products whose name starts with ‘S’.

var list7 = products.Where(x => x.Name.StartsWith("S"));
foreach (var item in list7)
{
    Console.WriteLine(item.Name);
}

Console.ReadLine();


//8.Show average price of products in each category.
var list8 = products
    .GroupBy(x => x.Category)
    .Select(g => new { Category = g.Key, AveragePrice = g.Average(x => x.Price) });

foreach (var item in list8)
{
    Console.WriteLine($"{item.Category} → Average Price: {item.AveragePrice:F2}");
}

Console.ReadLine();