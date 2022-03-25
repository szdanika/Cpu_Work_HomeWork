using System;

namespace Cpu_Work_HomeWork
{
    internal class Program
    {
        public static int[] ReadIn()
        {
            int[] tasks = new int[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Convert.ToInt32(Console.ReadLine().Split(',')[1]);
            }
            return tasks;
        }
        public static int SumTimeNeeded(int[] tasks)
        {
            int sum = 0;
            for (int i = 0; i < tasks.Length; i++)
            {
                sum += tasks[i];
            }
            return sum;
        }
        public static int NextTask(int[] tasks, int end)
        {
            //Console.WriteLine("meddig " + end);
            int minTaskTime = 0;
            
            for (int i = 1;i < end;i++)
            {
                //Console.WriteLine(i + " : i");
                if(i < tasks.Length)
                {
                    //Console.WriteLine("vizsgalom ezt " + tasks[i] + " ezzel :" + tasks[minTaskTime]);
                    if (tasks[i] < tasks[minTaskTime] && tasks[i] != 50000)
                        minTaskTime = i;
                }
                else
                {
                    i = end;
                }
            }
            //Console.WriteLine(minTaskTime + "/////");
            return minTaskTime;
        }
        static void Main(string[] args)
        {
            int[] tasks = ReadIn();
            int sum = SumTimeNeeded(tasks);
            bool idle = true;
            int meddig = 0;
            for (int i = 0; i < sum; i++)
            {
                if(idle == true)
                {
                    idle = false;
                    int index = NextTask(tasks, i);
                    meddig=i +tasks[index] ;
                    if (i != sum-1)
                    {
                        Console.Write(index + ",");
                    }
                    else
                        Console.Write(index);

                    tasks[index] = 50000;
                }
                else if(i == meddig)
                    idle = true;
            }
            Console.ReadLine();
        }
    }
}
