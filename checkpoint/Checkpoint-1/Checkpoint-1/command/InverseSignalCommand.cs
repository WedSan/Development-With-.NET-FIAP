﻿using System;
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
            if (calculator.calculatorOperator == "")
            {
                if (calculator.firstOperand.Contains("-"))
                {
                    calculator.firstOperand = calculator.firstOperand.Remove(0, 1);
                }
                else if (calculator.firstOperand != "")
                {
                    calculator.firstOperand = calculator.firstOperand.Insert(0, "-");
                }
            }
            else
            {
                if (calculator.secondOperand.Contains("-"))
                {
                    calculator.secondOperand = calculator.secondOperand.Remove(0, 1);
                }
                else if (calculator.secondOperand != "")
                {
                    calculator.secondOperand = calculator.secondOperand.Insert(0, "-");
                }
            }
        }
    }
}
