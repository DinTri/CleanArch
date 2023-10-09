using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Application.Abstract
{
    public interface ISalaryCalculator
    {
        Salary CalculateNetAmount(double grossSalary);
    }
}
