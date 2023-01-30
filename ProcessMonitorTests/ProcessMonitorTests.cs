using Moq;
using ProcessMonitor;
using NUnit.Framework;

namespace ProcessMonitorTests
{
    public class ProcessMonitorTests
    {

        [Test]
        public void ProcessMonitorUtil_KillProcess_ShouldKill_OldProcess()
        {
            // Arrange
            string name = "onenote";
            DateTime startTime = DateTime.Now.Subtract(TimeSpan.FromMinutes(10));
            var procFake = new ProcessFake(name, startTime);
            List<IProcessWrapper> processFakes = new() { procFake };

            var procProxyMock = new Mock<IProcessProxy>();
            procProxyMock.Setup(p => p.GetProcessesByNameProxy(It.IsAny<string>())).Returns(processFakes);
            var processHandler = new ProcessMonitorUtil(procProxyMock.Object);

            // Act
            processHandler.KillProcess(name, maxProcAge: TimeSpan.FromSeconds(5));

            // Assert
            Assert.That(procFake.procKilled, Is.True);
        }

        [Test]
        public void ProcessMonitorUtil_KillProcess_ShouldNotKill_YoungProcess()
        {
            // Arrange
            string name = "onenote";
            DateTime startTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(1));
            var procFake = new ProcessFake(name, startTime);
            List<IProcessWrapper> processFakes = new() { procFake };

            var procProxyMock = new Mock<IProcessProxy>();
            procProxyMock.Setup(p => p.GetProcessesByNameProxy(It.IsAny<string>())).Returns(processFakes);
            var processHandler = new ProcessMonitorUtil(procProxyMock.Object);

            // Act
            processHandler.KillProcess(name, maxProcAge: TimeSpan.FromSeconds(5));

            // Assert
            Assert.That(procFake.procKilled, Is.False);
        }

        [Test]
        public void ProcessMonitorUtil_KillProcess_ShouldNotKill_NoProcess()
        {
            // Arrange
            string name = "onenote";
            DateTime startTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(1));
            var procFake = new ProcessFake(name, startTime);
            List<IProcessWrapper> processFakes = new() { };

            var procProxyMock = new Mock<IProcessProxy>();
            procProxyMock.Setup(p => p.GetProcessesByNameProxy(It.IsAny<string>())).Returns(processFakes);
            var processHandler = new ProcessMonitorUtil(procProxyMock.Object);

            // Act
            processHandler.KillProcess(name, maxProcAge: TimeSpan.FromSeconds(5));

            // Assert
            Assert.That(procFake.procKilled, Is.False);
        }
    }
}