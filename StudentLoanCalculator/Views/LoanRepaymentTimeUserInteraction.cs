using StudentLoanCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLoanCalculator.Views
{
    public class LoanRepaymentTimeUserInteraction
    {
        private readonly Dictionary<int, string> _frequencyOptions = new Dictionary<int, string>
        {
            { 5, "Yearly" },
            { 4, "Monthly" },
            { 3, "Twice a month (Semi-Monthly)" },
            { 2, "Every other week (Bi-Weekly)" },
            { 1, "Weekly" },
            { 0, "Daily" }
        };

        public LoanTimeInterval GetInterestCompoundTimeInterval()
        {
            Console.WriteLine("Enter the number that best corresponds with how frequently interest is applied to your principal loan amount:");
            WriteFrequencyOptionsToConsole();

            var userInput = Console.ReadLine();
            var isParseSuccess = Enum.TryParse<LoanTimeInterval>(userInput, out var compoundTimeInterval);

            if (!isParseSuccess)
            {
                Console.WriteLine("Unknown option chosen.  Defaulting to `Daily` interest compounding.\n");
                return LoanTimeInterval.Daily;
            }

            var selectedOption = (int) compoundTimeInterval;
            Console.WriteLine($"You entered: {selectedOption} - {_frequencyOptions[selectedOption]}\n");
            return compoundTimeInterval;
        }

        public LoanTimeInterval GetPaymentSchedule()
        {
            Console.WriteLine("Enter the number that best corresponds with how frequently payments will be made toward this loan:");
            WriteFrequencyOptionsToConsole();

            var userInput = Console.ReadLine();
            var isParseSuccess = Enum.TryParse<LoanTimeInterval>(userInput, out var paymentSchedule);

            if (!isParseSuccess)
            {
                Console.WriteLine("Unknown option chosen.  Defaulting to `Monthly` payments.\n");
                return LoanTimeInterval.Monthly;
            }
            var selectedOption = (int) paymentSchedule;
            Console.WriteLine($"You entered: {selectedOption} - {_frequencyOptions[selectedOption]}\n");
            return paymentSchedule;
        }

        public double GetPaymentAmount()
        {
            Console.WriteLine("Enter the payment amount that will be paid each selected period (example - 1234.56):\n");

            var userInput = Console.ReadLine();
            var isParseSuccess = double.TryParse(userInput, out var paymentAmount);

            while (!isParseSuccess)
            {
                Console.WriteLine("Unknown amount enterred.  Please enter an amount in the format XXXX.XX where each X is a number\n");

                userInput = Console.ReadLine();
                isParseSuccess = double.TryParse(userInput, out paymentAmount);
            }

            Console.WriteLine($"You entered: ${paymentAmount}\n");
            return paymentAmount;
        }

        public double GetLoanAmount()
        {
            Console.WriteLine("Enter the principal amount for the loan (example - 1234.56):\n");

            var userInput = Console.ReadLine();
            var isParseSuccess = double.TryParse(userInput, out var loanAmount);

            while (!isParseSuccess)
            {
                Console.WriteLine("Unknown amount enterred.  Please enter an amount in the format XXXX.XX where each X is a number\n");

                userInput = Console.ReadLine();
                isParseSuccess = double.TryParse(userInput, out loanAmount);
            }

            Console.WriteLine($"You entered: ${loanAmount}\n");
            return loanAmount;
        }

        public double GetInterestRate()
        {
            Console.WriteLine("Enter the annual interest percent for the loan (example - 4.3):\n");

            var userInput = Console.ReadLine();
            var isParseSuccess = double.TryParse(userInput, out var interestRate);

            while (!isParseSuccess)
            {
                Console.WriteLine("Unknown interest rate enterred.  Please enter an interest rate in the format XXXX.XX where each X is a numerical percentage\n");

                userInput = Console.ReadLine();
                isParseSuccess = double.TryParse(userInput, out interestRate);
            }

            Console.WriteLine($"You entered: {interestRate}%\n");
            return interestRate;
        }

        public void ReportNumberOfYearsToFullyPayLoan(int years)
        {
            Console.WriteLine($"It will take {years} years in order to fully pay off this loan.\n");
        }

        public void ReportLoanWillNeverFullyBePaidOff()
        {
            Console.WriteLine("This loan will never fully be paid off at the current interest rate with the specified payment amount and frequency.\n");
        }

        private void WriteFrequencyOptionsToConsole()
        {
            _frequencyOptions.OrderByDescending(x => x);

            foreach (var frequencyOption in _frequencyOptions)
            {
                Console.WriteLine($"{frequencyOption.Key} - {frequencyOption.Value}");
            }

            Console.WriteLine();
        }
    }
}
