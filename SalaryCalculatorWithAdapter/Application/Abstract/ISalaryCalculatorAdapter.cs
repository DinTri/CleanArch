using SalaryCalculatorWithAdapter.Domain;

namespace SalaryCalculatorWithAdapter.Application.Abstract
{
    public interface ISalaryCalculatorAdapter
    {
        Salary CalculateNetSalary(string? userName, double grossSalary);
    }
}
