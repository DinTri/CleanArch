using TaxCalculator.Utils;

namespace TaxCalculator.Test
{
    public class NetSalaryCalculatorTests
    {
        [Fact]
        public void CalculateNetSalary_WithGrossSalaryBelowThreshold_ReturnsGrossSalary()
        {
            // Arrange
            double grossSalary = 980;

            // Act
            decimal netSalary = grossSalary.CalculateNetSalary();

            // Assert
            Assert.Equal((decimal)grossSalary, netSalary);
        }

        [Fact]
        public void CalculateNetSalary_WithGrossSalaryAboveThreshold_ReturnsCorrectNetSalary()
        {
            // Arrange
            double grossSalary = 2650;
            decimal expectedNetSalary = 2237.50m;

            // Act
            decimal netSalary = grossSalary.CalculateNetSalary();

            // Assert
            Assert.Equal(expectedNetSalary, netSalary);
        }

        [Theory]
        [InlineData(3400, 2860)]
        [InlineData(1000, 1000)]
        [InlineData(980, 980)]
        public void CalculateNetSalary_WithVariousGrossSalaries_ReturnsCorrectNetSalary(double grossSalary, decimal expectedNetSalary)
        {
            // Act
            decimal netSalary = grossSalary.CalculateNetSalary();

            // Assert
            Assert.Equal(expectedNetSalary, netSalary);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", false)]
        [InlineData("Jane", false)]
        [InlineData("Melissa Thompson", true)]
        [InlineData("Hannah567 Smith", false)]
        [InlineData("Jane#Brown", false)]
        [InlineData("Molly@Fields", false)]
        public void ValidateUserName_ShouldReturnCorrectValidationResult(string userName, bool expectedValidationResult)
        {
            // Act
            bool actualValidationResult = Validation.ValidateUserName(userName);

            // Assert
            Assert.Equal(expectedValidationResult, actualValidationResult);
        }
    }
}