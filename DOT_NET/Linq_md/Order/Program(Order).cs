var orders = new List<Order>
            {
                new Order{ OrderId=1001, CustomerId=1, Amount=2500, OrderDate=new DateTime(2025,5,12)},
                new Order{ OrderId=1002, CustomerId=2, Amount=1800, OrderDate=new DateTime(2025,5,13)},
                new Order{ OrderId=1003, CustomerId=1, Amount=4500, OrderDate=new DateTime(2025,5,20)},
                new Order{ OrderId=1004, CustomerId=3, Amount=6700, OrderDate=new DateTime(2025,6,01)},
                new Order{ OrderId=1005, CustomerId=4, Amount=2500, OrderDate=new DateTime(2025,6,02)},
                new Order{ OrderId=1006, CustomerId=2, Amount=5600, OrderDate=new DateTime(2025,6,10)},
                new Order{ OrderId=1007, CustomerId=5, Amount=3100, OrderDate=new DateTime(2025,6,12)},
                new Order{ OrderId=1008, CustomerId=3, Amount=7100, OrderDate=new DateTime(2025,7,01)},
                new Order{ OrderId=1009, CustomerId=4, Amount=4200, OrderDate=new DateTime(2025,7,05)},
                new Order{ OrderId=1010, CustomerId=5, Amount=2900, OrderDate=new DateTime(2025,7,10)}
            };


//1.Find total order amount per month.

var totalPerMonth = orders
    .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
    .Select(g => new
    {
        Month = $"{g.Key.Month}/{g.Key.Year}",
        TotalAmount = g.Sum(o => o.Amount)
    });

Console.WriteLine("1️⃣ Total Order Amount per Month:");
foreach (var item in totalPerMonth)
{
    Console.WriteLine($"{item.Month} : {item.TotalAmount}");
}
Console.WriteLine("---------------------------------\n");

//2.Show the customer who spent the most in total.
var topCustomer = orders
    .GroupBy(o => o.CustomerId)
    .Select(g => new { CustomerId = g.Key, TotalSpent = g.Sum(o => o.Amount) })
    .OrderByDescending(x => x.TotalSpent)
    .First();

Console.WriteLine("2️⃣ Customer Who Spent the Most:");
Console.WriteLine($"Customer ID: {topCustomer.CustomerId}, Total Spent: {topCustomer.TotalSpent}");
Console.WriteLine("---------------------------------\n");


//3.Display orders grouped by customer and show total amount spent.

var groupedByCustomer = orders
    .GroupBy(o => o.CustomerId)
    .Select(g => new
    {
        CustomerId = g.Key,
        TotalSpent = g.Sum(o => o.Amount),
        Orders = g.Select(o => new { o.OrderId, o.Amount, o.OrderDate })
    });

Console.WriteLine("3️⃣ Orders Grouped by Customer:");
foreach (var c in groupedByCustomer)
{
    Console.WriteLine($"Customer ID: {c.CustomerId}, Total Spent: {c.TotalSpent}");
    foreach (var order in c.Orders)
    {
        Console.WriteLine($"   Order ID: {order.OrderId}, Amount: {order.Amount}, Date: {order.OrderDate.ToShortDateString()}");
    }
    Console.WriteLine();
}
Console.WriteLine("---------------------------------\n");

//4.Display the top 2 orders with the highest amount.

var topOrders = orders
    .OrderByDescending(o => o.Amount)
    .Take(2);

Console.WriteLine("4️⃣ Top 2 Orders with Highest Amount:");
foreach (var o in topOrders)
{
    Console.WriteLine($"Order ID: {o.OrderId}, Amount: {o.Amount}, Date: {o.OrderDate.ToShortDateString()}");
}
Console.WriteLine("---------------------------------\n");