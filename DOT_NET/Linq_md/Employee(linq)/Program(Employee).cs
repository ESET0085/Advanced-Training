using System.Runtime.CompilerServices;


var employees = new List<Employee>
{
                new Employee{ Id=1, Name="Ravi", Department="IT", Salary=85000, Experience=5, Location="Bangalore"},
                new Employee{ Id=2, Name="Priya", Department="HR", Salary=52000, Experience=4, Location="Pune"},
                new Employee{ Id=3, Name="Kiran", Department="Finance", Salary=73000, Experience=6, Location="Hyderabad"},
                new Employee{ Id=4, Name="Asha", Department="IT", Salary=95000, Experience=8, Location="Bangalore"},
                new Employee{ Id=5, Name="Vijay", Department="Marketing", Salary=68000, Experience=5, Location="Mumbai"},
                new Employee{ Id=6, Name="Deepa", Department="HR", Salary=61000, Experience=7, Location="Delhi"},
                new Employee{ Id=7, Name="Arjun", Department="Finance", Salary=82000, Experience=9, Location="Bangalore"},
                new Employee{ Id=8, Name="Sneha", Department="IT", Salary=78000, Experience=4, Location="Pune"},
                new Employee{ Id=9, Name="Rohit", Department="Marketing", Salary=90000, Experience=10, Location="Delhi"},
                new Employee{ Id=10, Name="Meena", Department="Finance", Salary=66000, Experience=3, Location="Mumbai"}
};


//1.Display all employees working in the IT department.

var IT_dept = employees.Where(employees => employees.Department == "IT");
foreach (var employee in IT_dept)
{
    Console.WriteLine(employee.Name);

}

Console.ReadLine();

//2.List names and salaries of employees who earn more than 70,000.

var list3 = employees.Where(e => e.Salary > 70000)
                     .Select(e => $"{ e.Name} -- {e.Salary}");

 foreach(var employee in list3)
{
    Console.WriteLine(employee);
}


 Console.ReadLine();
//3.Find all employees located in Bangalore.

var list1 = employees.Where(employees => employees.Location == "Bangalore");
foreach (var employee in list1)
{
    Console.WriteLine(employee.Name);
}
Console.ReadLine();

//4.Display employees having more than 5 years of experience.

var list2 = employees.Where(e => e.Experience > 5);
foreach (var employee in list2)
{
    Console.WriteLine(employee.Name);
}
Console.ReadLine();

//5.Show names of employees and their salaries in ascending order of salary.

var multicond = employees.OrderBy(e => e.Salary)
                    .Select(e => $"{e.Name} -- {e.Salary}");

foreach (var employee in multicond)
{
    Console.WriteLine(employee);
}

Console.ReadLine();


//6.Group employees by location and count how many employees are in each location.

var groupby = employees.GroupBy(e => e.Location);
Console.WriteLine($"Location :{groupby:key},Count : {groupby.Count()}");




Console.ReadLine();



//7.Display employees whose salary is above the average salary.

var avgsalary = employees.Average(e => e.Salary);


var list5 = employees.Where(e => e.Salary > avgsalary);
foreach (var employee in list5)
{ 
    Console.WriteLine(employee.Name);
}

Console.ReadLine();
//8.Show top 3 highest-paid employees.

var list7 = employees.OrderByDescending(e => e.Salary).Take(3);
foreach(var employee in list7)
{
    Console.WriteLine(employee.Name);
}


