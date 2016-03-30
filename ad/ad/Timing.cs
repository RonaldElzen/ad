using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;


namespace ad
{
    public class Timing
    {

        //DLL imports
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);


        private long startTime;
        private long stopTime;
        private long frequency;

        //Lock
        private object _lock = new object();

        public Timing()
        {
            //Set defaults to 0
            startTime = 0;
            stopTime = 0;
            frequency = 0;

            // check if counter is supported
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }

            //Set Process priority & affinity
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)0x0001;
        }

        public void Start()
        {
            lock (_lock)
            {
                QueryPerformanceCounter(out startTime);
            }
        }


        public void Stop()
        {
            lock (_lock)
            {
                QueryPerformanceCounter(out stopTime);
            }
        }

        public enum TimeUnit : int
        {
            Seconds = 1,
            Miliseconds = 1000,
            Nanoseconds = 1000000
        }

        public class NoReturn
        {
        }

        public class Result<T>
        {
            public T ReturnValue { get; set; }

            public double Time { get; set; }
        }

        private double Duration(TimeUnit timeUnit)
        {
            return (((double)(stopTime - startTime) / ((double)frequency) * (int)timeUnit));
        }


        public static Result<NoReturn> GetTime(Action action, TimeUnit timeUnit)
        {
            return GetTime(() =>
            {
                action.Invoke();
                return new NoReturn();
            }, timeUnit);
        }
        public static Result<T> GetTime<T>(Func<T> function, TimeUnit timeUnit)
        {
            var timing = new Timing();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            timing.Start();
            var returnValue = function.Invoke();
            timing.Stop();

            return new Result<T>
            {
                Time = timing.Duration(timeUnit),
                ReturnValue = returnValue
            };
        }
    }
}
