namespace TrifonCleanArch.Infrastructure
{
    public class ImaginariaTaxCalculator : ITaxCalculator
    {
        private readonly double _taxThreshold;
        private readonly double _incomeTaxRate;

        public ImaginariaTaxCalculator(double taxThreshold, double incomeTaxRate)
        {
            _taxThreshold = taxThreshold;
            _incomeTaxRate = incomeTaxRate;
        }

        public decimal CalculateIncomeTax(double grossSalary)
        {

            if (grossSalary <= _taxThreshold)
                return 0;
            decimal taxableIncome = (decimal)(grossSalary > _taxThreshold ? grossSalary - _taxThreshold : 0);
            return taxableIncome * (decimal)_incomeTaxRate;
        }
    }
}
