using LeviDraw;
using MainProgram;

namespace ProjectNumerizis.Tasks.NumRootTasks;

class FixPointIterationTask : BasicTask
{

    internal Function Function { get; private set; }
    internal double X0 { get; private set; }
    internal double Epsilon { get; private set; }
    internal int MaxIterations { get; private set; }

    internal FixPointIterationTask(string function, double x0, double epsilon, int maxIter) : base()
    {
        Function = new Function("Fx", function, Color.Blue);
        X0 = x0;
        Epsilon = epsilon;
        MaxIterations = maxIter;
    }

    public override void EndSimulation(MainWindow mainWindow)
    {
        mainWindow.RemoveFunction(Function);
    }

    public override void Simulate(MainWindow mainWindow)
    {
        mainWindow.AddFunction(Function);
    }

    internal override void Calculate()
    {
        TaskResult = CalculateFixPointIteration();
    }

    private double CalculateFixPointIteration()
    {
        TaskSolution.Clear();
        Function g = Function;
        double x0 = X0;
        double epsilon = Epsilon;
        int maxIter = MaxIterations;

        TaskSolution.AppendLine("Fixed-Point Iteration:\n");
        TaskSolution.AppendLine("Step 1: Transform the equation f(x) = 0 into x = g(x).\n");
        TaskSolution.AppendLine("Step 2: Define the iteration formula: x_{k+1} = g(x_k)\n");
        TaskSolution.AppendLine("Step 3: Choose an initial approximation x_0 = " + x0 + "\n");
        TaskSolution.AppendLine("Step 4: Define convergence criterion: |x_{k+1} - x_k| < epsilon, where epsilon = " + epsilon + "\n");
        TaskSolution.AppendLine("Step 5: Perform iterations up to a maximum of " + maxIter + " steps.\n");

        if (maxIter <= 0)
        {
            TaskSolution.AppendLine("Error: The maximum number of iterations must be greater than zero.\n");
            return double.NaN;
        }

        if (epsilon <= 0)
        {
            TaskSolution.AppendLine("Error: The convergence criterion (epsilon) must be greater than zero.\n");
            return double.NaN;
        }

        double x = x0;
        for (int i = 0; i < maxIter; i++)
        {
            double xNew = g.Evaluate(x);

            TaskSolution.AppendLine($"Iteration {i + 1}:");
            TaskSolution.AppendLine($"   x_k = {x}");
            TaskSolution.AppendLine($"   x_(k+1) = g(x_k) = {xNew}");
            TaskSolution.AppendLine($"   |x_(k+1) - x_k| = {Math.Abs(xNew - x)}\n");

            if (double.IsNaN(xNew) || double.IsInfinity(xNew))
            {
                TaskSolution.AppendLine("Error: The function evaluation resulted in an invalid number (NaN or Infinity).\n");
                return double.NaN;
            }

            if (Math.Abs(xNew - x) < epsilon)
            {
                TaskSolution.AppendLine("Step 6: Convergence reached. Solution found: x = " + xNew + "\n");
                return xNew;
            }
            x = xNew;
        }

        TaskSolution.AppendLine("Step 6: Maximum iterations reached without convergence. Returning last computed value: x = " + x + "\n");
        return x;
    }

}