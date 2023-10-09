using SalaryCalculatorWithAdapter.Application.Abstract;
using SalaryCalculatorWithAdapter.Domain;

namespace SalaryCalculatorWithAdapter.Application.Concrete
{
    public class SalaryCalculatorAdapter : ISalaryCalculatorAdapter
    {
        private readonly ISalaryCalculator _salaryCalculator;

        public SalaryCalculatorAdapter(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }

        public Salary CalculateNetSalary(string? userName, double grossSalary)
        {
            return _salaryCalculator.CalculateNetSalary(userName, grossSalary);
        }
    }
}
