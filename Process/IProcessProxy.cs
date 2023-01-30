using System.Diagnostics;

namespace ProcessMonitor

{
    public interface IProcessProxy
    {
        List<IProcessWrapper> GetProcessesByNameProxy(string procName);
    }
}
