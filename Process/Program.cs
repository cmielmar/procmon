using System.ComponentModel;

namespace ProcessMonitor

{

    internal class Program
    {
        static void Main(string[] args)
        {
            var procWrapper = new ProcessProxy();
            var pm = new ProcessMonitorUtil(procWrapper);

            // only for debug
            // pm.MonitorProcess("onenote");
            try
            {
                var procName = args[0];
                var maxProcAge = args[1];
                var freq = args[2];
                pm.MonitorProcess(procName, maxProcAge, freq);
            }
            catch (Exception)
            {
                Console.WriteLine("Usage: Procs.exe <process name> <wait time> <frequency>");
            }
        }
    }
}
