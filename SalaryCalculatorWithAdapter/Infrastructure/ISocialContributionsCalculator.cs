namespace SalaryCalculatorWithAdapter.Infrastructure
{
    public interface ISocialContributionsCalculator
    {
        decimal CalculateSocialContributions(double grossSalary);
    }
}
