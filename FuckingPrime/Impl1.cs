using System;
using System.Threading;

namespace FuckingPrime
{
    public static class Impl1
    {
        public static void Run()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            int i = 0;
            while (true)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }

                i++;
            }
        }

        static bool IsPrime(int n)
        {
            if (n <= 3)
                return n > 1;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;

            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;

                i += 6;
            }

            return true;
        }
    }
}