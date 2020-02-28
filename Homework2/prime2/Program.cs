using System;
using System.Collections;

namespace prime2
{
    class Program
    {
        static void Process(out ArrayList prime)
        {
            const int MAXN = 100;
            bool[] flag = new bool[101];
            prime = new ArrayList();

            for (int i = 2; i <= MAXN; i ++)
            {
                if (!flag[i])
                {
                    prime.Add(i);
                }
                foreach (int p in prime)
                {
                    if (p * i > MAXN) break;
                    flag[p * i] = true;
                    if (i % p == 0) break;
                }
            }
        }
        static void Main(string[] args)
        {
            ArrayList prime;
            Process(out prime);
            foreach (int p in prime)
            {
                Console.Write(p + " ");
            }
        }
    }
}
