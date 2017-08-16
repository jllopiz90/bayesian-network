using System;
using System.Threading.Tasks;
using System.Threading;

namespace HelloThread
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatingThreads();
            //SleepVsSpinWait();
        }

        private static void CreatingThreads()
        {
            // Using explicit method call
            Task t1 = new Task(HelloThread);

            // Using lambdas
            Task t2 = new Task(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                     Console.WriteLine("Hola Hebra!!!");
                     System.Threading.Thread.Sleep(50);
                }
                   
            });

            // Using parameters
            Task t3 = new Task(()=>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("HOLAHOLA!!!");
                    System.Threading.Thread.Sleep(10);
                }
            });

            t1.Start();
            t2.Start();
            t3.Start();

            // Waiting for threads

            Task.WaitAll(t1, t2, t3);
        }

        static void HelloThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Hello Hebra!!!");
                System.Threading.Thread.Sleep(10);
            }
        }

        static void SleepVsSpinWait()
        {
            Thread sleep = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Sleeping...");
                    Thread.Sleep(1000);
                }
            });

            Thread spin = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Spinning...");
                    Thread.SpinWait(200000000);
                }
            });

            sleep.Start();
            spin.Start();

            sleep.Join();
            spin.Join();
        }
    }
}
