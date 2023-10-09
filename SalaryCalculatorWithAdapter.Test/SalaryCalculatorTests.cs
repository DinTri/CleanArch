using SalaryCalculatorWithAdapter.Infrastructure;

namespace SalaryCalculatorWithAdapter.Test
{
    public class SalaryCalculatorTests
    {
        [Theory]
        [InlineData(3400, 240)]
        [InlineData(1000, 0)]
        [InlineData(980, 0)]
        public void CalculateIncomeTax_ShouldReturnCorrectTax(double grossSalary, decimal expectedTax)
        {
            // Arrange
            double taxThreshold = 1000;
            double incomeTaxRate = 0.1;
            ITaxCalculator taxCalculator = new ImaginariaTaxCalculator(taxThreshold, incomeTaxRate);

            // Act
            decimal actualTax = taxCalculator.CalculateIncomeTax(grossSalary);

            // Assert
            Assert.Equal(expectedTax, actualTax);
        }
    }

    public class SocialContributionsCalculatorTests
    {
        [Theory]
        [InlineData(3400, 300)]
        [InlineData(1000, 0)]
        [InlineData(980, 0)]
        public void CalculateSocialContributions_ShouldReturnCorrectContributions(double grossSalary, decimal expectedContributions)
        {
            // Arrange

            double taxThreshold = 1000;
            double socialContributionsRate = 0.15;
            double socialContributionsThreshold = 3000;
            ISocialContributionsCalculator socialContributionsCalculator = new ImaginariaSocialContributionsCalculator(socialContributionsRate, socialContributionsThreshold, taxThreshold);

            // Act
            decimal actualContributions = socialContributionsCalculator.CalculateSocialContributions(grossSalary);

            // Assert
            Assert.Equal(expectedContributions, actualContributions);
        }
    }
}