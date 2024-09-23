using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkpoint_1.command
{
    internal class CalculatorInvoker
    {
        private ICalculatorCommand command;

        private CalculatorDisplay display;

        public CalculatorInvoker(CalculatorDisplay display)
        {
            this.display = display;
        }
        
        public void SetCommand(ICalculatorCommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            if(command != null)
            {
                try
                {
                    command.Execute();
                    display.UpdateDisplay();
                }
                catch (DivideByZeroException ex)
                {
                    display.UpdateDisplayError("Zero cannot be divided");
                }
                
            }
        }

    }
}
