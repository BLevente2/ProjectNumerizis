namespace LeviDraw;

public class CoordinateSystem
{
    private double width;
    private double height;
    private double offsetX;
    private double offsetY;
    private List<PointData> points;
    private List<Function> functions;
    private double magnificationMultiplier = 1.0;
    public List<Function> Functions => functions;
    public Color PointColor { get; set; }
    public Color FunctionColor { get; set; }
    public bool RenderGridLines { get; set; } = true;
    public bool RenderAxes { get; set; } = true;
    public bool RenderAxisLabels { get; set; } = true;
    public double GridSpacing { get; set; } = 30.0;
    public double PointSizeMultiplier { get; set; } = 1.0;

    private const double Threshold = 1000.0;

    public double MagnificationMultiplier
    {
        get { return magnificationMultiplier; }
        set
        {
            if (value <= 0) throw new ArgumentException("Magnification multiplier must be greater than zero.");

            double centerX = width / 2;
            double centerY = height / 2;

            offsetX = centerX - (centerX - offsetX) * (value / magnificationMultiplier);
            offsetY = centerY - (centerY - offsetY) * (value / magnificationMultiplier);

            magnificationMultiplier = value;
        }
    }

    public CoordinateSystem(double width, double height)
    {
        this.width = width;
        this.height = height;
        offsetX = width / 2;
        offsetY = height / 2;
        points = new List<PointData>();
        functions = new List<Function>();
        PointColor = Color.Blue;
        FunctionColor = Color.Orange;
    }

    public void Resize(double newWidth, double newHeight)
    {
        this.width = newWidth;
        this.height = newHeight;
        offsetX = newWidth / 2;
        offsetY = newHeight / 2;
    }

    public void Move(double dx, double dy)
    {
        offsetX += dx;
        offsetY += dy;
    }

    public void AddFunction(string name, string expression)
    {
        Function function = new Function(name, expression, FunctionColor);
        functions.Add(function);
    }

    public int NumberOfEnabledFunctions
    {
        get
        {
            int count = 0;
            foreach (var function in functions)
            {
                if (function.Enabled) count++;
            }
            return count;
        }
    }

    private void DrawFunctions(Graphics g)
    {
        double scaledGridSpacing = GridSpacing * magnificationMultiplier;

        if (NumberOfEnabledFunctions <= 3)
        {
            foreach (var function in functions)
            {
                if (function.Enabled)
                {
                    DrawSingleFunction(g, function, scaledGridSpacing);
                }
            }
        }
        else
        {
            var functionGroups = new List<List<Function>>();
            List<Function> currentGroup = new List<Function>();

            foreach (var function in functions)
            {
                if (function.Enabled)
                {
                    currentGroup.Add(function);

                    if (currentGroup.Count == 3)
                    {
                        functionGroups.Add(currentGroup);
                        currentGroup = new List<Function>();
                    }
                }
            }

            if (currentGroup.Count > 0)
            {
                functionGroups.Add(currentGroup);
            }

            object lockObject = new object();
            Parallel.ForEach(functionGroups, group =>
            {
                foreach (var function in group)
                {
                    lock (lockObject)
                    {
                        DrawSingleFunction(g, function, scaledGridSpacing);
                    }
                }
            });
        }
    }

    private void DrawSingleFunction(Graphics g, Function function, double scaledGridSpacing)
    {
        using (Pen functionPen = new Pen(function.FunctionColor, 2))
        {
            double prevScreenX = double.NaN;
            double prevScreenY = double.NaN;
            double prevCoordY = double.NaN;
            double prevSlope = double.NaN;

            double screenX = 0;
            while (screenX < width)
            {
                double coordX = (screenX - offsetX) / scaledGridSpacing;
                double coordY = function.Evaluate(coordX);

                double nextScreenX = screenX + GetAdaptiveStepSize(prevSlope);
                double nextCoordX = (nextScreenX - offsetX) / scaledGridSpacing;
                double nextCoordY = function.Evaluate(nextCoordX);

                double slope = (nextCoordY - coordY) / (nextCoordX - coordX);

                if (!double.IsNaN(prevSlope) && Math.Abs(slope - prevSlope) > CalculateSlopeThreshold())
                {
                    prevScreenX = double.NaN;
                }

                prevSlope = slope;

                if (double.IsInfinity(coordY) || double.IsNaN(coordY))
                {
                    prevScreenX = double.NaN;
                    screenX = nextScreenX;
                    continue;
                }

                prevCoordY = coordY;
                double screenY = offsetY - coordY * scaledGridSpacing;

                if (screenY >= 0 && screenY <= height)
                {
                    if (!double.IsNaN(prevScreenX) && !double.IsNaN(prevScreenY))
                    {
                        g.DrawLine(functionPen, (float)prevScreenX, (float)prevScreenY, (float)screenX, (float)screenY);
                    }

                    prevScreenX = screenX;
                    prevScreenY = screenY;
                }

                screenX = nextScreenX;
            }
        }
    }

    private double GetAdaptiveStepSize(double prevSlope)
    {
        if (double.IsNaN(prevSlope))
        {
            return GetDynamicStepSize();
        }

        double absSlope = Math.Abs(prevSlope);

        if (absSlope < 0.1)
        {
            return 5 * magnificationMultiplier;
        }
        else if (absSlope < 1)
        {
            return 2 * magnificationMultiplier;
        }
        else
        {
            return 0.5 * magnificationMultiplier;
        }
    }

    private double CalculateSlopeThreshold()
    {
        return Threshold / (magnificationMultiplier * GridSpacing);
    }

    private double GetDynamicStepSize()
    {
        return magnificationMultiplier < 0.5 ? 5 : 1;
    }

    public void Draw(Graphics g)
    {
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        Color axisColor = SystemColors.WindowText;
        Pen axisPen = new Pen(axisColor, 3);
        Pen gridPen = new Pen(Color.FromArgb(150, axisColor), 1);

        if (RenderGridLines)
        {
            for (double i = offsetX % GridSpacing; i < width; i += GridSpacing)
            {
                g.DrawLine(gridPen, (float)i, 0, (float)i, (float)height);
            }

            for (double i = offsetY % GridSpacing; i < height; i += GridSpacing)
            {
                g.DrawLine(gridPen, 0, (float)i, (float)width, (float)i);
            }
        }

        if (RenderAxes)
        {
            g.DrawLine(axisPen, (float)offsetX, 0, (float)offsetX, (float)height);
            g.DrawLine(axisPen, 0, (float)offsetY, (float)width, (float)offsetY);

            if (RenderAxisLabels)
            {
                Font font = new Font("Arial", 8);
                Brush textBrush = new SolidBrush(axisColor);

                for (double i = 1; i <= (width - offsetX) / GridSpacing; i++)
                {
                    if (i % 5 == 0)
                    {
                        string labelPos = (i / magnificationMultiplier).ToString("0.###");
                        string labelNeg = (-i / magnificationMultiplier).ToString("0.###");

                        g.DrawString(labelPos, font, textBrush,
                            (float)(offsetX + i * GridSpacing - 10), (float)(offsetY + 5));
                        g.DrawString(labelNeg, font, textBrush,
                            (float)(offsetX - i * GridSpacing - 10), (float)(offsetY + 5));
                    }
                }

                for (double i = 1; i <= (height - offsetY) / GridSpacing; i++)
                {
                    if (i % 5 == 0)
                    {
                        string labelPos = (i / magnificationMultiplier).ToString("0.###");
                        string labelNeg = (-i / magnificationMultiplier).ToString("0.###");

                        g.DrawString(labelPos, font, textBrush,
                            (float)(offsetX + 5), (float)(offsetY - i * GridSpacing - 8));
                        g.DrawString(labelNeg, font, textBrush,
                            (float)(offsetX + 5), (float)(offsetY + i * GridSpacing - 8));
                    }
                }
            }
        }

        DrawFunctions(g);

        foreach (var point in points)
        {
            double screenX = offsetX + point.X * GridSpacing * magnificationMultiplier;
            double screenY = offsetY - point.Y * GridSpacing * magnificationMultiplier;

            if (screenX >= 0 && screenX <= width && screenY >= 0 && screenY <= height)
            {
                float pointSize = (float)(6 * PointSizeMultiplier);

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

    public void AddPoint(double x, double y)
    {
        points.Add(new PointData(x, y, PointColor));
    }

    public (double coordX, double coordY) ScreenToCoordinateSystem(double screenX, double screenY)
    {
        double coordX = (screenX - offsetX) / GridSpacing / magnificationMultiplier;
        double coordY = (offsetY - screenY) / GridSpacing / magnificationMultiplier;
        return (coordX, coordY);
    }

    public void ChangeColorOfAllPoints(Color desiredColor)
    {
        foreach (PointData point in points)
        {
            point.Color = desiredColor;
        }
    }

    public (double coordX, double coordY) GetRandomVisiblePoint()
    {
        Random random = new Random();
        double screenX = random.NextDouble() * width;
        double screenY = random.NextDouble() * height;

        return ScreenToCoordinateSystem(screenX, screenY);
    }
}