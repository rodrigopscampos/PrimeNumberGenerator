using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuckingPrime
{
    class Impl2
    {
        static int[] _backlog = new int[500_0000];

        static int _b = 0;
        static int _b2 = 0;

        static void WriteAsync(int n)
        {
            _backlog[Interlocked.Increment(ref _b)] = n;
        }

        static void ProcessWriteAsync()
        {
            while (true)
            {
                while (_b2 <= _b)
                {
                    Console.WriteLine(_backlog[_b2++]);
                }
            }
        }

        public static void Run()
        {
            var t1 = new Thread(ProcessWriteAsync);
            t1.Priority = ThreadPriority.Highest;
            t1.Start();

            for (int i = 0; i < 4; i++)
            {
                var t = new Thread(new ThreadStart(LoopProcess));
                t.Priority = ThreadPriority.Highest;
                t.IsBackground = true;
                t.Start();
            }

            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            LoopProcess();
        }

        static void LoopProcess()
        {
            while (true)
            {
                var n = NextInt();
                if (IsPrime(n))
                {
                    WriteAsync(n);
                }
            }
        }

        static int _i;
        static int NextInt()
        {
            return Interlocked.Increment(ref _i);
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
