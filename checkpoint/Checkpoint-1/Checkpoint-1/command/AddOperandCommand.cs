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
                calculator.firstOperand = RemoveFirstZeroDigit(calculator.firstOperand);
                calculator.firstOperand += button.Text;
            }
            else
            {
                calculator.secondOperand = RemoveFirstZeroDigit(calculator.secondOperand);
                calculator.secondOperand += button.Text;
            }
        }

        private String RemoveFirstZeroDigit(String operand)
        {
            if (operand.Length == 1)
            {
                if (operand[0].Equals('0'))
                {
                    operand = operand.Remove(0, 1);
                }
            }
            return operand;
        }
    }

   
}
