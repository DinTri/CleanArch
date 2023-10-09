using MediatR;
using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Application.Queries
{
    public class CalculateNetSalaryQuery : IRequest<Salary>
    {
        public decimal GrossValue { get; }

        public CalculateNetSalaryQuery(decimal grossValue)
        {
            GrossValue = grossValue;
        }
    }
}
