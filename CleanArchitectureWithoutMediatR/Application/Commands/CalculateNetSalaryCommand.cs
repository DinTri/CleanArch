namespace CleanArchitectureWithoutMediatR.Application.Commands
{
    public class CalculateNetSalaryCommand
    {
        public string? EmployeeName { get; set; }
        public decimal GrossSalary { get; set; }
    }
}
