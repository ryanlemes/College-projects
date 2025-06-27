using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskScheduling
{
    static class Dynamic
    {
        public static int dynamic(int row, int column, int max, List<Task> tasks, ref List<Task> solutions)
        {
            if (row == 0 || column == 0)
            {
                return 0;
            };

            return Math.Min(column - dynamic(row - 1, column, max, tasks, ref solutions),
                            column - (dynamic(row - 1, column - tasks.ElementAt(row - 1).time, max, tasks, ref solutions) +
                            tasks.ElementAt(row - 1).time));
        }
    }
}
