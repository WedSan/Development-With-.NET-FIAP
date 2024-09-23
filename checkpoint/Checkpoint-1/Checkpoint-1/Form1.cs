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

        private CalculatorInvoker invoker;

        public Form1()
        {
            InitializeComponent();
            this.calculator = new Calculator();
            CalculatorDisplay display = new CalculatorDisplay(this.textBox1, calculator);
            this.invoker = new CalculatorInvoker(display);
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            Button button = (Button)sender;

            ICalculatorCommand command = new CalculatorCommandFactory().CreateCalculatorCommand(button, calculator);
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
