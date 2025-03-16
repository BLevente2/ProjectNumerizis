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

    }
}