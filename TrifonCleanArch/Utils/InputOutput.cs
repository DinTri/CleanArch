using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Utils
{
    public class InputOutput
    {
        public decimal GetGrossValue()
        {
            Console.Write("Enter the gross value: ");
            string? input = Console.ReadLine();
            decimal.TryParse(input, out var grossValue);
            return grossValue;
        }

        public void DisplayNetSalary(Salary salary)
        {
            Console.WriteLine($"Net Income: {salary.NetSalary} IDR");
            Console.WriteLine($"Income Tax: {salary.IncomeTax} IDR");
            Console.WriteLine($"Social Contributions: {salary.SocialContributions} IDR");
        }
    }
}
