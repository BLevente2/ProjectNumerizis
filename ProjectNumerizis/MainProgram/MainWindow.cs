using LeviDraw;
using ProjectNumerizis.MainProgram;

namespace MainProgram;

public partial class MainWindow : Form
{

    #region PropertiesAndConstructors

    private CoordinateSystem _coordinateSystem;
    private bool _isDragging;
    private Point _lastMousePosition;
    private List<CheckBox> _functionsList;
    private System.Windows.Forms.Timer _moveTimer;
    private HashSet<Keys> _pressedKeys;
    private float _moveSpeedMultiplier;
    private TasksWindow _tasksWindow;

    public MainWindow(double FPS)
    {
        InitializeComponent();

        _coordinateSystem = new CoordinateSystem(this.ClientSize.Width, this.ClientSize.Height);
        _isDragging = false;
        _moveSpeedMultiplier = 5.0f;
        _moveTimer = new System.Windows.Forms.Timer();
        _moveTimer.Interval = (int)Math.Round(1000.0 / FPS);
        _moveTimer.Tick += MoveTimer_Tick;
        _pressedKeys = new HashSet<Keys>();

        this.Paint += new PaintEventHandler(DrawCoordinateSystem);
        this.Resize += new EventHandler(Form1_Resize);

        toggleButton.Location = new Point(this.ClientSize.Width - toggleButton.Width - 10, 10);
        toggleButton.FlatAppearance.BorderColor = SystemColors.ControlText;
        toggleButton.FlatAppearance.BorderSize = 1;
        this.Controls.Add(toggleButton);

        AddButton.Location = new Point(10, 10);
        AddButton.FlatAppearance.BorderColor = SystemColors.ControlText;
        AddButton.FlatAppearance.BorderSize = 1;
        this.Controls.Add(AddButton);

        TasksButton.FlatAppearance.BorderSize = 1;
        TasksButton.FlatAppearance.BorderColor = SystemColors.ControlText;

        this.MouseWheel += new MouseEventHandler(Form1_MouseWheel!);

        _functionsList = new List<CheckBox>();
        FunctionsList.AutoSizeMode = AutoSizeMode.GrowOnly;

        toggleButton.MouseEnter += Button_MouseEnter;
        toggleButton.MouseLeave += Button_MouseLeave;
        AddButton.MouseEnter += Button_MouseEnter;
        AddButton.MouseLeave += Button_MouseLeave;
        AddPointButton.MouseEnter += Button_MouseEnter;
        AddPointButton.MouseLeave += Button_MouseLeave;
        AddRandomPointsButton.MouseEnter += Button_MouseEnter;
        AddRandomPointsButton.MouseLeave += Button_MouseLeave;
        AddNewFunctionButton.MouseEnter += Button_MouseEnter;
        AddNewFunctionButton.MouseLeave += Button_MouseLeave;
        TasksButton.MouseEnter += Button_MouseEnter;
        TasksButton.MouseLeave += Button_MouseLeave;

        _tasksWindow = new TasksWindow();
    }

    #endregion

    private void DrawCoordinateSystem(object? sender, PaintEventArgs e)
    {
        _coordinateSystem.Draw(e.Graphics);
    }

    private void Form1_Resize(object? sender, EventArgs e)
    {
        _coordinateSystem.Resize(this.ClientSize.Width, this.ClientSize.Height);
        toggleButton.Location = new Point(this.ClientSize.Width - toggleButton.Width - 10, 10);
        this.Invalidate();
    }

    private void MoveTimer_Tick(object? sender, EventArgs e)
    {
        MoveCoordinateSystem();
    }

    private void MoveCoordinateSystem()
    {
        double dx = 0, dy = 0;
        double magnification = _coordinateSystem.MagnificationMultiplier;

        if (_pressedKeys.Contains(Keys.A)) dx -= 1 * _moveSpeedMultiplier;
        if (_pressedKeys.Contains(Keys.D)) dx += 1 * _moveSpeedMultiplier;
        if (_pressedKeys.Contains(Keys.W)) dy -= 1 * _moveSpeedMultiplier;
        if (_pressedKeys.Contains(Keys.S)) dy += 1 * _moveSpeedMultiplier;
        if (_pressedKeys.Contains(Keys.Add)) magnification *= 1.004;
        if (_pressedKeys.Contains(Keys.Subtract)) magnification *= 0.996;
        if (_pressedKeys.Contains(Keys.E) && GridSpacingBar.Value < 110) GridSpacingBar.Value++;
        if (_pressedKeys.Contains(Keys.Q) && GridSpacingBar.Value > 15) GridSpacingBar.Value--;

        _coordinateSystem.MagnificationMultiplier = Math.Max(0.001, Math.Min(100, magnification));
        _coordinateSystem.Move(dx, dy);
        this.Invalidate();
    }

    private void SetToDefault()
    {
        _coordinateSystem.MagnificationMultiplier = 1;
        PointSizeBar.Value = 1;
        _coordinateSystem.Resize(this.ClientSize.Width, this.ClientSize.Height);
        GridSpacingBar.Value = 30;
        this.Invalidate();
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Home)
        {
            SetToDefault();
            return;
        }

        if (!_pressedKeys.Contains(e.KeyCode))
        {
            _pressedKeys.Add(e.KeyCode);
        }
        _moveTimer.Start();
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if (_pressedKeys.Contains(e.KeyCode))
        {
            _pressedKeys.Remove(e.KeyCode);
        }
        if (_pressedKeys.Count == 0)
        {
            _moveTimer.Stop();
        }
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _isDragging = true;
            _lastMousePosition = e.Location;
        }
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_isDragging)
        {
            double dx = e.X - _lastMousePosition.X;
            double dy = e.Y - _lastMousePosition.Y;
            _coordinateSystem.Move(dx, dy);
            _lastMousePosition = e.Location;
            this.Invalidate(); // Újrarajzolás
        }
    }

    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _isDragging = false;
        }
    }

    private void toggleButton_Click(object sender, EventArgs e)
    {
        PropertiesPanel.Visible = !PropertiesPanel.Visible;
        this.KeyPreview = !PropertiesPanel.Visible;
        toggleButton.BringToFront();
        AddPanel.Visible = false;
    }

    private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var coordinates = _coordinateSystem.ScreenToCoordinateSystem(e.X, e.Y);
        _coordinateSystem.AddPoint(coordinates.coordX, coordinates.coordY);
        this.Invalidate();
    }

    private void RenderGridLinesBox_CheckedChanged(object sender, EventArgs e)
    {
        _coordinateSystem.RenderGridLines = !_coordinateSystem.RenderGridLines;
        this.Invalidate();
    }

    private void RenderAxisLabelsBox_CheckedChanged(object sender, EventArgs e)
    {
        _coordinateSystem.RenderAxisLabels = !_coordinateSystem.RenderAxisLabels;
        this.Invalidate();
    }

    private void RenderAxesBox_CheckedChanged(object sender, EventArgs e)
    {
        _coordinateSystem.RenderAxes = !_coordinateSystem.RenderAxes;
        RenderAxisLabelsBox.Enabled = !RenderAxisLabelsBox.Enabled;
        Invalidate();
    }

    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        PropertiesPanel.Visible = false;
        AddPanel.Visible = false;
        this.KeyPreview = true;
    }

    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta > 0)
        {
            _coordinateSystem.MagnificationMultiplier = Math.Min(100, _coordinateSystem.MagnificationMultiplier * 1.1);
        }
        else
        {
            _coordinateSystem.MagnificationMultiplier = Math.Max(0.001, _coordinateSystem.MagnificationMultiplier * 0.9);
        }
        this.Invalidate();
    }

    private void GridSpacingBar_ValueChanged(object sender, EventArgs e)
    {
        _coordinateSystem.GridSpacing = GridSpacingBar.Value;
        GridSpacingLabel.Text = $"Grid Spacing:  {GridSpacingBar.Value}  pixel";
        this.Invalidate();
    }

    private void PointSizeBar_ValueChanged(object sender, EventArgs e)
    {
        _coordinateSystem.PointSizeMultiplier = PointSizeBar.Value / 10.0;
        PointSizeLabel.Text = $"Point Size:  {PointSizeBar.Value}x";
        this.Invalidate();
    }

    private void PointBrushColorButton_Click(object sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _coordinateSystem.PointColor = colorDialog.Color;
                PointBrushColorIndicator.BackColor = colorDialog.Color;
            }
        }
    }

    private void ChangeAllPointsButton_Click(object sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _coordinateSystem.ChangeColorOfAllPoints(colorDialog.Color);
                _coordinateSystem.PointColor = colorDialog.Color;
                PointBrushColorIndicator.BackColor = colorDialog.Color;
                this.Invalidate();
            }
        }
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        AddPanel.Visible = !AddPanel.Visible;
        this.KeyPreview = !AddPanel.Visible;
        AddButton.BringToFront();
        PropertiesPanel.Visible = false;

    }

    private void AddPointButton_Click(object sender, EventArgs e)
    {
        double x = 0;
        double y = 0;
        try
        {
            x = double.Parse(AddPointXBox.Text);
            y = double.Parse(AddPointYBox.Text);
            _coordinateSystem.AddPoint(x, y);
            this.Invalidate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            AddPointXBox.Text = "";
            AddPointYBox.Text = "";
        }
    }

    private void AddRandomPointsButton_Click(object sender, EventArgs e)
    {
        try
        {
            int numberOfPoints = int.Parse(AddRandomPointsBox.Text);
            for (int i = 0; i < numberOfPoints; i++)
            {
                var coordinates = _coordinateSystem.GetRandomVisiblePoint();
                _coordinateSystem.AddPoint(coordinates.coordX, coordinates.coordY);
            }
            this.Invalidate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            AddRandomPointsBox.Text = "";
        }
    }

    private void AddFunctionColorSelector_Click(object sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _coordinateSystem.FunctionColor = colorDialog.Color;
                AddFunctionColorIndicator.BackColor = colorDialog.Color;
            }
        }
    }

    private void AddNewFunctionButton_Click(object sender, EventArgs e)
    {
        try
        {
            _coordinateSystem.AddFunction(AddFunctionNameBox.Text, AddFunctionExpressionBox.Text);
            CheckBox box = new CheckBox();
            box.Text = AddFunctionNameBox.Text + "x = " + AddFunctionExpressionBox.Text;
            box.ForeColor = _coordinateSystem.FunctionColor;
            AddFunctionToList(box);
            this.Invalidate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            AddFunctionNameBox.Text = "";
            AddFunctionExpressionBox.Text = "";
        }
    }

    private void AddFunctionToList(CheckBox box)
    {
        box.Checked = true;
        box.Font = FunctionsList.Font;
        int index = _functionsList.Count;
        if (index != 0) index *= _functionsList[index - 1].Height;
        box.Location = new Point(10, index);
        box.AutoSize = true;
        box.CheckedChanged += new EventHandler(Functions_CheckedChanged);
        box.MouseUp += CheckBox_MouseUp;
        _functionsList.Add(box);
        FunctionsList.Controls.Add(box);
    }

    private void Functions_CheckedChanged(object? sender, EventArgs e)
    {
        for (int i = 0; i < _functionsList.Count; i++)
        {
            _coordinateSystem.Functions[i].Enabled = _functionsList[i].Checked;
        }
        _coordinateSystem.EnabledFunctions = _coordinateSystem.Functions.Where(x => x.Enabled).ToList();
        this.Invalidate();
    }

    private void CheckBox_MouseUp(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && sender != null)
        {
            var result = MessageBox.Show("Do you want to delete this function?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CheckBox box = (CheckBox)sender;
                int index = _functionsList.IndexOf(box);
                Function func = _coordinateSystem.Functions[index];
                if (box.Checked)
                {
                    _coordinateSystem.EnabledFunctions.Remove(func);
                }
                _coordinateSystem.Functions.Remove(func);
                func.Dispose();
                _functionsList.Remove(box);
                FunctionsList.Controls.Remove(box);
                this.Invalidate();
            }
        }
    }

    private void Button_MouseEnter(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            Button button = (Button)sender;
            button.BackColor = SystemColors.Highlight;
        }
    }

    private void Button_MouseLeave(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            Button button = (Button)sender;
            button.BackColor = SystemColors.Control;
        }
    }

    private void TasksButton_Click(object sender, EventArgs e)
    {
        var result = _tasksWindow.ShowDialog();
        
        if (result == DialogResult.OK)
        {

        }
    }
}