namespace TrifonCleanArch.Infrastructure
{
    public class ImaginariaSocialContributionsCalculator : ISocialContributionsCalculator
    {
        private readonly double _socialContributionsRate;
        private readonly double _socialContributionsThreshold;
        private readonly double _taxationThreshold;

        public ImaginariaSocialContributionsCalculator(double socialContributionsRate, double socialContributionsThreshold, double taxationThreshold)
        {
            _socialContributionsRate = socialContributionsRate;
            _socialContributionsThreshold = socialContributionsThreshold;
            _taxationThreshold = taxationThreshold;
        }

        public decimal CalculateSocialContributions(double grossSalary)
        {
            double taxableAmount = (grossSalary > _taxationThreshold ? grossSalary - _taxationThreshold : 0);
            double incomeTax = Math.Min(taxableAmount * (double)_taxationThreshold, 2000);
            double taxableIncome = Math.Min(incomeTax, _socialContributionsThreshold);
            return (decimal)(taxableIncome * _socialContributionsRate);
        }
    }
}
