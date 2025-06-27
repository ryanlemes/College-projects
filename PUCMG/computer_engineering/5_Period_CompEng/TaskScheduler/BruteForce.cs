using System.Collections.Generic;

namespace TaskScheduling
{
    static class BruteForce
    {
        public static List<Task> bruteForce(List<Task> T, int max, int sum)
        {
            List<Task> solution = new List<Task>();
            List<List<Task>> solutionList = new List<List<Task>>();

            for (int i = 0; i < T.Count; i++)
            {
                solutionList.Add(recursive(T, max, 0));
            }

            int max = solutionList[0].Count;

            foreach (List<Task> list in solutionList)
            {
                if (list.Count >= max)
                {
                    solution = list;
                }
            }

            return solution;
        }

        private static List<Task> recursive(List<Task> T, int max, int sum)
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < T.Count; i++)
            {
                if (sum + T[i].time <= max)
                {
                    tasks.Add(T[i]);
                }
            }

            return tasks;
        }
    }
}
