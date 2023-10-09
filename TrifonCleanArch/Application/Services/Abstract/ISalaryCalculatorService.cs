using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Application.Services.Abstract
{
    public interface ISalaryCalculatorService
    {
        Salary CalculateNetSalary(decimal grossValue);
    }
}
