using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TCSASystems.Blazor.EmployeeManagement.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public decimal Salary { get; set; }
    public EmployeeType Type { get; set; }
    public Position Position { get; set; }
}

public enum EmployeeType
{
    [Display(Name = "Freelance")]
    Freelance,

    [Display(Name = "Casual")]
    Casual,

    [Display(Name = "Part Time")]
    PartTime,

    [Display(Name = "Full Time")]
    FullTime
}

public enum Position
{
    [Display(Name = "CEO")]
    CEO,

    [Display(Name = "CFO")]
    CFO,

    [Display(Name = "CTO")]
    CTO,

    [Display(Name = "Accountant")]
    Accountant,

    [Display(Name = "HR Manager")]
    HRManager,

    [Display(Name = "Marketing Manager")]
    MarketingManager,

    [Display(Name = "Sales Manager")]
    SalesManager,

    [Display(Name = "Software Engineer")]
    SoftwareEngineer,

    [Display(Name = "Data Analyst")]
    DataAnalyst,

    [Display(Name = "Customer Support")]
    CustomerSupport
}

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
          .GetMember(enumValue.ToString())
          .First()
          .GetCustomAttribute<DisplayAttribute>()
          ?.GetName();
    }
}
