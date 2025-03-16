using MainProgram;

namespace ProjectNumerizis.Tasks;

public interface ISimulatableTask
{

    public void Simulate(MainWindow mainWindow);
    public void EndSimulation(MainWindow mainWindow);

}