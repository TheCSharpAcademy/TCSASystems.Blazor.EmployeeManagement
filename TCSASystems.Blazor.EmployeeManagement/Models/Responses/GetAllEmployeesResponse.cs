namespace TCSASystems.Blazor.EmployeeManagement.Models.Responses;

public class GetAllEmployeesResponse: EmployeeResponse
{
    public List<Employee>? Employees { get; set; }
}
