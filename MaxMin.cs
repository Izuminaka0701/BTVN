using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace BTVN
{
    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;
        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StopTime()
        {
            duration =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.
            Subtract(startingTime);
        }
        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Timing timing = new Timing();
            timing.startTime();
            int[] a = new int[1000];
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(1, 1001);
            }
            int max = Max(a);
            int min = Min(a);
            Console.WriteLine(string.Join(", ", a));
            Console.WriteLine($"Max : {max}");
            Console.WriteLine($"Min : {min}");
            timing.StopTime();
            Console.WriteLine("\n Thoi gian : " + timing.Result().TotalSeconds);
        }
        static int Max(int[] arr)
        {
            int max = arr[0];
            foreach (int i in arr)
            {
                if (i > max)
                {
                    max = i;
                }
            }return max;
        }
        static int Min(int[] arr)
        {
            int min = arr[0];
            foreach(int i in arr)
            {
                if(i < min)
                {
                    min = i;
                }
            }return min;
        }

    }
}
