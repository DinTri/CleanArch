using MediatR;
using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Application.Commands
{
    public class CalculateNetSalaryCommand : IRequest<Salary>
    {
        public decimal GrossValue { get; }

        public CalculateNetSalaryCommand(decimal grossValue)
        {
            GrossValue = grossValue;
        }
    }
}
