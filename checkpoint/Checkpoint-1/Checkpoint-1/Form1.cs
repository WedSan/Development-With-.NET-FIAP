﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Calculator calculator = new Calculator();

            Button button = (Button)sender;
            
            String[] listMathOperations = {"+", "-", "X", "÷"};
            String firstOperator = "";
            String secondOperator = "";
            String operation = "";
            double result = 0;

            if (listMathOperations.Contains(button.Text))
            {
                int operationIndex = Array.IndexOf(listMathOperations, button.Text);
                operation = listMathOperations[operationIndex];
            }
            else if(button.Text.Equals(","))
            {
                if(operation == "")
                {
                    if (!firstOperator.Contains(",") && firstOperator != "")
                    {
                        firstOperator.Concat(",");
                    }
                }
                else
                {
                    if (!secondOperator.Contains(",") && secondOperator != "")
                    {
                        secondOperator.Concat(",");
                    }
                }
            }
            else if (button.Text.Equals("C"))
            {
                firstOperator = "";
                secondOperator = "";
                operation = "";
            }
            else if (button.Text.Equals("="))
            {
               if(firstOperator != "" && secondOperator != "")
                {
                    double firstOperatorNumber = Double.Parse(firstOperator);
                    double secondOperatorNumber = Double.Parse(secondOperator);
               

                    if (operation == "+")
                    {
                        result = calculator.Sum(firstOperatorNumber, secondOperatorNumber);
                    }
                    else if(operation == "-")
                    {
                        result = calculator.Subtract(firstOperatorNumber, secondOperatorNumber);
                    }
                }
            }
            else
            {
                if(operation == "")
                {
                    firstOperator.Concat(button.Text);
                }
                else
                {
                    secondOperator.Concat(button.Text);
                }
            }

            this.textBox1.Text = result != 0 ? result.ToString() : firstOperator + " " + operation + " " + secondOperator;
            Console.WriteLine(this.textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
