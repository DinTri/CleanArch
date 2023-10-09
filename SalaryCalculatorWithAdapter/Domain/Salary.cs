namespace SalaryCalculatorWithAdapter.Domain
{
    public class Salary
    {
        public string? UserName { get; set; }
        public double GrossSalary { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal SocialContributions { get; set; }
        public decimal NetSalary { get; set; }
    }
}
