using System;
using System.Runtime;
using System.Threading;

namespace FuckingPrime
{
    class Impl3
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
                while (_b2 <= _b - 20)
                {
                    Console.WriteLine(
                        _backlog[_b2]
                        + "\n" + _backlog[_b2 + 1]
                        + "\n" + _backlog[_b2 + 2]
                        + "\n" + _backlog[_b2 + 3]
                        + "\n" + _backlog[_b2 + 4]
                        + "\n" + _backlog[_b2 + 5]
                        + "\n" + _backlog[_b2 + 6]
                        + "\n" + _backlog[_b2 + 7]
                        + "\n" + _backlog[_b2 + 8]
                        + "\n" + _backlog[_b2 + 9]
                        + "\n" + _backlog[_b2 + 10]

                        + "\n" + _backlog[_b2 + 11]
                        + "\n" + _backlog[_b2 + 12]
                        + "\n" + _backlog[_b2 + 13]
                        + "\n" + _backlog[_b2 + 14]
                        + "\n" + _backlog[_b2 + 15]
                        + "\n" + _backlog[_b2 + 16]
                        + "\n" + _backlog[_b2 + 17]
                        + "\n" + _backlog[_b2 + 18]
                        + "\n" + _backlog[_b2 + 19]
                        + "\n" + _backlog[_b2 + 20]
                        );

                    _b2 += 20;
                }
            }
        }

        public static void Run()
        {
            var t1 = new Thread(ProcessWriteAsync);
            t1.Priority = ThreadPriority.Highest;
            t1.Start();

            for (int i = 0; i < 7; i++)
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
            int n;
            while (true)
            {
                n = NextInt();
                if (IsPrime(n))
                {
                    WriteAsync(n);
                }
            }
        }

        static int _i = 3;
        static int NextInt()
        {
            return Interlocked.Add(ref _i, 2);
        }

        static bool IsPrime(int n)
        {
            if (n % 3 == 0)
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
