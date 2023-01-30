namespace ProcessMonitor

{
    public interface IProcessWrapper
    {
        DateTime StartTime { get; set; }
        void Kill();

    }
}
