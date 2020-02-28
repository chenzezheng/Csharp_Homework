using System;

namespace array
{
    class MyArray
    {
        double[] numbers;
        public void Init(int n)
        {
            if (n == 0)
                throw new Exception(message: "Empty Array.");
            numbers = new double[n];
            Console.WriteLine("Please input the numbers of array.A number per line.");
            for (int i = 0; i < n; i ++)
            {
                double x = 0;
                string inputs = Console.ReadLine();
                while (!double.TryParse(inputs, out x))
                {
                    Console.WriteLine("Invalid Input.Please input the number again:");
                    inputs = Console.ReadLine();
                }
                numbers[i] = x;
            }
        }
        public void Calculate(out double min, out double max, out double sum, out double avg)
        {
            if (numbers.Length == 0)
                throw new Exception(message: "Empty Array.");
            max = numbers[0];
            min = numbers[0];
            sum = avg = 0;
            foreach (double num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
                if (num > max)
                {
                    max = num;
                }
                sum += num;
            }
            avg = sum / numbers.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input the length of array:");
            string inputs = Console.ReadLine();
            int n;
            while (!int.TryParse(inputs, out n) || n < 0)
            {
                Console.Write("Invalid Input.Please input the length of array again:");
                inputs = Console.ReadLine();
            }
            try
            {
                MyArray myarray = new MyArray();
                myarray.Init(n);
                double min, max, sum, avg;
                myarray.Calculate(out min, out max, out sum, out avg);
                Console.WriteLine($"Min:{min} Max:{max} Sum:{sum} Average:{avg}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
