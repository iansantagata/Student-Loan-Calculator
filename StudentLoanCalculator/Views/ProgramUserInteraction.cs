using StudentLoanCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLoanCalculator.Views
{
    public class ProgramUserInteraction
    {
        private readonly Dictionary<int, string> _calculatorOptions = new Dictionary<int, string>
        {
            { 1, "Calculate Loan Repayment Time" },
            { 0, "Exit Program" }
        };

        public void GreetUser()
        {
            Console.WriteLine("Welcome to the Student Loan calculator!\n");
        }

        public CalculatorType GetCalculatorType()
        {
            Console.WriteLine("Please enter the numeric value of one option below:\n");
            WriteCalculatorOptionsToConsole();

            var optionInput = Console.ReadLine();
            var isParseSuccess = Enum.TryParse<CalculatorType>(optionInput, out var calculatorType);

            if (!isParseSuccess)
            {
                Console.WriteLine("Unknown option selected.  Please select a valid option.\n");
            }

            var selectedOption = (int) calculatorType;
            Console.WriteLine($"You selected: {selectedOption} - {_calculatorOptions[selectedOption]}\n");
            return calculatorType;
        }

        public void ExitProgram()
        {
            Console.WriteLine("Exiting program.\n");
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

        private void WriteCalculatorOptionsToConsole()
        {
            _calculatorOptions.OrderByDescending(x => x);

            foreach (var calculatorOption in _calculatorOptions)
            {
                Console.WriteLine($"{calculatorOption.Key} - {calculatorOption.Value}");
            }

            Console.WriteLine();
        }
    }
}
