using System;

namespace Homework2
{
    class MyMath
    {
        public bool IsPrime(int x)
        {
            if (x == 1) return false;
            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void Decompose(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0 && IsPrime(i))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input an integer:");
            string inputs = Console.ReadLine();
            int n;
            while (!int.TryParse(inputs, out n) || n < 0)
            {
                Console.Write("Invalid Input.Please input an integer again:");
                inputs = Console.ReadLine();
            }
            MyMath mymath = new MyMath();
            mymath.Decompose(n);
            Console.ReadKey();
        }
    }
}