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

            switch (button.Text)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return new SetOperatorCommand(button.Text, calculator);

                case ",":
                    return new AddDotCommand(calculator);

                case "C":
                    return new ClearFieldCommand(calculator);

                case "=":
                    return new CalculateCommand(calculator);

                case "+/-":
                    return new InverseSignalCommand(calculator);

                default:
                    return new AddOperatorCommand(calculator, button);
            }
        }
    }
}
