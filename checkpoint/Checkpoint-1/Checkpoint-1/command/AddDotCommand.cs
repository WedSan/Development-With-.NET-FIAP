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
            if (calculator.operation == "")
            {
                if (!calculator.firstOperator.Contains(".") && calculator.firstOperator != "")
                {
                    calculator.firstOperator += ".";
                }
            }
            else
            {
                if (!calculator.secondOperator.Contains(".") && calculator.secondOperator != "")
                {
                    calculator.secondOperator += ".";
                }
            }
        }
    }
}
