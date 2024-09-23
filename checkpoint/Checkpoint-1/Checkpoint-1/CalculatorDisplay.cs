using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkpoint_1
{
    internal class CalculatorDisplay
    {
        private Calculator calculator;

        private TextBox textBox;

        public CalculatorDisplay(TextBox textBox, Calculator calculator)
        {
            this.calculator = calculator;
            this.textBox = textBox;
        }

        public void UpdateDisplay()
        {
            if (calculator.result != 0)
            {
                textBox.Text = calculator.result.ToString();
                calculator.firstOperand = calculator.result.ToString();
                calculator.secondOperand = "";
                calculator.calculatorOperator = "";
                calculator.result = 0;
            }
            else
            {
                textBox.Text = calculator.firstOperand + " " + calculator.calculatorOperator + " " + calculator.secondOperand;
            }
        }

        public void UpdateDisplayError(String errorMessage)
        {
            this.textBox.Text = errorMessage;
        }
    }
}
