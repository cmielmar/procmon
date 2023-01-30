using System.Diagnostics;

namespace ProcessMonitor

{
    public class ProcessMonitorUtil
     {
        public IProcessProxy ProcessProxy { get; set; }

        public ProcessMonitorUtil(IProcessProxy procProxy)
        {
            ProcessProxy = procProxy;
        }

        public void MonitorProcess(string processName = "onenote", string maxProcAge = "2", string freq = "1")
        {
            var maxAge = TimeSpan.FromMinutes(int.Parse(maxProcAge));
            var nextPeriod = TimeSpan.FromMinutes(int.Parse(freq));
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Press q to end the program.");

            KillProcess(processName, maxAge);
            while (true)
            {
                if (sw.Elapsed >= nextPeriod)
                {
                    KillProcess(processName, maxAge);
                    sw.Restart();
                }

                ExitApp();
            }
        }

        private void ExitApp()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().KeyChar;
                if (key == 'q')
                {
                    Environment.Exit(0);
                }
            }
        }

        public void KillProcess(string procName, TimeSpan maxProcAge)
        {
            var processes = ProcessProxy.GetProcessesByNameProxy(procName);
            
                foreach (var proc in processes)
                {
                    var procAge = DateTime.Now - proc.StartTime;
                    Console.WriteLine($"Process runtime: {procAge}");

                    if (procAge > maxProcAge)
                    {
                        proc.Kill();
                        Console.Error.WriteLine($"Process <{procName}> was killed after {procAge} minutes");
                    }
                }
        }
    }
}