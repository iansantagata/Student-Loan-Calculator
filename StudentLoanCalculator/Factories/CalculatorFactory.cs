using StudentLoanCalculator.Calculators;
using StudentLoanCalculator.Enums;

namespace StudentLoanCalculator.Factories
{
    public class CalculatorFactory
    {
        public ICalculator SelectCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.LoanRepaymentTimeCalculator:
                    return new LoanRepaymentTimeCalculator();

                case CalculatorType.Unknown:
                case CalculatorType.None:
                default:
                    return null;
            }
        }
    }
}