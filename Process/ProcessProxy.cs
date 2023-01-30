using System.Diagnostics;

namespace ProcessMonitor

{
    public class ProcessProxy : IProcessProxy
    {
        public List<IProcessWrapper> GetProcessesByNameProxy(string procName)
        {
            var wrappedProcesses = new List<IProcessWrapper>();
            Process[] processes = Process.GetProcessesByName(procName);
            foreach (var pr in processes)
            {
                var procProxy = new ProcessWrapper(pr);
                wrappedProcesses.Add(procProxy);
            }

            return wrappedProcesses;
        }
    }
}
