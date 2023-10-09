namespace TaxCalculator
{
    public static class TaxExtensions
    {
        public static decimal CalculateNetSalary(this double grossSalary)
        {
            double grSalary = grossSalary;

            double incomeTax = 0;
            double socialContributions = 0;
            double netSalary;

            if (grSalary <= 1000)
            {
                netSalary = grSalary;
            }
            else
            {
                double taxableIncome = grSalary - 1000;

                if (taxableIncome > 0)
                {
                    incomeTax = taxableIncome * 0.1;
                    if (taxableIncome > 2000)
                    {
                        socialContributions = 2000 * 0.15;
                    }
                    else
                    {
                        socialContributions = taxableIncome * 0.15;
                    }
                }

                netSalary = grSalary - incomeTax - socialContributions;

            }
            return (decimal)netSalary;
        }
    }
}
