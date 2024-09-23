using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkpoint_1.command
{
    internal class AddOperandCommand : ICalculatorCommand
    {
        private Calculator calculator;

        private Button button;

        public AddOperandCommand(Calculator calculator, Button buttonEvent)
        {
            this.calculator = calculator;
            this.button = buttonEvent;
        }

        public void Execute()
        {
            if (calculator.calculatorOperator == "")
            {
                calculator.firstOperand += button.Text;
            }
            else
            {
                calculator.secondOperand += button.Text;
            }
        }
    }

   
}
