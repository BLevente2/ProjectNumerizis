using LeviDraw;
using MainProgram;

namespace ProjectNumerizis.Tasks.NumDifTasks;

internal class NewtonBackwardDifferenceTask : BaseNumDifTask
{
    internal NewtonBackwardDifferenceTask(string originalFunction, double xOfDif, double h) : base(originalFunction, xOfDif, h)
    {

    }

    internal override void Calculate()
    {
        double x = XOfDif;
        double h = H;
        double f_x = OriginalFunction.Evaluate(x);
        double f_x_neg_h = OriginalFunction.Evaluate(x - h);
        double f_x_neg_2h = OriginalFunction.Evaluate(x - 2 * h);
        double derivative = (3 * f_x - 4 * f_x_neg_h + f_x_neg_2h) / (2 * h);
        string fx = OriginalFunction.FunctionExpression;
        string dfx = OriginalFunction.DerivativeFunction;
        NumDifPoint = new PointData(x, derivative, NumDifPointDefColor);

        TaskSolution.Clear();
        TaskSolution.Append("Numerical Analysis Solution Using Newton Backward Difference:\n");
        TaskSolution.Append($"f(x) = {fx}\n");
        TaskSolution.Append($"f'x = {dfx}\n");
        TaskSolution.Append($"f'({x}) = {ActualDif}\n");
        TaskSolution.Append($"Step 1: Define function f(x) at x = {x}\n");
        TaskSolution.Append($"f({x}) = {f_x}\n");
        TaskSolution.Append($"Step 2: Compute f(x - h) and f(x - 2h) where h = {h}\n");
        TaskSolution.Append($"f({x} - {h}) = f({x - h}) = {f_x_neg_h}\n");
        TaskSolution.Append($"f({x} - {2 * h}) = f({x - 2 * h}) = {f_x_neg_2h}\n");
        TaskSolution.Append("Step 3: Apply Newton Backward Difference Formula:\n");
        TaskSolution.Append($"f'({x}) ≈ (3f({x}) - 4f({x} - {h}) + f({x} - {2 * h})) / (2h)\n");
        TaskSolution.Append($"f'({x}) ≈ (3 * {f_x} - 4 * {f_x_neg_h} + {f_x_neg_2h}) / (2 * {h})\n");
        TaskSolution.Append($"f'({x}) ≈ {derivative}\n");

        TaskResult = derivative;
    }
}