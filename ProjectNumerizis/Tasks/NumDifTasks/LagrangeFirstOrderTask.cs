using LeviDraw;
using MainProgram;
using System.Text;

namespace ProjectNumerizis.Tasks.NumDifTasks;

internal class LagrangeFirstOrderTask : BaseNumDifTask
{
    internal List<PointData> InterpolationPoints;

    internal LagrangeFirstOrderTask(double xOfDif, List<PointData> interpolationPoints) : base(LagrangeInterpolation(interpolationPoints), xOfDif, 0)
    {
        InterpolationPoints = interpolationPoints;

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
            term.Append($"{y[i]}");
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    term.Append($" * (x - {x[j]}) / ({x[i] - x[j]})");
                }
            }
            if (i > 0) functionExpression.Append(" + ");
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
        for (int i = 0; i < n; i++)
        {
            double term = y[i];
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    term /= (x[i] - x[j]);
                }
            }
            derivative += term;
        }

        string fx = OriginalFunction.FunctionExpression;
        string dfx = OriginalFunction.DerivativeFunction;
        NumDifPoint = new PointData(x0, derivative, NumDifPointDefColor);

        TaskSolution.Clear();
        TaskSolution.Append("Numerical Analysis Solution Using Lagrange First Order Derivative:");
        TaskSolution.Append($"f(x) = {fx}");
        TaskSolution.Append($"f'x = {dfx}");
        TaskSolution.Append($"f'({x0}) = {ActualDif}");
        TaskSolution.Append("Step 1: Define given interpolation points:");
        for (int i = 0; i < n; i++)
        {
            TaskSolution.Append($"P{i}: ({x[i]}, {y[i]})");
        }
        TaskSolution.Append("Step 2: Apply Lagrange Interpolation Formula:");
        TaskSolution.Append($"f'({x0}) ≈ Σ (y[i] * Π (1 / (x[i] - x[j])) for i ≠ j)");
        TaskSolution.Append($"f'({x0}) ≈ {derivative}");
    }

}