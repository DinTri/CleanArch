using TrifonCleanArch.Application.Services.Abstract;
using TrifonCleanArch.Domain;
using TrifonCleanArch.Infrastructure;

namespace TrifonCleanArch.Application.Services.Concrete
{
    public class SalaryCalculatorService : ISalaryCalculatorService
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly ISocialContributionsCalculator _socialContributionsCalculator;

        public SalaryCalculatorService(ITaxCalculator taxCalculator, ISocialContributionsCalculator socialContributionsCalculator)
        {
            _taxCalculator = taxCalculator;
            _socialContributionsCalculator = socialContributionsCalculator;
        }
        public Salary CalculateNetSalary(decimal grossValue)
        {
            Salary salary = new Salary { GrossSalary = grossValue };

            if (grossValue <= 1000)
            {
                salary.NetSalary = grossValue;
                return salary;
            }

            decimal taxableIncome = grossValue - 1000;
            salary.IncomeTax = taxableIncome * 0.1m;
            if (taxableIncome > 0)
            {
                salary.IncomeTax = taxableIncome * 0.1m;
                if (taxableIncome > 2000)
                {
                    salary.SocialContributions = 2000 * 0.15m;
                }
                else
                {
                    salary.SocialContributions = taxableIncome * 0.15m;
                }
            }

            salary.NetSalary = grossValue - salary.IncomeTax - salary.SocialContributions;
            return salary;

        }
    }
}
