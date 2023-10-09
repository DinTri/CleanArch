using CleanArchitectureWithoutMediatR.Application.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Xunit.Assert;

namespace NetSalaryCalculatorWithoutMediatR.Tests
{
    public class NetSalaryCalculatorTests
    {
        [Fact]
        public void CalculateNetSalary_ShouldCalculateCorrectNetSalary()
        {
            // Arrange
            var query = new CalculateNetSalaryQuery
            {
                EmployeeName = "Hannah",
                GrossSalary = 3400m
            };

            var queryHandler = new CalculateNetSalaryQueryHandler();

            // Act
            var result = queryHandler.Handle(query);

            // Assert
            Assert.Equal("Hannah", result.EmployeeName);
            Assert.Equal(3400m, result.GrossSalary);
            Assert.Equal(2860m, result.NetSalary);
        }

        [DataTestMethod]
        [DataRow(3400.0, 2860.0)]
        [DataRow(1000.0, 1000.0)]
        [DataRow(980.0, 980.0)]
        public void CalculateNetSalaryWithInlineData_ShouldCalculateCorrectNetSalary(double grossSalary, double expectedNetSalary)
        {
            // Arrange
            var query = new CalculateNetSalaryQuery
            {
                EmployeeName = "Melissa",
                GrossSalary = Convert.ToDecimal(grossSalary)
            };

            var queryHandler = new CalculateNetSalaryQueryHandler();

            // Act
            var result = queryHandler.Handle(query);

            // Assert
            Assert.Equal(Convert.ToDecimal(expectedNetSalary), result.NetSalary);
        }
    }
}