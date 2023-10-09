using SalaryCalculatorWithAdapter.Application.Abstract;
using SalaryCalculatorWithAdapter.Domain;
using SalaryCalculatorWithAdapter.Infrastructure;

namespace SalaryCalculatorWithAdapter.Application.Concrete
{
    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly ISocialContributionsCalculator _socialContributionsCalculator;

        public SalaryCalculator(ITaxCalculator taxCalculator, ISocialContributionsCalculator socialContributionsCalculator)
        {
            _taxCalculator = taxCalculator;
            _socialContributionsCalculator = socialContributionsCalculator;
        }

        public Salary CalculateNetSalary(string? userName, double grossSalary)
        {
            var salary = new Salary { UserName = userName, GrossSalary = grossSalary };

            decimal incomeTax = _taxCalculator.CalculateIncomeTax(grossSalary);
            decimal socialContributions = _socialContributionsCalculator.CalculateSocialContributions(grossSalary);

            salary.IncomeTax = incomeTax;
            salary.SocialContributions = socialContributions;
            salary.NetSalary = (decimal)grossSalary - incomeTax - socialContributions;

            return salary;
        }
    }
}
