using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1.command
{
    internal class CalculateCommand : ICalculatorCommand
    {

        private Calculator calculator;
        public CalculateCommand(Calculator calculator) 
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            if (calculator.firstOperand != "" && calculator.secondOperand != "")
            {
                double firstOperatorNumber = Double.Parse(calculator.firstOperand);
                double secondOperatorNumber = Double.Parse(calculator.secondOperand);


                if (calculator.calculatorOperator == "+")
                {
                    calculator.result = calculator.Sum(firstOperatorNumber, secondOperatorNumber);
                }
                else if (calculator.calculatorOperator == "-")
                {
                    calculator.result = calculator.Subtract(firstOperatorNumber, secondOperatorNumber);
                }
                else if (calculator.calculatorOperator == "X")
                {
                    calculator.result = calculator.Multiply(firstOperatorNumber, secondOperatorNumber);
                }
                else if (calculator.calculatorOperator == "÷")
                {
                    calculator.result = calculator.Divide(firstOperatorNumber, secondOperatorNumber);                    
                }
                else if (calculator.calculatorOperator == "%")
                {
                    calculator.result = calculator.CalculatePercentage(firstOperatorNumber, secondOperatorNumber);
                }
            }
        }
    }
}
