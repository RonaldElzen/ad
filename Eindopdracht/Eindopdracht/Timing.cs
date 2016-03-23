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

        // timespans
        TimeSpan startTime;
        TimeSpan result;

        // calls timerclass with initial values
        public Timing()
        {
            startTime = new TimeSpan(0);
            result = new TimeSpan(0);
        }

        // stops mesuring time 
        public void stop()
        {
            Process p = Process.GetCurrentProcess();
            ProcessThread thread = p.Threads[0];
            thread.ProcessorAffinity = (IntPtr)1;
            result = thread.UserProcessorTime;
        }

        // starts mesuring time
        public void start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Process p = Process.GetCurrentProcess();
            ProcessThread thread = p.Threads[0];
            thread.ProcessorAffinity = (IntPtr)1;
            startTime = thread.UserProcessorTime;

        }

        // retuns duration
        public TimeSpan duration()
        {
            return result - startTime;
        }
    }
}
 
