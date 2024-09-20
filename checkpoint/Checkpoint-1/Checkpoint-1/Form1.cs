using Checkpoint_1.command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkpoint_1
{
    public partial class Form1 : Form
    {
        private Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            this.calculator = new Calculator();
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            Button button = (Button)sender;
            
            String[] listMathOperations = {"+", "-", "X", "÷", "%"};
         

            if (listMathOperations.Contains(button.Text))
            {
                int operationIndex = Array.IndexOf(listMathOperations, button.Text);
                calculator.operation = listMathOperations[operationIndex];
            }
            else if(button.Text.Equals(","))
            {
                new AddDotCommand(calculator).Execute();
            }
            else if (button.Text.Equals("C"))
            {
               new ClearFieldCommand(calculator).Execute();
            }
            else if (button.Text.Equals("="))
            {
                try
                {
                    new CalculateCommand(calculator).Execute();
                }
                catch(DivideByZeroException ex)
                {
                    this.textBox1.Text = "Zero cannot be divided";
                    return;
                }
            }
            else if(button.Text == "+/-")
            {
               new InverseSignalCommand(calculator).Execute();
            }
            else
            {
              new AddOperatorCommand(calculator, button).Execute();
            }

            new DisplayResultCommand(calculator, this.textBox1).Execute();
            Console.WriteLine(this.textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
