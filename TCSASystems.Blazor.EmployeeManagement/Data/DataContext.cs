using Bogus;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCSASystems.Blazor.EmployeeManagement.Models;

namespace TCSASystems.Blazor.EmployeeManagement.Data;

public class DataContext: IdentityDbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasData(GetEmployees());
    }

    private List<Employee> GetEmployees()
    {
        var employees = new List<Employee>();
        var faker = new Faker("en"); // Specify the language for name generation

        for (int i = 1; i <= 50; i++)
        {
            var employee = new Employee
            {
                Id = i,
                ImgUrl = faker.Internet.Avatar(),
                Name = faker.Name.FullName(),
                Salary = GetRandomSalary(),
                Type = GetRandomEmployeeType(),
                Position = GetRandomPosition()
            };

            employees.Add(employee);
        }

        return employees;
    }

    private decimal GetRandomSalary()
    {
        var random = new Random();
        decimal salary = random.Next(30000, 100000); // Generates a random salary between $30,000 and $100,000
        return salary;
    }

    // Method to get a random employee type
    private EmployeeType GetRandomEmployeeType()
    {
        var random = new Random();
        var types = Enum.GetValues(typeof(EmployeeType));
        return (EmployeeType)types.GetValue(random.Next(types.Length));
    }

    // Method to get a random position
    private Position GetRandomPosition()
    {
        var random = new Random();
        var positions = Enum.GetValues(typeof(Position));
        return (Position)positions.GetValue(random.Next(positions.Length));
    }
}
