using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// This is a command line calculator implementation.
    /// </summary>
    class Calculator
    {
        private IStackADT stack = new LinkedStack(); // data structure that holds information for calculations.

        /// <summary>
        /// property to get the stack.
        /// </summary>
        private IStackADT Stack
            {
                get { return stack; }
            }

        /// <summary>
        /// Main method for starting the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            bool calculateAgain = true;
            Console.Write("Postfix Calculator. \nRecognized operators: + - * /");
            while(calculateAgain)
            {
                calculateAgain = calc.Calculate();
            }
            Console.Write("Thank you for feeding me. Goodbye.");
        }

        /// <summary>
        /// This method gets the user input and performs a calculation.
        /// </summary>
        /// <returns>True if calculation was a success. False if not.</returns>
        private bool Calculate()
        {
            Console.Write("\nPlease enter q to quit\n\n");
            string input, output = "";
            input = Console.ReadLine();

            if (input.Trim().ToLower().StartsWith("q"))
            {
                return false;
            }

            try
            {
                output = EvaluatePostFixInput(input);
            }
            catch (ArgumentException ex)
            {
                output = ex.Message;
            }
            Console.Write("\n\t>>> " + input + " = " + output);
            return true;
        }

        /// <summary>
        /// Evalutates the given input if written in postfix form.
        /// </summary>
        /// <param name="input">Type of input here.</param>
        /// <returns>the answer as a sting output.</returns>
        private string EvaluatePostFixInput(string input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentException("Null or the empty string are not valid postfix expressions");
            Stack.Clear();
            int stackCount = 0; 

            double a, b, c, x; // Temporary variables 

            string[] variables = input.Trim().Split(' ');
            foreach (string v in variables)
            {
                // if it's a number, push it on the stack
                if (Double.TryParse(v, out x))
                {
                    Stack.Push((x));
                    stackCount++;
                }
                else // Must be an operator or some other character/word.
                {
                    if (v.Length > 1)
                        throw new ArgumentException("Input Error: " + v + " is not an allowed number or operator");
                    // may be an operator, so pop two values off stack and perform operation
                    if (Stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    b = (double)Stack.Pop();
                    if (Stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting first operand.");
                    a = (double)Stack.Pop();
                    // Send values to another method to perform operation.
                    c = Evaluate(a, b, v, ref stackCount);
                    // Push answer from operation back onto the stack.
                    Stack.Push(c);
                }
            } // end loop
            if (stackCount > 1)
                throw new ArgumentException("Input Error: Improper operand to operator ratio.");
            return Stack.Pop().ToString();
        }


        /// <summary>
        /// Performs all aritmatic for the calculator method.
        /// </summary>
        /// <param name="a">First</param>
        /// <param name="b">Second</param>
        /// <param name="v">Operator input</param>
        /// <param name="stackCount">Total number of items on the stack.</param>
        /// <returns>The answer to the equation.</returns>
        private double Evaluate(double a, double b, string v, ref int stackCount)
        {
            double c = 0.0;
            if (v.Equals("+"))
            {
                c = (a + b);
            }
            else if (v.Equals("-"))
            {
                c = (a - b);
            }
            else if (v.Equals("*"))
            {
                c = (a * b);
            }
            else if (v.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if(Double.IsNegativeInfinity(c) || Double.IsPositiveInfinity(c))
                    {
                        throw new ArgumentException("Cant divide by zero.");
                    }
                }
                catch (ArithmeticException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
            else
            {
                throw new ArgumentException("Improper operator: " + v + ", is not one of +, -, *, or /");
            }

            stackCount--;
            return c;
        }

    }
}
