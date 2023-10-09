using TaxCalculator.Utils;

namespace TaxCalculator;

static class Program
{
    private static void Main(string[] args)
    {
        string? input;
        string? userName;
        bool isValidUserName;
        do
        {
            Console.Write("Enter the Employee's name: ");
            userName = Console.ReadLine();
            isValidUserName = Validation.ValidateUserName(userName);
            if (!isValidUserName)
            {
                Console.WriteLine("Invalid input. Please enter Employee's First Name & Last Name separated by a space, with only letters and spaces allowed.");
            }
        } while (!isValidUserName);
        do
        {

            bool isValidGrossSalary = false;
            double grossSalary = 0;
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

            if (!isValidGrossSalary) continue;
            decimal netSalary = grossSalary.CalculateNetSalary();
            Console.WriteLine($"Employee: {userName} has Net salary: {netSalary} IDR");

        } while (input?.ToLower() != "p");

    }
}