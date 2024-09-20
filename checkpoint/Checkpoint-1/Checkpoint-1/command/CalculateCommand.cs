using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1.command
{
    internal class CalculateCommand
    {

        private Calculator calculator;
        public CalculateCommand(Calculator calculator) 
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            if (calculator.firstOperator != "" && calculator.secondOperator != "")
            {
                double firstOperatorNumber = Double.Parse(calculator.firstOperator);
                double secondOperatorNumber = Double.Parse(calculator.secondOperator);


                if (calculator.operation == "+")
                {
                    calculator.result = calculator.Sum(firstOperatorNumber, secondOperatorNumber);
                }
                else if (calculator.operation == "-")
                {
                    calculator.result = calculator.Subtract(firstOperatorNumber, secondOperatorNumber);
                }
                else if (calculator.operation == "X")
                {
                    calculator.result = calculator.Multiply(firstOperatorNumber, secondOperatorNumber);
                }
                else if (calculator.operation == "÷")
                {
                    calculator.result = calculator.Divide(firstOperatorNumber, secondOperatorNumber);                    
                }
                else if (calculator.operation == "%")
                {
                    calculator.result = calculator.CalculatePercentage(firstOperatorNumber, secondOperatorNumber);
                }
            }
        }
    }
}
