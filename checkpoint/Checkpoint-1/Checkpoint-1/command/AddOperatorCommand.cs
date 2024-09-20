using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkpoint_1.command
{
    internal class AddOperatorCommand
    {
        private Calculator calculator;

        private Button button;

        public AddOperatorCommand(Calculator calculator, Button buttonEvent)
        {
            this.calculator = calculator;
            this.button = buttonEvent;
        }

        public void Execute()
        {
            if (calculator.operation == "")
            {
                calculator.firstOperator += button.Text;
            }
            else
            {
                calculator.secondOperator += button.Text;
            }
        }
    }

   
}
