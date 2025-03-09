using MainProgram;

namespace ProjectNumerizis.Tasks;

public interface ISimulatableTask
{

    public Task Simulate(MainWindow mainWindow);

}