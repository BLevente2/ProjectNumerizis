using LeviDraw;
using MainProgram;

namespace ProjectNumerizis.Tasks.NumRootTasks;

class BisectionMethodTask : BasicTask
{

    internal Function Function { get; private set; }
    internal double A {  get; private set; }
    internal double B { get; private set; }
    internal double Epsilon { get; private set; }

    internal BisectionMethodTask(string function, double a, double b, double epsilon) : base()
    {
        Function = new Function("Fx", function, Color.Blue);
        A = a;
        B = b;
        Epsilon = epsilon;
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
        TaskResult = CalculateBisection();
    }


    private double CalculateBisection()
    {
        double a = A;
        double b = B;
        double epsilon = Epsilon;
        double result = double.NaN;
        string fx = Function.FunctionExpression;

        TaskSolution.Clear();

        TaskSolution.AppendLine("Bisection Method:");
        TaskSolution.AppendLine($"Given a continuous function f(x) = {fx} on [a, b], where f(a) * f(b) < 0, there exists a root in (a, b).\n");
        TaskSolution.AppendLine("Step 1: Define the stopping criterion. We continue the iterations while (b - a) / 2 > epsilon.\n");
        TaskSolution.AppendLine("Step 2: Compute the midpoint using the formula: c = (a + b) / 2\n");
        TaskSolution.AppendLine("Step 3: Evaluate f(c). If f(c) = 0, then c is the root. Otherwise, determine the next interval:\n");
        TaskSolution.AppendLine("    - If f(a) * f(c) < 0, then the root is in [a, c], so we set b = c.\n");
        TaskSolution.AppendLine("    - Otherwise, the root is in [c, b], so we set a = c.\n");
        TaskSolution.AppendLine("Step 4: Repeat steps 2-3 until the stopping criterion is met.\n");

        int iteration = 1;
        while ((b - a) / 2 > epsilon)
        {
            double c = (a + b) / 2;
            double f_a = Function.Evaluate(a);
            double f_b = Function.Evaluate(b);
            double f_c = Function.Evaluate(c);

            TaskSolution.AppendLine($"Iteration {iteration}:");
            TaskSolution.AppendLine($"Current interval: [{a}, {b}]");
            TaskSolution.AppendLine($"Midpoint: c = (a + b) / 2 = {c}");
            TaskSolution.AppendLine($"Function values: f(a) = {f_a}, f(b) = {f_b}, f(c) = {f_c}");

            if (f_c == 0)
            {
                TaskSolution.AppendLine("Since f(c) = 0, the exact root has been found at c.");
                return c;
            }
            else if (f_a * f_c < 0)
            {
                TaskSolution.AppendLine("Since f(a) * f(c) < 0, the root lies in the left subinterval [a, c]. Setting b = c.\n");
                b = c;
            }
            else
            {
                TaskSolution.AppendLine("Since f(a) * f(c) >= 0, the root lies in the right subinterval [c, b]. Setting a = c.\n");
                a = c;
            }

            iteration++;
        }

        double final_result = (a + b) / 2;
        TaskSolution.AppendLine("Stopping criterion met: (b - a) / 2 <= epsilon");
        TaskSolution.AppendLine($"Approximated root: {final_result}\n");

        return final_result;
    }

}