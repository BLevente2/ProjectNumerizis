namespace LeviDraw;

/// <summary>
/// Represents a point in the coordinate system with X and Y coordinates and a color.
/// </summary>
public class PointData
{
    /// <summary>
    /// Gets or sets the X coordinate of the point.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate of the point.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the color of the point.
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PointData"/> class with the specified coordinates and color.
    /// </summary>
    /// <param name="x">The X coordinate of the point.</param>
    /// <param name="y">The Y coordinate of the point.</param>
    /// <param name="color">The color of the point.</param>
    public PointData(double x, double y, Color color)
    {
        X = x;
        Y = y;
        Color = color;
    }
}