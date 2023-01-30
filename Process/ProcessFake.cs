namespace ProcessMonitor

{
    public class ProcessFake : IProcessWrapper
    {
        public bool procKilled{ get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }

        public ProcessFake(string name, DateTime startTime)
        {
            this.Name = name;
            this.StartTime = startTime;
        }

        public void Kill()
        {
            procKilled = true;
        }
    }
}
