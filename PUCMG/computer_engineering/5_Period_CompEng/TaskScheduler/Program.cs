using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TaskScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int W = 5;

            List<Task> tasks = Data.PopulateRandom(90);

            #region BruteForce
            Console.WriteLine("-------------------Brute Force Algorithm-------------------");

            stopwatch.Start();
            List<Task> solutionListbruteForce = new List<Task>();
            while (stopwatch.Elapsed.Seconds != 5)
            {
                solutionListbruteForce = BruteForce.bruteForce(tasks, W, 0);
                Data.PopulateRandom(90).CopyTo(tasks.ToArray());
            }

            Data.PrintData(solutionListbruteForce);
            stopwatch.Stop();

            TimeSpan time = stopwatch.Elapsed;
            Console.WriteLine($"Brute Force process time: {time.Milliseconds} ms");
            #endregion

            #region Greedy
            Console.WriteLine("---------------------Greedy Algorithm---------------------");

            stopwatch.Restart();
            tasks = Data.PopulateRandom(90);
            List<Task> solutionListGreedy = new List<Task>();

            while (stopwatch.Elapsed.Seconds != 5)
            {
                solutionListGreedy = Greedy.greedy(tasks, W);
                Data.PopulateRandom(90).CopyTo(tasks.ToArray());
            }

            Data.PrintData(solutionListGreedy);
            stopwatch.Stop();

            time = stopwatch.Elapsed;
            Console.WriteLine($"Greedy process time: {time.Milliseconds} ms");
            #endregion

            #region Dynamic
            Console.WriteLine("---------------------Dynamic Algorithm--------------------");

            stopwatch.Restart();
            tasks = Data.PopulateRandom(90);

            List<Task> solutionListDynamic = new List<Task>();
            while (stopwatch.Elapsed.Seconds != 5)
            {
                var a = Dynamic.dynamic(tasks.Count - 1, W, W, tasks, ref solutionListDynamic);
                Data.PopulateRandom(90).CopyTo(tasks.ToArray());
            }

            Data.PrintData(solutionListDynamic);
            stopwatch.Stop();

            time = stopwatch.Elapsed;
            Console.WriteLine($"Dynamic process time: {time.Milliseconds} ms");
            #endregion

            Console.ReadKey();
        }
    }
}
