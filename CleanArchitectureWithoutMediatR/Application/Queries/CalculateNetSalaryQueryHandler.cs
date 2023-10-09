using CleanArchitectureWithoutMediatR.Domain;

namespace CleanArchitectureWithoutMediatR.Application.Queries
{
    public class CalculateNetSalaryQueryHandler : IQueryHandler<CalculateNetSalaryQuery, SalaryCalculation>
    {
        public SalaryCalculation Handle(CalculateNetSalaryQuery query)
        {
            decimal grossSalary = query.GrossSalary;

            decimal incomeTax = 0m;
            decimal socialContributions = 0m;
            decimal netSalary = 0m;

            if (grossSalary <= 1000m)
            {
                netSalary = grossSalary;
            }
            else
            {
                decimal taxableIncome = grossSalary - 1000m;

                if (taxableIncome > 0m)
                {
                    incomeTax = taxableIncome * 0.1m;
                    if (taxableIncome > 2000m)
                    {
                        socialContributions = 2000m * 0.15m;
                    }
                    else
                    {
                        socialContributions = taxableIncome * 0.15m;
                    }
                }

                netSalary = grossSalary - incomeTax - socialContributions;
            }
            var result = new SalaryCalculation
            {
                EmployeeName = query.EmployeeName,
                GrossSalary = grossSalary,
                NetSalary = netSalary,
                IncomeTax = incomeTax,
                SocialContributions = socialContributions
            };

            return result;
        }
    }
}
