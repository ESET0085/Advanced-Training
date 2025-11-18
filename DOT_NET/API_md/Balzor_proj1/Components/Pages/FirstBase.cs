using DataAccess;
using Microsoft.AspNetCore.Components;

namespace Balzor_proj1.Components.Pages
{
    public class FirstBase: ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            Employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Position = "Developer" },
                new Employee { Id = 2, Name = "Bob", Position = "Designer" },
                new Employee { Id = 3, Name = "Charlie", Position = "Manager" }
            };
        }

        


    }
}








