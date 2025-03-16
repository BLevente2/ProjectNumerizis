using LeviDraw;
using MainProgram;
using System.Globalization;
using System.Text;

namespace ProjectNumerizis.Tasks.NumDifTasks;

internal class LagrangeSecondOrderTask : BaseNumDifTask
{
    internal List<PointData> InterpolationPoints;

    internal LagrangeSecondOrderTask(double xOfDif, List<PointData> interpolationPoints) : base(LagrangeInterpolation(interpolationPoints), xOfDif, 0)
    {
        InterpolationPoints = interpolationPoints;
        DerivativeFunction = new Function(SecondDerivateFunctionDefName, DerivativeFunction.DerivativeFunction, DerivativeFunctionDefColor);
        ActualDif = DerivativeFunction.Evaluate(xOfDif);
        AActualDifPoint = new PointData(xOfDif, ActualDif, ActualDifPointDefColor);

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
        foreach (PointData point in InterpolationPoints)
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

            if (i > 0 && y[i] >= 0)
                functionExpression.Append(" + ");
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

        double secondDerivative = 0.0;
        StringBuilder derivativeBreakdown = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            double term = 0.0;
            StringBuilder termBreakdown = new StringBuilder($"[ y{i} * (");

            for (int j = 0; j < n; j++)
            {
                if (j == i)
                    continue;

                double innerSum = 0.0;
                StringBuilder innerBreakdown = new StringBuilder("(");

                for (int l = 0; l < n; l++)
                {
                    if (l == i || l == j)
                        continue;

                    double product = 1.0;
                    StringBuilder productBreakdown = new StringBuilder();

                    for (int k = 0; k < n; k++)
                    {
                        if (k == i || k == j || k == l)
                            continue;
                        product *= (x0 - x[k]) / (x[i] - x[k]);
                        productBreakdown.AppendFormat(CultureInfo.InvariantCulture, "(x0 - {0})/({1} - {0}) * ", x[k], x[i]);
                    }

                    string productStr = productBreakdown.ToString().TrimEnd(' ', '*');
                    if (string.IsNullOrEmpty(productStr))
                        productStr = "1";

                    double subterm = (1.0 / (x[i] - x[l])) * product;
                    innerSum += subterm;
                    innerBreakdown.AppendFormat(CultureInfo.InvariantCulture, " (1/({0} - {1}))*{2} + ", x[i], x[l], productStr);
                }

                string innerBreakdownStr = innerBreakdown.ToString().TrimEnd(' ', '+');
                innerBreakdownStr += " )";

                double subProduct = (1.0 / (x[i] - x[j])) * innerSum;
                term += subProduct;
                termBreakdown.AppendFormat(CultureInfo.InvariantCulture, " (1/({0} - {1}))*{2} + ", x[i], x[j], innerBreakdownStr);
            }

            string termBreakdownStr = termBreakdown.ToString().TrimEnd(' ', '+');
            termBreakdownStr += " )]";
            secondDerivative += y[i] * term;
            derivativeBreakdown.AppendLine(termBreakdownStr);
        }

        NumDifPoint = new PointData(x0, secondDerivative, NumDifPointDefColor);

        TaskSolution.Clear();
        TaskSolution.AppendLine("=== Numerical Analysis: Lagrange Second Order Derivative ===");
        TaskSolution.AppendLine($"Given function f(x):\n  f(x) = {OriginalFunction.FunctionExpression}");
        TaskSolution.AppendLine("Second-order derivative f''(x):");
        TaskSolution.AppendLine($"Approximated second derivative at x = {x0}:");
        TaskSolution.AppendLine($"  f''({x0}) ≈ {secondDerivative}");
        TaskSolution.AppendLine("\n--- Step 1: Define Interpolation Points ---");

        for (int i = 0; i < n; i++)
        {
            TaskSolution.AppendLine($"  P{i}: ({x[i]}, {y[i]})");
        }

        TaskSolution.AppendLine("\n--- Step 2: Compute Lagrange Second Order Derivative ---");
        TaskSolution.AppendLine("Using the formula:");
        TaskSolution.AppendLine("  f''(x0) ≈ Σ [ y[i] * Σ (1/(x[i]-x[j])) * Σ (1/(x[i]-x[l]) * Π ((x0 - x[k])/(x[i]-x[k])) ) ]");
        TaskSolution.AppendLine("\nDetailed calculation breakdown:");
        TaskSolution.AppendLine(derivativeBreakdown.ToString());

        TaskResult = secondDerivative;
    }

}