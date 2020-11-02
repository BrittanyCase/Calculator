using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcLab3
{
    class Calc
    {
        private decimal operandOne;
        private decimal operandTwo;
        private decimal currentVal;
        private Operator op; 


        public enum Operator
        {
           Add,
           Subtract,
           Multiply,
           Divide,
           None

        }

        //constructor
        public Calc ()
        {

        }

        //getters
        public decimal getOperandOne()
        {
            return operandOne;
        }
        public decimal getOperandTwo()
        {
            return operandTwo;
        }
        public decimal getCurrentVal()
        {
            return currentVal;
        }
        //setters
        public void setOpOne(decimal opOne)
        {
            this.operandOne = opOne;

        }

        public void setOpTwo(decimal opTwo)
        {
            this.operandTwo = opTwo;

        }

        public void setOp(Operator op)
        {

            this.op = op;
        }

        //math methods c:
        private void add()
        {

            this.operandOne = operandOne + operandTwo;
            currentVal = operandOne;


        }

        public void subtract()
        {

            this.operandOne = operandOne - operandTwo;
            currentVal = operandOne;

        }

        public void divide()
        {
            try
            {
                operandOne = operandOne / operandTwo;
                currentVal = operandOne;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("error, cannot divide by Zero");
            }

        }
        
        public void multiply()
        {
            operandOne = operandOne * operandTwo;
            currentVal = operandOne;

        }
        //clears everything
        public void Clear()
        {
            operandOne = 0;
            operandTwo = 0;
            op =Calc.Operator.None;
        }
        //equals method
        public void Equals()
        {
            if(this.op == Calc.Operator.Add)
            {
                add();
            }
            else if(this.op==Calc.Operator.Divide)
            {
                divide();
            }
            else if(this.op == Calc.Operator.Multiply)
            {
                multiply();
            }
            else if(this.op == Calc.Operator.Subtract)
            {
                subtract();
            }
            else
            {

            }
            this.operandTwo = 0;
            currentVal = operandOne;

        }
    }
}
