using Microsoft.EntityFrameworkCore;
using TCSASystems.Blazor.EmployeeManagement.Data;
using TCSASystems.Blazor.EmployeeManagement.Models.Responses;

namespace TCSASystems.Blazor.EmployeeManagement.Services;

public interface IEmployeeService
{
    Task<GetAllEmployeesResponse> GetEmployees();
}

public class EmployeeService: IEmployeeService
{
    private readonly IDbContextFactory<DataContext> _factory;

    public EmployeeService(IDbContextFactory<DataContext> factory)
    {
        _factory = factory;
    }
    public async Task<GetAllEmployeesResponse> GetEmployees()
    {
        var response = new GetAllEmployeesResponse();
        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var employees = context.Employees.ToList();
                response.StatusCode = 200;
                response.StatusMessage = "Success";
                response.Employees = employees;
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.StatusMessage = "Error retrieving employees: " + ex.Message;
            response.Employees = null;
        }

        return response;
    }
}
