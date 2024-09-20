using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkpoint_1.command
{
    internal class DisplayResultCommand
    {

        private TextBox textBox;

        private Calculator calculator;
        public DisplayResultCommand(Calculator calculator, TextBox textBox) 
        {
            this.calculator = calculator;
            this.textBox = textBox;
        }

        public void Execute()
        {
            if (calculator.result != 0)
            {
                textBox.Text = calculator.result.ToString();
                calculator.firstOperator = calculator.result.ToString();
                calculator.secondOperator = "";
                calculator.operation = "";
                calculator.result = 0;
            }
            else
            {
                textBox.Text = calculator.firstOperator + " " + calculator.operation + " " + calculator.secondOperator;
            }
        }
    }
}
