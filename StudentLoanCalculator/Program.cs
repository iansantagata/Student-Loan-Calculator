using StudentLoanCalculator.Enums;
using StudentLoanCalculator.Factories;
using StudentLoanCalculator.Views;

namespace StudentLoanCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userInteraction = new ProgramUserInteraction();
            userInteraction.GreetUser();

            var calculatorFactory = new CalculatorFactory();

            while (true)
            {
                var calculatorType = userInteraction.GetCalculatorType();

                if (calculatorType == CalculatorType.None)
                {
                    userInteraction.ExitProgram();
                    return;
                }

                var calculator = calculatorFactory.SelectCalculator(calculatorType);

                if (calculator == null)
                {
                    userInteraction.ReportInvalidCalculator();
                }

                else
                {
                    calculator.GetCalculatorInput();
                    calculator.Calculate();
                    if (!userInteraction.IsMoreCalculatingRequested())
                    {
                        userInteraction.ExitProgram();
                        return;
                    }
                }
            }
        }
    }
}
