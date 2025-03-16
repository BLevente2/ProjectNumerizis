using LeviDraw;
using MainProgram;
using System.Globalization;
using System.Text;

namespace ProjectNumerizis.Tasks.NumDifTasks;

internal class LagrangeFirstOrderTask : BaseNumDifTask
{
    internal List<PointData> InterpolationPoints;

    internal LagrangeFirstOrderTask(double xOfDif, List<PointData> interpolationPoints) : base(LagrangeInterpolation(interpolationPoints), xOfDif, 0)
    {
        InterpolationPoints = interpolationPoints;

    }

    public override void Simulate(MainWindow mainWindow)
    {
        base.Simulate(mainWindow);
        foreach (PointData point in InterpolationPoints)
        {
            mainWindow.AddPoint(point);
        }
    }

    public override void EndSimulation(MainWindow mainWindow)
    {
        base.EndSimulation(mainWindow);
        foreach(PointData point in InterpolationPoints)
        {
            mainWindow.RemovePoint(point);
        }
    }

    private static string LagrangeInterpolation(List<PointData> interpolationPoints)
    {
        int n = interpolationPoints.Count;
        List<double> x = interpolationPoints.Select(p => p.X).ToList();
        List<double> y = interpolationPoints.Select(p => p.Y).ToList();

        StringBuilder functionExpression = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            StringBuilder term = new StringBuilder();
            term.Append(CultureInfo.InvariantCulture, $"{y[i]:0.######}");

            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    term.AppendFormat(CultureInfo.InvariantCulture, " * (x - {0:0.######}) / ({1:0.######})", x[j], x[i] - x[j]);
                }
            }

            if (i > 0 && y[i] >= 0) functionExpression.Append(" + ");
            functionExpression.Append(term);
        }

        return functionExpression.ToString();
    }

    internal override void Calculate()
    {
        double x0 = XOfDif;
        int n = InterpolationPoints.Count;
        List<double> x = InterpolationPoints.Select(p => p.X).ToList();
        List<double> y = InterpolationPoints.Select(p => p.Y).ToList();

        double derivative = 0.0;
        StringBuilder derivativeBreakdown = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            double term = 0.0;
            StringBuilder termBreakdown = new StringBuilder($"[ y{i} * (");

            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    double product = 1.0;
                    StringBuilder productBreakdown = new StringBuilder();

                    for (int k = 0; k < n; k++)
                    {
                        if (k != i && k != j)
                        {
                            product *= (x0 - x[k]) / (x[i] - x[k]);
                            productBreakdown.AppendFormat("(x0 - {0}) / ({1} - {2}) * ", x[k], x[i], x[k]);
                        }
                    }

                    term += (1.0 / (x[i] - x[j])) * product;
                    termBreakdown.AppendFormat("(1 / ({0} - {1})) * {2} ) + ", x[i], x[j], productBreakdown.ToString().TrimEnd('*', ' '));
                }
            }

            derivative += y[i] * term;
            derivativeBreakdown.AppendLine(termBreakdown.ToString().TrimEnd('+', ' ') + "]");
        }

        NumDifPoint = new PointData(x0, derivative, NumDifPointDefColor);

        TaskSolution.Clear();
        TaskSolution.AppendLine("=== Numerical Analysis: Lagrange First Order Derivative ===");
        TaskSolution.AppendLine($"Given function f(x):\n  f(x) = {OriginalFunction.FunctionExpression}");
        TaskSolution.AppendLine($"First-order derivative f'(x):\n  f'(x) = {OriginalFunction.DerivativeFunction}");
        TaskSolution.AppendLine($"Approximated derivative at x = {x0}:");
        TaskSolution.AppendLine($"  f'({x0}) ≈ {derivative}");
        TaskSolution.AppendLine("\n--- Step 1: Define Interpolation Points ---");

        for (int i = 0; i < n; i++)
        {
            TaskSolution.AppendLine($"  P{i}: ({x[i]}, {y[i]})");
        }

        TaskSolution.AppendLine("\n--- Step 2: Compute Lagrange Derivative ---");
        TaskSolution.AppendLine("Using the formula:");
        TaskSolution.AppendLine("  f'(x0) ≈ Σ [ y[i] * Σ (1 / (x[i] - x[j])) * Π ((x0 - x[k]) / (x[i] - x[k])) ]");
        TaskSolution.AppendLine("\nDetailed calculation breakdown:");
        TaskSolution.AppendLine(derivativeBreakdown.ToString());

        TaskResult = derivative;
    }

}