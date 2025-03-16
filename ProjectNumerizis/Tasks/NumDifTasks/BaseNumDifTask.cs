using LeviDraw;
using MainProgram;

namespace ProjectNumerizis.Tasks.NumDifTasks;

internal abstract class BaseNumDifTask : BasicTask
{

    internal Function OriginalFunction { get; set; }
    internal Function DerivativeFunction { get; set; }
    internal double XOfDif { get; set; }    
    internal double H {  get; set; }
    internal double ActualDif { get; set; }
    internal double NumDif { get; set; }
    internal PointData AActualDifPoint { get; set; }
    internal PointData NumDifPoint { get; set; }

    internal static Color OriginalFunctionDefColor = Color.Blue;
    internal static Color DerivativeFunctionDefColor = Color.Pink;
    internal static Color ActualDifPointDefColor = Color.Cyan;
    internal static Color NumDifPointDefColor = Color.Red;
    internal static string OriginalFunctionDefName = "Fx";
    internal static string DerivativeFunctionDefName = "F'";
    internal static string SecondDerivateFunctionDefName = "F''";


    internal BaseNumDifTask(string originalFunction, double xOfDif, double h) : base()
    {
        OriginalFunction = new Function(OriginalFunctionDefName, originalFunction, OriginalFunctionDefColor);
        DerivativeFunction = new Function(DerivativeFunctionDefName, OriginalFunction.DerivativeFunction, DerivativeFunctionDefColor);
        XOfDif = xOfDif;
        H = h;
        ActualDif = DerivativeFunction.Evaluate(xOfDif);
        NumDif = 0;
        AActualDifPoint = new PointData(xOfDif, ActualDif, ActualDifPointDefColor);
        NumDifPoint = new PointData(xOfDif, 0, NumDifPointDefColor);
    }

    public override void Simulate(MainWindow mainWindow)
    {
        Calculate();
        mainWindow.AddFunction(OriginalFunction);
        mainWindow.AddFunction(DerivativeFunction);
        mainWindow.AddPoint(AActualDifPoint);
        mainWindow.AddPoint(NumDifPoint);
    }

    internal override abstract void Calculate();

    public override void EndSimulation(MainWindow mainWindow)
    {
        mainWindow.RemoveFunction(OriginalFunction);
        mainWindow.RemoveFunction(DerivativeFunction);
        mainWindow.RemovePoint(AActualDifPoint);
        mainWindow.RemovePoint(NumDifPoint);
    }

}