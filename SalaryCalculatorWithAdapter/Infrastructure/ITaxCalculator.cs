namespace SalaryCalculatorWithAdapter.Infrastructure
{
    public interface ITaxCalculator
    {
        decimal CalculateIncomeTax(double grossSalary);
    }
}
