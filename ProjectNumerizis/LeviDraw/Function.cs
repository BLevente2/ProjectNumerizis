using Expr = MathNet.Symbolics.SymbolicExpression;
using System.Text.RegularExpressions;

namespace LeviDraw;

public class Function : IDisposable
{
    #region PropertiesAndConstructors

    private Expr _expression;
    private Func<double, double> _compiledFunction;
    private Func<double, double> _compiledDerivative;
    private Func<double, double>? _compiledSecondDerivative;
    private Dictionary<double, (double Y, double Derivative)> _cache = new Dictionary<double, (double, double)>();
    private LinkedList<double> _cacheOrder = new LinkedList<double>();
    private object _cacheLock = new object();
    private const int HardMaxCacheSize = 10000;
    private const int NotHardMaxCacheSize = 5000;
    private int MaxCacheSize;
    private bool _disposed = false;
    private Expr _derivativeExpression;
    public string Name { get; private set; }
    public Color FunctionColor { get; private set; }
    public bool Enabled { get; set; }
    public double LastEvaluationOfDerivative { get; set; }
    public bool HardToEvaluate { get; private set; }
    public Pen FunctionPen { get; private set; }
    public const int FunctionPenWidth = 2;

    public string DerivativeFunction => _derivativeExpression.ToString();
    public string FunctionExpression => _expression.ToString();


    public Function(string name, string function, Color functionColor)
    {
        _expression = Expr.Parse(function);
        var variable = Expr.Variable("x");
        Expr derivative;
        try
        {
            derivative = _expression.Differentiate("x");
            _derivativeExpression = derivative;
        }
        catch
        {
            throw new InvalidOperationException("The function is not differentiable.");
        }
        _compiledFunction = _expression.Compile("x");
        _compiledDerivative = derivative.Compile("x");
        Name = name;
        FunctionColor = functionColor;
        FunctionPen = new Pen(functionColor, FunctionPenWidth);
        Enabled = true;
        LastEvaluationOfDerivative = double.NaN;
        string exprStr = _expression.ToString().ToLowerInvariant();
        bool containsSin = exprStr.Contains("sin(") && !exprStr.Contains("asin(");
        bool containsCos = exprStr.Contains("cos(") && !exprStr.Contains("acos(") && !exprStr.Contains("cosh(");
        bool containsTan = exprStr.Contains("tan(") && !exprStr.Contains("atan(");
        bool containsCot = exprStr.Contains("cot(") && !exprStr.Contains("acot(");
        bool containsSinh = exprStr.Contains("sinh(");
        bool containsTanh = exprStr.Contains("tanh(");
        bool containsCoth = exprStr.Contains("coth(");
        bool hasHyperbola = exprStr.Contains("/x") || exprStr.Contains("1/x");
        bool highDegree = false;
        foreach (Match m in Regex.Matches(exprStr, @"x\^(\d+(\.\d+)?)"))
        {
            if (double.TryParse(m.Groups[1].Value, out double degree))
            {
                if (degree >= 4)
                {
                    highDegree = true;
                    break;
                }
            }
        }
        HardToEvaluate = containsSin || containsCos || containsTan || containsCot || containsSinh || containsTanh || containsCoth || hasHyperbola || highDegree;

        if (HardToEvaluate)
        {
            MaxCacheSize = HardMaxCacheSize;
        }
        else
        {
            {
                MaxCacheSize = NotHardMaxCacheSize;
            }
        }

        try
        {
            var secondDerivativeExpr = derivative.Differentiate("x");
            _compiledSecondDerivative = secondDerivativeExpr.Compile("x");
        }
        catch
        {
            _compiledSecondDerivative = null;
        }
    }

    #endregion

    #region Utilities

    public void ChangeExpression(string newExpression)
    {
        _expression = Expr.Parse(newExpression);
        Expr derivative;
        try
        {
            derivative = _expression.Differentiate("x");
        }
        catch
        {
            throw new InvalidOperationException("The function is not differentiable.");
        }
        _compiledFunction = _expression.Compile("x");
        _compiledDerivative = derivative.Compile("x");
        try
        {
            var secondDerivativeExpr = derivative.Differentiate("x");
            _compiledSecondDerivative = secondDerivativeExpr.Compile("x");
        }
        catch
        {
            _compiledSecondDerivative = null;
        }
        lock (_cacheLock)
        {
            _cache.Clear();
            _cacheOrder.Clear();
        }
    }

    private double Quantize(double x)
    {
        return Math.Round(x, 6);
    }

    private void AddToCache(double key, (double Y, double Derivative) value)
    {
        lock (_cacheLock)
        {
            if (_cache.ContainsKey(key))
            {
                _cacheOrder.Remove(key);
            }
            else
            {
                if (_cache.Count >= MaxCacheSize)
                {
                    double oldest = _cacheOrder.Last.Value;
                    _cacheOrder.RemoveLast();
                    _cache.Remove(oldest);
                }
            }
            _cache[key] = value;
            _cacheOrder.AddFirst(key);
        }
    }

    private bool TryGetFromCache(double key, out (double Y, double Derivative) value)
    {
        lock (_cacheLock)
        {
            if (_cache.TryGetValue(key, out value))
            {
                _cacheOrder.Remove(key);
                _cacheOrder.AddFirst(key);
                return true;
            }
            return false;
        }
    }

    public double Evaluate(double x)
    {
        double key = Quantize(x);
        if (TryGetFromCache(key, out var value))
            return value.Y;
        double y;
        try
        {
            y = _compiledFunction(x);
        }
        catch
        {
            y = double.NaN;
        }
        double d;
        try
        {
            d = _compiledDerivative(x);
        }
        catch
        {
            d = double.NaN;
        }
        AddToCache(key, (y, d));
        return y;
    }

    public double EvaluateDerivative(double x)
    {
        double key = Quantize(x);
        if (TryGetFromCache(key, out var value))
            return value.Derivative;
        double y;
        try
        {
            y = _compiledFunction(x);
        }
        catch
        {
            y = double.NaN;
        }
        double d;
        try
        {
            d = _compiledDerivative(x);
        }
        catch
        {
            d = double.NaN;
        }
        AddToCache(key, (y, d));
        return d;
    }

    public double? EvaluateSecondDerivative(double x)
    {
        if (_compiledSecondDerivative == null)
            return null;
        try
        {
            return _compiledSecondDerivative(x);
        }
        catch
        {
            return double.NaN;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                lock (_cacheLock)
                {
                    _cache.Clear();
                    _cacheOrder.Clear();
                }
            }
            _disposed = true;
        }
    }
    ~Function()
    {
        Dispose(false);
    }

    #endregion
}