using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Eindopdracht
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
        private long frequence;

        //Lock
        private object _lock = new object();

        public Timing()
        {
            //Set defaults to 0
            startTime = 0;
            stopTime = 0;
            frequence = 0;

            // check if counter is supported
            if (QueryPerformanceFrequency(out frequence) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }

            //Set Process priority & affinity
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)0x0001;
        }

        public void start()
        {
            lock (_lock)
            {
                QueryPerformanceCounter(out startTime);
            }
        }


        public void stop()
        {
            lock (_lock)
            {
                QueryPerformanceCounter(out stopTime);
            }
        }


        public double duration
        {
            get
            {
                return (double)(stopTime - startTime) / (double)frequence;
            }
        }
    }
}