namespace LeviDraw;

public class CoordinateSystem
{
    #region PropertiesAndConstructors

    public const double TRESHOLD = 1200.0;
    public const double VERTICAL_SLOPE_LIMIT = 500.0;
    public static readonly Color DEFAULT_POINT_COLOR = Color.Blue;
    public static readonly Color DEFAULT_FUNCTION_COLOR = Color.Orange;

    private double _width;
    private double _height;
    private double _offsetX;
    private double _offsetY;
    private double _magnificationMultiplier;
    private List<Function> _hardFunctions;
    private List<List<Function>> _nonHardGroups;
    private int _cachedFunctionsHash;

    public List<PointData> Points {  get; private set; }
    public List<Function> Functions { get; private set; }
    public List<Function> EnabledFunctions { get; set; }
    public Color PointColor { get; set; }
    public Color FunctionColor { get; set; }
    public bool RenderGridLines { get; set; }
    public bool RenderAxes { get; set; }
    public bool RenderAxisLabels { get; set; }
    public double GridSpacing { get; set; }
    public double PointSizeMultiplier { get; set; }

    public double MagnificationMultiplier
    {
        get { return _magnificationMultiplier; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Magnification multiplier must be greater than zero.");
            }

            double centerX = _width / 2;
            double centerY = _height / 2;
            _offsetX = centerX - (centerX - _offsetX) * (value / _magnificationMultiplier);
            _offsetY = centerY - (centerY - _offsetY) * (value / _magnificationMultiplier);

            _magnificationMultiplier = value;
        }
    }

    public CoordinateSystem(double width, double height)
    {
        _width = width;
        _height = height;
        _offsetX = width / 2;
        _offsetY = height / 2;
        Points = new List<PointData>();
        Functions = new List<Function>();
        EnabledFunctions = new List<Function>();
        PointColor = DEFAULT_POINT_COLOR;
        FunctionColor = DEFAULT_FUNCTION_COLOR;
        _magnificationMultiplier = 1.0;
        RenderGridLines = true;
        RenderAxes = true;
        RenderAxisLabels = true;
        GridSpacing = 30.0;
        PointSizeMultiplier = 1.0;
        _hardFunctions = new List<Function>();
        _nonHardGroups = new List<List<Function>>();
        _cachedFunctionsHash = 0;
    }

    #endregion

    #region MethodsToDrawTheCoordinateSystem

    private void UpdateFunctionGrouping()
    {
        int hash = EnabledFunctions.Count;
        foreach (var f in EnabledFunctions)
        {
            hash ^= f.Name.GetHashCode();
            hash ^= f.HardToEvaluate ? 1 : 0;
        }
        if (hash == _cachedFunctionsHash) return;
        _hardFunctions = EnabledFunctions.Where(f => f.HardToEvaluate).ToList();
        var nonHard = EnabledFunctions.Where(f => !f.HardToEvaluate).ToList();
        _nonHardGroups = new List<List<Function>>();
        for (int i = 0; i < nonHard.Count; i += 3)
        {
            _nonHardGroups.Add(nonHard.Skip(i).Take(3).ToList());
        }
        _cachedFunctionsHash = hash;
    }

    private void DrawFunctions(Graphics g)
    {
        double scaledGridSpacing = GridSpacing * _magnificationMultiplier;
        if (EnabledFunctions.Count <= 3)
        {
            foreach (var function in EnabledFunctions)
            {
                DrawSingleFunction(g, function, scaledGridSpacing);
            }
            return;
        }
        UpdateFunctionGrouping();
        List<Task> tasks = new List<Task>();
        if (_hardFunctions.Count > 0)
        {
            tasks.Add(Task.Run(() =>
            {
                if (_hardFunctions.Count == 1)
                {
                    lock (g)
                    {
                        DrawSingleFunction(g, _hardFunctions[0], scaledGridSpacing);
                    }
                }
                else
                {
                    Parallel.ForEach(_hardFunctions, function =>
                    {
                        lock (g)
                        {
                            DrawSingleFunction(g, function, scaledGridSpacing);
                        }
                    });
                }
            }));
        }
        if (_nonHardGroups != null && _nonHardGroups.Count > 0)
        {
            tasks.Add(Task.Run(() =>
            {
                if (_nonHardGroups.Count == 1)
                {
                    foreach (var function in _nonHardGroups[0])
                    {
                        lock (g)
                        {
                            DrawSingleFunction(g, function, scaledGridSpacing);
                        }
                    }
                }
                else
                {
                    Parallel.ForEach(_nonHardGroups, group =>
                    {
                        foreach (var function in group)
                        {
                            lock (g)
                            {
                                DrawSingleFunction(g, function, scaledGridSpacing);
                            }
                        }
                    });
                }
            }));
        }
        Task.WaitAll(tasks.ToArray());
    }

    private void DrawSingleFunction(Graphics g, Function function, double scaledGridSpacing)
    {
        using (Pen functionPen = new Pen(function.FunctionColor, 2))
        {
            List<PointF> segment = new List<PointF>();
            double prevDerivative = double.NaN;
            for (double screenX = 0; screenX < _width;)
            {
                double coordX = (screenX - _offsetX) / scaledGridSpacing;
                double coordY = function.Evaluate(coordX);
                double derivative = function.EvaluateDerivative(coordX);
                double screenY = _offsetY - coordY * scaledGridSpacing;
                bool isValid = !(double.IsNaN(coordY) || double.IsInfinity(coordY));
                if (isValid && Math.Abs(screenY) > _height * 10)
                {
                    isValid = false;
                }
                bool breakSegment = false;
                if (segment.Count > 0)
                {
                    if (!isValid)
                        breakSegment = true;
                    else if (Math.Abs(derivative - prevDerivative) > TRESHOLD)
                        breakSegment = true;
                    else if (Math.Abs(derivative) > VERTICAL_SLOPE_LIMIT && Math.Abs(screenY - segment.Last().Y) > (_height / 4.0))
                        breakSegment = true;
                }
                if (breakSegment)
                {
                    if (segment.Count > 0)
                    {
                        PointF lastPoint = segment.Last();
                        double lastF = (_offsetY - lastPoint.Y) / scaledGridSpacing;
                        float edgeY = (float)(lastF > 0 ? 0 : (lastF < 0 ? _height : lastPoint.Y));
                        g.DrawLine(functionPen, lastPoint.X, lastPoint.Y, lastPoint.X, edgeY);
                        DrawSegment(g, functionPen, segment);
                        segment.Clear();
                    }
                    if (isValid)
                    {
                        float edgeY = (float)(coordY > 0 ? 0 : (coordY < 0 ? _height : screenY));
                        g.DrawLine(functionPen, (float)screenX, edgeY, (float)screenX, (float)screenY);
                        segment.Add(new PointF((float)screenX, (float)screenY));
                        prevDerivative = derivative;
                    }
                }
                else
                {
                    if (isValid)
                    {
                        segment.Add(new PointF((float)screenX, (float)screenY));
                        prevDerivative = derivative;
                    }
                    else
                    {
                        if (segment.Count > 0)
                        {
                            PointF lastPoint = segment.Last();
                            double lastF = (_offsetY - lastPoint.Y) / scaledGridSpacing;
                            float edgeY = (float)(lastF > 0 ? 0 : (lastF < 0 ? _height : lastPoint.Y));
                            g.DrawLine(functionPen, lastPoint.X, lastPoint.Y, lastPoint.X, edgeY);
                            DrawSegment(g, functionPen, segment);
                            segment.Clear();
                        }
                    }
                }
                screenX += GetAdaptiveStepSize(derivative, prevDerivative, function.HardToEvaluate);
            }
            if (segment.Count > 0)
            {
                PointF lastPoint = segment.Last();
                double lastF = (_offsetY - lastPoint.Y) / scaledGridSpacing;
                float edgeY = (float)(lastF > 0 ? 0 : (lastF < 0 ? _height : lastPoint.Y));
                g.DrawLine(functionPen, lastPoint.X, lastPoint.Y, lastPoint.X, edgeY);
                DrawSegment(g, functionPen, segment);
            }
        }
    }

    private void DrawSegment(Graphics g, Pen pen, List<PointF> segment)
    {
        for (int i = 1; i < segment.Count; i++)
            g.DrawLine(pen, segment[i - 1], segment[i]);
    }

    private double GetAdaptiveStepSize(double derivative, double prevDerivative, bool hard)
    {
        double absDerivative = Math.Abs(derivative);
        double derivativeDiff = !double.IsNaN(prevDerivative) ? Math.Abs(derivative - prevDerivative) : 0;
        double maxStep = (hard ? 5 : 10) * _magnificationMultiplier;
        double minStep = (hard ? 0.5 : 2) * _magnificationMultiplier;
        if (absDerivative >= VERTICAL_SLOPE_LIMIT)
            return minStep;
        double factor = 1.0 / (1.0 + absDerivative + derivativeDiff / 100.0);
        double adaptiveStep = maxStep * factor;
        return Math.Clamp(adaptiveStep, minStep, maxStep);
    }
    private void DrawGrid(Graphics g, Pen gridPen)
    {
        for (double i = _offsetX % GridSpacing; i < _width; i += GridSpacing)
        {
            g.DrawLine(gridPen, (float)i, 0, (float)i, (float)_height);
        }

        for (double i = _offsetY % GridSpacing; i < _height; i += GridSpacing)
        {
            g.DrawLine(gridPen, 0, (float)i, (float)_width, (float)i);
        }
    }

    private void DrawAxes(Graphics g, Pen axesPen)
    {
        g.DrawLine(axesPen, (float)_offsetX, 0, (float)_offsetX, (float)_height);
        g.DrawLine(axesPen, 0, (float)_offsetY, (float)_width, (float)_offsetY);
    }

    private void DrawAxesLables(Graphics g, Color axesColor)
    {
        Font font = new Font("Arial", 8);
        Brush textBrush = new SolidBrush(axesColor);

        for (double i = 1; i <= (_width - _offsetX) / GridSpacing; i++)
        {
            if (i % 5 == 0)
            {
                string labelPos = (i / _magnificationMultiplier).ToString("0.###");
                string labelNeg = (-i / _magnificationMultiplier).ToString("0.###");

                g.DrawString(labelPos, font, textBrush,
                    (float)(_offsetX + i * GridSpacing - 10), (float)(_offsetY + 5));
                g.DrawString(labelNeg, font, textBrush,
                    (float)(_offsetX - i * GridSpacing - 10), (float)(_offsetY + 5));
            }
        }

        for (double i = 1; i <= (_height - _offsetY) / GridSpacing; i++)
        {
            if (i % 5 == 0)
            {
                string labelPos = (i / _magnificationMultiplier).ToString("0.###");
                string labelNeg = (-i / _magnificationMultiplier).ToString("0.###");

                g.DrawString(labelPos, font, textBrush,
                    (float)(_offsetX + 5), (float)(_offsetY - i * GridSpacing - 8));
                g.DrawString(labelNeg, font, textBrush,
                    (float)(_offsetX + 5), (float)(_offsetY + i * GridSpacing - 8));
            }
        }
    }

    private void DrawPoints(Graphics g)
    {
        float pointSize = (float)(6 * PointSizeMultiplier);

        foreach (PointData point in Points)
        {
            double screenX = _offsetX + point.X * GridSpacing * _magnificationMultiplier;
            double screenY = _offsetY - point.Y * GridSpacing * _magnificationMultiplier;

            if (screenX >= 0 && screenX <= _width && screenY >= 0 && screenY <= _height)
            {
                using (Brush pointBrush = new SolidBrush(point.Color))
                {
                    g.FillEllipse(pointBrush,
                                  (float)screenX - pointSize / 2,
                                  (float)screenY - pointSize / 2,
                                  pointSize,
                                  pointSize);
                }
            }
        }
    }

    public void Draw(Graphics g)
    {
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        Color axesColor = SystemColors.WindowText;

        if (RenderGridLines)
        {
            Pen gridPen = new Pen(Color.FromArgb(150, axesColor), 1);
            DrawGrid(g, gridPen);
        }

        if (RenderAxes)
        {
            Pen axesPen = new Pen(axesColor, 3);
            DrawAxes(g, axesPen);

            if (RenderAxisLabels)
            {
                DrawAxesLables(g, axesColor);
            }
        }

        if (Functions.Count > 0)
        {
            DrawFunctions(g);
        }

        if (Points.Count > 0)
        {
            DrawPoints(g);
        }
    }

    #endregion

    #region Utilities

    public void Resize(double newWidth, double newHeight)
    {
        this._width = newWidth;
        this._height = newHeight;
        _offsetX = newWidth / 2;
        _offsetY = newHeight / 2;
    }

    public void Move(double dx, double dy)
    {
        _offsetX += dx;
        _offsetY += dy;
    }

    public void AddFunction(string name, string expression)
    {
        Function function = new Function(name, expression, FunctionColor);
        Functions.Add(function);
        EnabledFunctions.Add(function);
    }

    public void AddPoint(double x, double y)
    {
        Points.Add(new PointData(x, y, PointColor));
    }

    public (double coordX, double coordY) ScreenToCoordinateSystem(double screenX, double screenY)
    {
        double coordX = (screenX - _offsetX) / GridSpacing / _magnificationMultiplier;
        double coordY = (_offsetY - screenY) / GridSpacing / _magnificationMultiplier;
        return (coordX, coordY);
    }

    public void ChangeColorOfAllPoints(Color desiredColor)
    {
        foreach (PointData point in Points)
        {
            point.Color = desiredColor;
        }
    }

    public (double coordX, double coordY) GetRandomVisiblePoint()
    {
        Random random = new Random();
        double screenX = random.NextDouble() * _width;
        double screenY = random.NextDouble() * _height;

        return ScreenToCoordinateSystem(screenX, screenY);
    }

    #endregion

}