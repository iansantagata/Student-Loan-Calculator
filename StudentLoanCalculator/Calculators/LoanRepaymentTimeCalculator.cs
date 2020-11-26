using StudentLoanCalculator.Enums;
using StudentLoanCalculator.Models;
using StudentLoanCalculator.Views;
using System;

namespace StudentLoanCalculator.Calculators
{
    public class LoanRepaymentTimeCalculator : ICalculator
    {
        private LoanRepaymentTimeModel _model { get; set; }
        private LoanRepaymentTimeUserInteraction _userInteraction { get; set; } = new LoanRepaymentTimeUserInteraction();

        public void GetCalculatorInput()
        {
            var interestRate = _userInteraction.GetInterestRate();
            var compoundTimeInterval = _userInteraction.GetInterestCompoundTimeInterval();
            var paymentSchedule = _userInteraction.GetPaymentSchedule();
            var paymentAmount = _userInteraction.GetPaymentAmount();
            var loanAmount = _userInteraction.GetLoanAmount();

            _model = new LoanRepaymentTimeModel
            {
                LoanAmount = loanAmount,
                AnnualInterestRate = interestRate,
                CompoundTime = compoundTimeInterval,
                PaymentAmount = paymentAmount,
                PaymentTime = paymentSchedule
            };
        }

        public void Calculate()
        {
            // Compound interest formula -- A = P (1 + r/n) ^ (n * t)
            // We can see how long it takes to pay off the loan when A becomes 0 and then solve for t

            var P = _model.LoanAmount; // Principal Amount
            var r = _model.AnnualInterestRate / 100.0d; // Annual Interest Rate (decimal)
            var t = 1; // One year
            var n = GetNumberOfTimesPerYearFromFrequency(_model.CompoundTime); // Number of times interest compounds per year

            var paymentAmount = _model.PaymentAmount;
            var paymentFrequency = GetNumberOfTimesPerYearFromFrequency(_model.PaymentTime);

            var isDiverging = false;
            var yearCount = 0;

            while (P > 0.0d && !isDiverging)
            {
                yearCount++;

                // Intermediate calculations, add the interest for a year
                var baseValue = 1 + (r / n);
                var exponent = n * t;
                var exponentiatedValue = Math.Pow(baseValue, exponent);
                var interestValue = exponentiatedValue * P;

                // Now subtract the amount payed for the year

                var principalAfterOneYear = interestValue - (paymentAmount * paymentFrequency);

                // If our cost after one year is greater than our cost that we started with, 
                // then our payments were not enough and the loan will never be paid off
                if (principalAfterOneYear >= P)
                {
                    isDiverging = true;
                }

                // Adjust our principal amount to be the amount we paid (plus interest added), and keep going
                P = principalAfterOneYear;
            }

            if (!isDiverging)
            {
                _userInteraction.ReportNumberOfYearsToFullyPayLoan(yearCount);
            }
            else
            {
                _userInteraction.ReportLoanWillNeverFullyBePaidOff();
            }
        }

        private int GetNumberOfTimesPerYearFromFrequency(LoanTimeInterval frequency)
        {
            switch (frequency)
            {
                case (LoanTimeInterval.Yearly):
                    return 1;

                case (LoanTimeInterval.Monthly):
                    return 12;

                case (LoanTimeInterval.BiWeekly):
                    return 26;

                case (LoanTimeInterval.SemiMonthly):
                    return 24;

                case (LoanTimeInterval.Weekly):
                    return 52;

                case (LoanTimeInterval.Daily):
                default:
                    return 365;
            }
        }
    }
}
