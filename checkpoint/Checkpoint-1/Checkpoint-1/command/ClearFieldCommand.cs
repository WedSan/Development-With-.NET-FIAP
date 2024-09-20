using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1.command
{
    internal class ClearFieldCommand
    {
        private Calculator calculator;

        public ClearFieldCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            calculator.firstOperator = "";
            calculator.secondOperator = "";
            calculator.operation = "";
            calculator.result = 0;
        }
    }
}
