using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "", result = "";
            int a, b;
            Console.Write("Please input the first number:");
            s = Console.ReadLine();
            while ( !int.TryParse(s, out a) )
            {
                Console.Write("Inavlid Input. Please input the first number again:");
                s = Console.ReadLine();
            }
            Console.Write("Please input the second number:");
            s = Console.ReadLine();
            while (!int.TryParse(s, out b))
            {
                Console.Write("Inavlid Input. Please input the second number again:");
                s = Console.ReadLine();
            }
            Console.Write("Please input an operator ( +, -, *, / ):");
            char op;
            s = Console.ReadLine();
            while (!char.TryParse(s, out op) || (op != '+' && op != '-' && op != '*' && op != '/'))
            {
                Console.Write("Inavlid Input. Please input an operator ( +, -, *, / ) again:");
                s = Console.ReadLine();
            }
            switch (op)
            {
                case '+':
                    result = $"{a + b}";
                    break;
                case '-':
                    result = $"{a - b}";
                    break;
                case '*':
                    result = $"{a * b}";
                    break;
                case '/':
                    if (b == 0)
                    {
                        result = "Invalid Input.";
                        break;
                    }
                    result = $"{a / b}";
                    break;
            }
            if (result != "Invalid Input.")
            {
                Console.Write("The result is:");
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
