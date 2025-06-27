using System;
using System.Collections.Generic;

namespace TaskScheduling
{
    static class Greedy
    {
        public static List<Task> greedy(List<Task> T, int max)
        {
            List<Task> solution = new List<Task>();
            int sum = 0;

            for (int minIndex = 0; minIndex < T.Count; minIndex++)
            {
                int min = Int32.MaxValue;
                for (int k = minIndex; k < T.Count; k++)
                {
                    if (T[k].time < min)
                    {
                        min = T[k].time;
                        minIndex = k;
                    }
                }

                if (min < max && (sum + T[minIndex].time) <= max)
                {
                    solution.Add(T[minIndex]);
                    sum += T[minIndex].time;
                }
            }

            return solution;
        }
    }
}
