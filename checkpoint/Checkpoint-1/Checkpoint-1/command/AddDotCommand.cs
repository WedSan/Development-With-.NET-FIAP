using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1.command
{
    internal class AddDotCommand : ICalculatorCommand
    {
        private Calculator calculator;
        
        public AddDotCommand(Calculator calculator) 
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            if (calculator.calculatorOperator == "")
            {
                if (!calculator.firstOperand.Contains(".") && calculator.firstOperand != "")
                {
                    calculator.firstOperand += ".";
                }
            }
            else
            {
                if (!calculator.secondOperand.Contains(".") && calculator.secondOperand != "")
                {
                    calculator.secondOperand += ".";
                }
            }
        }
    }
}
