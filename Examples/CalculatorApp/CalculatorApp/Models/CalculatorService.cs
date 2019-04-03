using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorApp.Models
{
    public class CalculatorService
    {
        private static List<string> _resultMessages = new List<string>();

        public List<string> ResultMessages
        {
            get { return _resultMessages; }
        }

        public void PerformOperation(string input1, string input2, string op)
        {
            decimal num1, num2;
            string result = "";
            try
            {
                num1 = decimal.Parse(input1);
                num2 = decimal.Parse(input2);
                switch (op)
                {
                    case "+":
                        result = num1 + " + " + num2 + " = " + (num1 + num2);
                        break;
                    case "-":
                        result = num1 + " - " + num2 + " = " + (num1 - num2);
                        break;
                    case "*":
                        result = num1 + " * " + num2 + " = " + (num1 * num2);
                        break;
                    case "/":
                        result = num1 + " / " + num2 + " = " + (num1 / num2);
                        break;
                }
            }
            catch (Exception)
            {
                result = "Cannot do " + input1 + " " + op + " " + input2 + "!";
            }
            _resultMessages.Add(result);
        }

    }
}