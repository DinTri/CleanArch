using Microsoft.Extensions.Configuration;

namespace TrifonCleanArch.ConfigurationUtils
{
    public static class ConfigMethods
    {
        static readonly IConfiguration Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        public static double GetTaxThresholdFromConfig()
        {

            return Config.GetValue<double>("TaxThreshold");
        }

        public static double GetIncomeTaxRateFromConfig()
        {
            return Config.GetValue<double>("IncomeTaxRate");
        }

        public static double GetSocialContributionsRateFromConfig()
        {
            return Config.GetValue<double>("SocialContributionsRate");
        }

        public static double GetSocialContributionsThresholdFromConfig()
        {
            return Config.GetValue<double>("SocialContributionsThreshold");
        }
    }
}
