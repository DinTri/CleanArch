using SalaryCalculatorWithAdapter.Application.Abstract;
using SalaryCalculatorWithAdapter.Application.Concrete;
using SalaryCalculatorWithAdapter.ConfigurationUtils;
using SalaryCalculatorWithAdapter.Domain;
using SalaryCalculatorWithAdapter.Infrastructure;
using SalaryCalculatorWithAdapter.Utils;

double taxThreshold = ConfigMethods.GetTaxThresholdFromConfig();
double incomeTaxRate = ConfigMethods.GetIncomeTaxRateFromConfig();
double socialContributionsRate = ConfigMethods.GetSocialContributionsRateFromConfig();
double socialContributionsThreshold = ConfigMethods.GetSocialContributionsThresholdFromConfig();

// Instantiate the tax calculator
ITaxCalculator taxCalculator = new ImaginariaTaxCalculator(taxThreshold, incomeTaxRate);

// Instantiate the social contributions calculator
ISocialContributionsCalculator socialContributionsCalculator = new ImaginariaSocialContributionsCalculator(socialContributionsRate, socialContributionsThreshold, taxThreshold);

// Instantiate the salary calculator
ISalaryCalculator salaryCalculator = new SalaryCalculator(taxCalculator, socialContributionsCalculator);
// Instantiate the adapter
ISalaryCalculatorAdapter adapter = new SalaryCalculatorAdapter(salaryCalculator);

string? input;
do
{
    // Read and validate the user name from user input
    string? userName;
    bool isValidUserName = false;
    do
    {
        Console.Write("Enter the user name: ");
        userName = Console.ReadLine();
        isValidUserName = Validation.ValidateUserName(userName);
        if (!isValidUserName)
        {
            Console.WriteLine("Invalid input. Please enter User's First Name and Last Name separated by a space, with only letters and spaces allowed.");
        }
    } while (!isValidUserName);

    double grossSalary = 0;
    bool isValidGrossSalary = false;
    do
    {
        Console.Write("Enter the gross salary. Enter 'p' to exit: ");
        input = Console.ReadLine();

        if (input?.ToLower() == "p")
        {
            // User entered 'p', exit the loop
            break;
        }

        isValidGrossSalary = double.TryParse(input, out grossSalary);
        if (!isValidGrossSalary)
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the gross salary.");
        }
    } while (!isValidGrossSalary);

    if (isValidGrossSalary)
    {
        Salary salary = adapter.CalculateNetSalary(userName, grossSalary);

        Console.WriteLine("User Name: " + salary.UserName);
        Console.WriteLine("Gross Salary: " + salary.GrossSalary + " IDR");
        Console.WriteLine("Income Tax: " + salary.IncomeTax + " IDR");
        Console.WriteLine("Social Contributions: " + salary.SocialContributions + " IDR");
        Console.WriteLine("Net Salary: " + salary.NetSalary + " IDR");
    }
} while (input?.ToLower() != "p");
