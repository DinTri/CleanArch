using SalaryCalculatorWithAdapter.Domain;

namespace SalaryCalculatorWithAdapter.Application.Abstract
{
    public interface ISalaryCalculator
    {
        Salary CalculateNetSalary(string? userName, double grossSalary);
    }
}
