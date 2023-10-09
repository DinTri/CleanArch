namespace CleanArchitectureWithoutMediatR.Application.Queries
{
    public class CalculateNetSalaryQuery
    {
        public string? EmployeeName { get; set; }
        public decimal GrossSalary { get; set; }
    }
}
