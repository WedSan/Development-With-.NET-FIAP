using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_1
{

    internal class Calculator
    {

        public String firstOperand { get; set; }

        public String secondOperand { get; set; }

        public String calculatorOperator { get; set; }

        public double result { get; set; }

        public Calculator()
        {
            this.firstOperand = "";
            this.secondOperand = "";
            this.calculatorOperator = "";
            this.result = Double.MinValue;
        }
        
        public double Sum(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }
        
        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;       
        }

        public double CalculatePercentage(double value, double percentage)
        {
            return (value * percentage) / 100;
        }
    }
}
