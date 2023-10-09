namespace TrifonCleanArch.Domain
{
    public class Salary
    {
        public string? UserName { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal SocialContributions { get; set; }
        public decimal NetSalary { get; set; }
    }
}
