using StudentLoanCalculator.Enums;

namespace StudentLoanCalculator.Models
{
    public class LoanRepaymentTimeModel
    {
        public double AnnualInterestRate { get; set; }

        public LoanTimeInterval CompoundTime { get; set; }

        public double LoanAmount { get; set; }

        public double PaymentAmount { get; set; }

        public LoanTimeInterval PaymentTime { get; set; }
    }
}