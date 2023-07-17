using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TCSASystems.Blazor.EmployeeManagement.Data;

public class DataContext: IdentityDbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
}
