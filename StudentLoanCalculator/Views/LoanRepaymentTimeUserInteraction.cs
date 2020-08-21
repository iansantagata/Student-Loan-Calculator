using StudentLoanCalculator.Enums;
using System;

namespace StudentLoanCalculator.Views
{
    public class LoanRepaymentTimeUserInteraction
    {
        public LoanTimeInterval GetInterestCompoundTimeInterval()
        {
            Console.WriteLine("Enter the number that best corresponds with how frequently interest is applied to your principal loan amount:");
            Console.WriteLine("5 - Yearly");
            Console.WriteLine("4 - Monthly");
            Console.WriteLine("3 - Twice a month (Semi-Monthly)");
            Console.WriteLine("2 - Every other week (Bi-Weekly)");
            Console.WriteLine("1 - Weekly");
            Console.WriteLine("0 - Daily\n");

            var userInput = Console.ReadLine();
            var isParseSuccess = Enum.TryParse<LoanTimeInterval>(userInput, out var compoundTimeInterval);

            if (!isParseSuccess)
            {
                Console.WriteLine("Unknown option chosen.  Defaulting to `Daily` interest compounding.\n");
                return LoanTimeInterval.Daily;
            }

            return compoundTimeInterval;
        }

        public LoanTimeInterval GetPaymentSchedule()
        {
            Console.WriteLine("Enter the number that best corresponds with how frequently payments will be made toward this loan:");
            Console.WriteLine("5 - Yearly");
            Console.WriteLine("4 - Monthly");
            Console.WriteLine("3 - Twice a month (Semi-Monthly)");
            Console.WriteLine("2 - Every other week (Bi-Weekly)");
            Console.WriteLine("1 - Weekly");
            Console.WriteLine("0 - Daily\n");

            var userInput = Console.ReadLine();
            var isParseSuccess = Enum.TryParse<LoanTimeInterval>(userInput, out var paymentSchedule);

            if (!isParseSuccess)
            {
                Console.WriteLine("Unknown option chosen.  Defaulting to `Monthly` payments.\n");
                return LoanTimeInterval.Monthly;
            }

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

            return loanAmount;
        }

        public double GetInterestRate()
        {
            Console.WriteLine("Enter the annual interest percent for the loan (example - 4.3):\n");

            var userInput = Console.ReadLine();
            var isParseSuccess = double.TryParse(userInput, out var interestRate);

            while (!isParseSuccess)
            {
                Console.WriteLine("Unknown interest rate enterred.  Please enter an interest rate in the format XXXX.XX where each X is a number\n");

                userInput = Console.ReadLine();
                isParseSuccess = double.TryParse(userInput, out interestRate);
            }

            return interestRate;
        }

        public void ReportNumberOfYearsToFullyPayLoan(int years)
        {
            Console.WriteLine($"It will take {years} years in order to fully pay off this loan.\n");
        }
    }
}
