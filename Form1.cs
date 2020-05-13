using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {


            string operand1 = operand1Box.Text;
            string operand2 = operand2Box.Text;
            string operator1 = operatorBox.Text;

            string pastOperand1 = operand1;
            string pastOperand2 = operand2;
            string pastOperator = operator1;
            //If any of the textbox values have changed, change the result text box to be cleared
            if(operand1 != pastOperand1 || operand2!= pastOperand2|| operator1 != pastOperator)
            {
                resultBox.Clear();
            }

        }

        public bool IsPresent()
        {
            if (string.IsNullOrEmpty(operand1Box.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(operand2Box.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(operatorBox.Text))
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public bool IsDecimal()
        {
            decimal operand1 =
                decimal.Parse(operand1Box.Text);
            decimal operand2 =
                decimal.Parse(operand2Box.Text);
            decimal million = 1000000;

            if (0 <= operand1 && operand1 <= million && 0 <= operand2 && operand2 <= million)
            {
                return true;
            }
            else
            {
                MessageBox.Show("You must have numbers between 0 and 1,000,000.");
                return false;
            }
            
        }

        public bool IsOperator()
        {
            if (operatorBox.Text == "+")
            {
                return true;
            }

            else if (operatorBox.Text == "-")
            {
                return true;
            }

            else if (operatorBox.Text == "*")
            {
                return true;
            }

            else if (operatorBox.Text == "/")
            {
                return true;
            }
            else
            {
                MessageBox.Show("You must have a valid operator! (+,-,*,/) ", "Invalid Operator Error");
                return false;
            }
        }

        public bool IsValidData(bool IsOperator, bool IsDecimal, bool IsPresent)
        {
            //all three have to be true, otherwise, do not calculate the numbers.
            if (IsOperator == true && IsDecimal == true && IsPresent == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private decimal Calculate(decimal operand1, string operator1, decimal operand2)
        {
            operand1 =
                decimal.Parse(operand1Box.Text);
            operator1 = 
                operatorBox.Text;
            operand2 =
                decimal.Parse(operand2Box.Text);

            if (operator1 == "+")
            {
                decimal addition = operand1 + operand2;
                resultBox.Text = addition.ToString();
            }
            else if (operator1 == "-")
            {
                decimal subtraction = operand1 - operand2;
                resultBox.Text = subtraction.ToString();
            }
            else if (operator1 == "*")
            {
                decimal multiplication = operand1 * operand2;
                resultBox.Text = multiplication.ToString();
            }
            else if (operator1 == "/")
            {
                decimal division = operand1 / operand2;
                resultBox.Text = division.ToString();

            }

            decimal result =
                decimal.Parse(resultBox.Text);
            //formats the number to only have up to 4 decimal places.
            string formattedResult = string.Format("{0:0.0000}", result);
            return Convert.ToDecimal(formattedResult);

        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            if(IsValidData(IsOperator(), IsPresent(), IsDecimal()))
            {
                Calculate(decimal.Parse(operand1Box.Text), operatorBox.Text, decimal.Parse(operand2Box.Text));
            }

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
