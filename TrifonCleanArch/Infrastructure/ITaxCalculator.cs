namespace TrifonCleanArch.Infrastructure
{
    public interface ITaxCalculator
    {
        decimal CalculateIncomeTax(double grossSalary);
    }
}
