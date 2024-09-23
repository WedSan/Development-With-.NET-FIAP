using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1.command
{
    internal class SetOperatorCommand : ICalculatorCommand
    {
        private String calculatorOperator;

        private Calculator calculator;

        public SetOperatorCommand(String calculatorOperator, Calculator calculator)
        { 
            this.calculatorOperator = calculatorOperator;
            this.calculator = calculator;
        }

        public void Execute()
        {
            calculator.calculatorOperator = this.calculatorOperator;
            return;
        }
    }
}
