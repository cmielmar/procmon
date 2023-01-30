using System.Diagnostics;

namespace ProcessMonitor

{
    public class ProcessWrapper : IProcessWrapper
    {

        public Process Process { get; }
        public DateTime StartTime { get; set; } 

        public ProcessWrapper(Process process)
        {
            Process = process;
            this.StartTime = Process.StartTime;
        }

        public void Kill()
        {
            Process.Kill();
        }
    }
}
