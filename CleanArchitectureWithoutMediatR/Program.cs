using CleanArchitectureWithoutMediatR.Application.Queries;
using CleanArchitectureWithoutMediatR.Utils;

namespace CleanArchitectureWithoutMediatR
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string? input;
            do
            {
                bool isValidUserName;
                string? employeeName;
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("Net Salary Calculator for the citizens of Imaginaria!");
                    Console.Write("Enter the Employee's name: ");
                    employeeName = Console.ReadLine();
                    isValidUserName = Validation.ValidateUserName(employeeName);
                    if (!isValidUserName)
                    {
                        Console.WriteLine(
                            "Invalid input. Please enter Employee's First Name & Last Name separated by a space, with only letters and spaces allowed.");
                    }
                } while (!isValidUserName);
                bool isValidGrossSalary = false;
                do
                {
                    Console.Write("Enter gross salary (in IDR): ");
                    input = Console.ReadLine();
                    if (input?.ToLower() == "p")
                    {
                        // User entered 'p', exit the loop
                        break;
                    }

                    isValidGrossSalary = decimal.TryParse(input, out decimal grossSalary);
                    if (!isValidGrossSalary)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number for the gross salary.");
                    }
                    if (isValidGrossSalary)
                    {
                        var query = new CalculateNetSalaryQuery
                        {
                            EmployeeName = employeeName,
                            GrossSalary = grossSalary
                        };

                        var queryHandler = new CalculateNetSalaryQueryHandler();
                        var result = queryHandler.Handle(query);

                        Console.WriteLine(
                            $"{result.EmployeeName}'s gross salary is: {result.GrossSalary} IDR, and Net Salary is: {result.NetSalary} IDR");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid gross salary.");
                    }
                } while (!isValidGrossSalary);
            } while (input?.ToLower() != "p");
        }
    }
}