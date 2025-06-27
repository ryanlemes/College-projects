using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskScheduling
{
    public static class Data
    {
        public static List<Task> PopulateRandom(int value)
        {
            List<Task> tasks = new List<Task>();

            Random r = new Random();

            for (int i = 0; i < value; i++)
            {
                tasks.Add(new Task()
                {
                    time = (int)(r.NextDouble() * 6),
                    id = i,
                });

            }

            tasks = tasks.OrderBy(i => i.time).ToList();

            return tasks;
        }

        public static List<Task> Mock()
        {
            List<Task> tasks = new List<Task>
            {
                new Task()
                {
                    time = 9,
                    id = 1,
                },

                new Task()
                {
                    time = 15,
                    id = 2,
                },

                new Task()
                {
                    time = 3,
                    id = 3,
                },
                new Task()
                {
                    time = 8,
                    id = 4,
                },
                new Task()
                {
                    time = 5,
                    id = 5,
                }
            };

            tasks = tasks.OrderBy(i => i.time).ToList();

            return tasks;
        }

        public static void PrintData(List<Task> t)
        {
            foreach (Task task in t)
            {
                Console.WriteLine($"Id: {task.id} | Time: {task.time}");
            }
        }
    }
}
