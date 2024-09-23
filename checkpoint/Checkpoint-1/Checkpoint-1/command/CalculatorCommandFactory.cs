using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkpoint_1.command
{
    internal class CalculatorCommandFactory
    {
        public CalculatorCommandFactory() { }

        public ICalculatorCommand CreateCalculatorCommand(Button button, Calculator calculator)
        {

            
            if (button.Text.Equals(","))
            {
                new AddDotCommand(calculator).Execute();
            }
            else if (button.Text.Equals("C"))
            {
                new ClearFieldCommand(calculator).Execute();
            }
            else if (button.Text.Equals("="))
            {
                new CalculateCommand(calculator).Execute();
            }
            else if (button.Text == "+/-")
            {
                new InverseSignalCommand(calculator).Execute();
            }
            else
            {
                new AddOperatorCommand(calculator, button).Execute();
            }
        }
    }
}
