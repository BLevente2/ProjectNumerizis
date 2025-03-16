using LeviDraw;
using MainProgram;

namespace ProjectNumerizis.Tasks.NumDifTasks;

internal class NewtonSecondDerivativeTask : BaseNumDifTask
{
    internal NewtonSecondDerivativeTask(string originalFunction, double xOfDif, double h) : base(originalFunction, xOfDif, h)
    {
        DerivativeFunction = new Function(SecondDerivateFunctionDefName, DerivativeFunction.DerivativeFunction, DerivativeFunctionDefColor);
        ActualDif = DerivativeFunction.Evaluate(xOfDif);
        AActualDifPoint = new PointData(xOfDif, ActualDif, ActualDifPointDefColor);
    }

    internal override void Calculate()
    {
        double x = XOfDif;
        double h = H;
        double f_x_h = OriginalFunction.Evaluate(x + h);
        double f_x = OriginalFunction.Evaluate(x);
        double f_x_neg_h = OriginalFunction.Evaluate(x - h);
        double derivative = (f_x_h - 2 * f_x + f_x_neg_h) / (h * h);
        string fx = OriginalFunction.FunctionExpression;
        string ddfx = OriginalFunction.DerivativeFunction;

        NumDifPoint = new PointData(x, derivative, NumDifPointDefColor);

        TaskSolution.Clear();
        TaskSolution.Append("Numerical Analysis Solution Using Newton's Second Derivative:\n");
        TaskSolution.Append($"f(x) = {fx}\n");
        TaskSolution.Append($"f''x = {ddfx}\n");
        TaskSolution.Append($"f''({x}) = {ActualDif}\n");
        TaskSolution.Append($"Step 1: Define function f(x) at x = {x}\n");
        TaskSolution.Append($"f({x}) = {f_x}\n");
        TaskSolution.Append($"Step 2: Compute f(x + h) and f(x - h) where h = {h}\n");
        TaskSolution.Append($"f({x} + {h}) = f({x + h}) = {f_x_h}\n");
        TaskSolution.Append($"f({x} - {h}) = f({x - h}) = {f_x_neg_h}\n");
        TaskSolution.Append("Step 3: Apply Newton's Second Derivative Formula:\n");
        TaskSolution.Append($"f''({x}) ≈ (f({x} + {h}) - 2f({x}) + f({x} - {h})) / h²\n");
        TaskSolution.Append($"f''({x}) ≈ ({f_x_h} - 2 * {f_x} + {f_x_neg_h}) / ({h}²)\n");
        TaskSolution.Append($"f''({x}) ≈ {derivative}\n");

        TaskResult = derivative;
    }
}