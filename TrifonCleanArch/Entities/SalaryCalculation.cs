using TrifonCleanArch.Application.Abstract;
using TrifonCleanArch.Domain;
using TrifonCleanArch.Infrastructure;

namespace TrifonCleanArch.Entities
{
    public class SalaryCalculation : ISalaryCalculator
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly ISocialContributionsCalculator _socialContributionsCalculator;

        public SalaryCalculation(ITaxCalculator taxCalculator, ISocialContributionsCalculator socialContributionsCalculator)
        {
            _taxCalculator = taxCalculator;
            _socialContributionsCalculator = socialContributionsCalculator;
        }


        public Salary CalculateNetAmount(double grossSalary)
        {
            var salary = new Salary { GrossSalary = (decimal)grossSalary };

            decimal incomeTax = _taxCalculator.CalculateIncomeTax(grossSalary);
            decimal socialContributions = _socialContributionsCalculator.CalculateSocialContributions(grossSalary);

            salary.IncomeTax = incomeTax;
            salary.SocialContributions = socialContributions;
            salary.NetSalary = (decimal)grossSalary - incomeTax - socialContributions;

            return salary;
        }
    }
}
