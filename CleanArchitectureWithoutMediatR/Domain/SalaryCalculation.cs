namespace CleanArchitectureWithoutMediatR.Domain
{
    public class SalaryCalculation
    {
        public string? EmployeeName { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal SocialContributions { get; set; }
        public decimal NetSalary { get; set; }
    }
}
