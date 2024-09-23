using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1.command
{
    internal class InverseSignalCommand : ICalculatorCommand
    {
        private Calculator calculator;

        public InverseSignalCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }


        public void Execute()
        {
            if (calculator.operation == "")
            {
                if (calculator.firstOperator.Contains("-"))
                {
                    calculator.firstOperator = calculator.firstOperator.Remove(0, 1);
                }
                else if (calculator.firstOperator != "")
                {
                    calculator.firstOperator = calculator.firstOperator.Insert(0, "-");
                }
            }
            else
            {
                if (calculator.secondOperator.Contains("-"))
                {
                    calculator.secondOperator = calculator.secondOperator.Remove(0, 1);
                }
                else if (calculator.secondOperator != "")
                {
                    calculator.secondOperator = calculator.secondOperator.Insert(0, "-");
                }
            }
        }
    }
}
