using TrifonCleanArch.Application.Services.Concrete;
using TrifonCleanArch.Infrastructure;

namespace TrifonCleanArch.Test
{
    public class CleanArchNetSalaryCalculatorTests
    {
        [Theory]
        [InlineData(3400, 2860, 240, 300)]
        [InlineData(1000, 1000, 0, 0)]
        [InlineData(980, 980, 0, 0)]
        public void CalculateNetSalary_Should_Return_Correct_NetSalary(decimal grossValue, decimal expectedNetValue, decimal expectedIncomeTax, decimal expectedSocialContributions)
        {
            // Arrange

            var salaryCalculatorService = new SalaryCalculatorService(new ImaginariaTaxCalculator(1000, 0.1), new ImaginariaSocialContributionsCalculator(0.15, 2000, 1000));

            // Act
            var salary = salaryCalculatorService.CalculateNetSalary(grossValue);

            // Assert
            Assert.Equal(expectedNetValue, salary.NetSalary);
            Assert.Equal(expectedIncomeTax, salary.IncomeTax);
            Assert.Equal(expectedSocialContributions, salary.SocialContributions);
        }
    }

    public class TaxationRules
    {
        public decimal NoTaxThreshold { get; set; }
        public decimal IncomeTaxRate { get; set; }
        public decimal SocialContributionsRate { get; set; }
        public decimal SocialContributionsMaxIncome { get; set; }
    }
}