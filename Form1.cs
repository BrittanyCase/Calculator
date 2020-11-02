using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace calcLab3
{
    
    public partial class Form1 : Form
    {
        //tracks if the last button clicked was zero. prevents leading eros
        Boolean lastClicked0 = true;
        //calc object
        Calc calcu = new Calc();
        //tracks if decimal was clicked. 
        Boolean decimalClicked = false;
        public Form1()
        {
            InitializeComponent();

        }
        //neg pos button
        private void btnPNeg_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            String sRes;
            //converts text in box to decimal
            Decimal.TryParse(displayTxt.Text, out result);
            //formal for converting pos and neg
            result = (-1*(result));
            sRes = result.ToString();
            displayTxt.Text = sRes;
            
            





        }

        //number buttons
        private void button1_Click(object sender, EventArgs e)
        {
            //appends number to current string in text box. all number buttons do this.
            displayTxt.Text += "1";
            lastClicked0 = false;
        }


        private void btn2_Click(object sender, EventArgs e)
        {

            displayTxt.Text += "2";
            lastClicked0 = false;
        }

        private void btn3_Click(object sender, EventArgs e)
        {

            displayTxt.Text += "3";
            lastClicked0 = false;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            displayTxt.Text += "4";
            lastClicked0 = false;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            displayTxt.Text += "5";
            lastClicked0 = false;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            displayTxt.Text += "6";
            lastClicked0 = false;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            displayTxt.Text += "7";
            lastClicked0 = false;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            displayTxt.Text += "8";
            lastClicked0 = false;

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            displayTxt.Text += "9";
            lastClicked0 = false;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            //if zero last clicked is true will not add an aditional zero
            if (lastClicked0)
            {


            }
            else
            {
                //if zero last clicked was false adds zero to string
                displayTxt.Text += "0";
                //sets last clicked zero to true
                lastClicked0 = true;
            }
        }
        private void btnDeci_Click(object sender, EventArgs e)
        {
            //if decimal clicked is true will not add another decimal
           if(decimalClicked)
            {

            }
            else
            {
            //if false adds aditional decimal and sets to true.
              displayTxt.Text += ".";
              decimalClicked = true;
            }
        }
        //backspace button
        private void btnBack_Click(object sender, EventArgs e)
        {
            //removes one from the current string in the display text box

          
                if (displayTxt.Text.Length == 1)
                    displayTxt.Text = "0"; 
                else
                {
                   displayTxt.Text = displayTxt.Text.Remove(displayTxt.Text.Length - 1, 1);
                }
            

        }
        //clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            displayTxt.Text = " ";
            calcu.Clear();
            lastClicked0 = false;
            decimalClicked = false;
        }
        //math buttons
        private void btnDiv_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            //converts text in box to decimal
            Decimal.TryParse(displayTxt.Text, out result);
            //uses a setter to set the value of operand 1
            calcu.setOpOne(result);
            //sets the operator 
            calcu.setOp(Calc.Operator.Divide);
            //clears current string
            displayTxt.Text = " ";
            decimalClicked = false;
            lastClicked0 = false;
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            //converts text in box to decimal
            Decimal.TryParse(displayTxt.Text, out result);
            //uses a setter to set the value of operand 1
            calcu.setOpOne(result);
            //sets the operator 
            calcu.setOp(Calc.Operator.Multiply);
            //clears current string
            displayTxt.Text = " ";
            decimalClicked = false;
            lastClicked0 = false;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            //converts text in box to decimal
            Decimal.TryParse(displayTxt.Text, out result);
            //uses a setter to set the value of operand 1
            calcu.setOpOne(result);
            //sets the operator 
            calcu.setOp(Calc.Operator.Subtract);
            //clears current string
            displayTxt.Text = " ";
           
            decimalClicked = false;
            lastClicked0 = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            //converts text in box to decimal
            Decimal.TryParse(displayTxt.Text, out result);
            //uses a setter to set the value of operand 1
            calcu.setOpOne(result);
            //sets the operator 
            calcu.setOp(Calc.Operator.Add);
            //clears current string
            displayTxt.Text = " ";
            decimalClicked = false;
            lastClicked0 = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            
            //converts text in box to decimal
            Decimal.TryParse(displayTxt.Text, out result);
            //sets operand two 
            calcu.setOpTwo(result);
            //calculate stuff
            calcu.Equals();
            //set output display to currentvalue

            
             
                result = calcu.getCurrentVal();

            


             String sResult =   result.ToString();
            displayTxt.Text = sResult;
            decimalClicked = false;
            lastClicked0 = false;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
           
            double result;
            String sRes;
            //converts text in box to double
            double.TryParse(displayTxt.Text, out result);
            //sqrt
            result = Math.Sqrt(result);
            //sets result as operand one incase user preforms another function on the number
            calcu.setOpOne((decimal)result);
            //converts result to a string
            sRes = result.ToString();
            //sets result to text box.
            displayTxt.Text = sRes;
            decimalClicked = false;
            lastClicked0 = false;
        }

        private void btn1X_Click(object sender, EventArgs e)
        {
            //creates a decimal variable. probably a better way to do this this just makes sense to me
            decimal result;
            String sRes;
            //converts text in box to decimal
            decimal.TryParse(displayTxt.Text, out result);
            //inverse
            result = 1 / result;
            //sets result as operand One
            calcu.setOpOne(result);
            sRes = result.ToString();
            //sets result to text box.
            displayTxt.Text = sRes;
            decimalClicked = false;
            lastClicked0 = false;

        }
    }
}
