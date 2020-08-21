using StudentLoanCalculator.Enums;
using System;

namespace StudentLoanCalculator.Views
{
    public class ProgramUserInteraction
    {
        public void GreetUser()
        {
            Console.WriteLine("Welcome to the Student Loan calculator!\n");
        }

        public CalculatorType GetCalculatorType()
        {
            Console.WriteLine("Please enter the numeric value of one option below:\n");
            Console.WriteLine("1 - Calculate Loan Repayment Time");
            Console.WriteLine("0 - Exit Program\n");

            var optionInput = Console.ReadLine();
            var isParseSuccess = Enum.TryParse<CalculatorType>(optionInput, out var calculatorType);

            if (!isParseSuccess)
            {
                Console.WriteLine("Unknown option selected.  Please select a valid option.\n");
            }

            return calculatorType;
        }

        public void ExitProgram()
        {
            Console.WriteLine("Exiting program.");
        }

        public void ReportInvalidCalculator()
        {
            Console.WriteLine("Unknown calculator type selected.  Please select a valid option.\n");
        }

        public bool IsMoreCalculatingRequested()
        {
            Console.WriteLine("Would you like to calculate something else? [y/n]\n");
            var response = Console.ReadLine();

            if (response.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
