using MainProgram;
using System.Text;

namespace ProjectNumerizis.Tasks;

internal abstract class BasicTask : ISimulatableTask
{

    internal double TaskResult { get; set; }
    internal StringBuilder TaskSolution { get; set; }

    internal BasicTask()
    {
        TaskResult = 0;
        TaskSolution = new StringBuilder();
    }

    internal abstract void Calculate();

    public abstract Task Simulate(MainWindow mainWindow);
}