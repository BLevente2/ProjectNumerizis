using LeviDraw;
using ProjectNumerizis.Tasks;
using ProjectNumerizis.Tasks.NumDifTasks;
using ProjectNumerizis.Tasks.NumRootTasks;
using System.Windows.Forms;

namespace ProjectNumerizis.MainProgram;

public partial class TasksWindow : Form
{
    private List<Panel> _views;
    private List<ListBox> _taskSelectors;
    private string _defSolutionBoxText;

    internal BasicTask? SelectedTask { get; private set; }

    public TasksWindow()
    {
        InitializeComponent();

        SelectedTask = null;

        _views = new List<Panel>();
        _views.Add(NumDifTasksPanel);
        _views.Add(NumIntTasksPanel);
        _views.Add(NumRootTasksPanel);

        _taskSelectors = new List<ListBox>();
        _taskSelectors.Add(NumDifTasks);
        _taskSelectors.Add(NumIntTasks);
        _taskSelectors.Add(NumRootTasks);


        SetButtonStyle(DrawButton);
        SetButtonStyle(CalculateButton);
        SetButtonStyle(CancelButton);
        SetButtonStyle(CopySolutionButton);

        ViewsList.DrawItem += ListBox_DrawItem;
        ViewsList.SelectedIndexChanged += ViewsList_SelectionChanged;
        ViewsList.SelectedIndex = 0;
        NumDifTasks.DrawItem += ListBox_DrawItem;
        NumDifTasks.SelectedIndexChanged += NumDifTasks_SelectionChanged;
        NumDifTasks.SelectedIndex = 0;
        NumDifTasks_SelectionChanged(null, EventArgs.Empty);
        _defSolutionBoxText = "You will se the solution of the task here!";
        SolutionBox.Text = _defSolutionBoxText;

        NumIntTasks.DrawItem += ListBox_DrawItem;
        NumIntTasks.SelectedIndexChanged += NumIntTasks_SelectionChanged;
        NumRootTasks.DrawItem += ListBox_DrawItem;
        NumRootTasks.SelectedIndexChanged += NumRootTasks_SelectionChanged;
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

    private void SetButtonStyle(Button button)
    {
        button.FlatAppearance.BorderSize = 1;
        button.MouseEnter += Button_MouseEnter;
        button.MouseLeave += Button_MouseLeave;
    }


    private void CopySolutionButton_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(SolutionBox.Text);
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void DrawButton_Click(object sender, EventArgs e)
    {
        CalculateButton_Click(sender, e);
        DialogResult = DialogResult.OK;
        this.Close();
    }

    private void CalculateButton_Click(object sender, EventArgs e)
    {
            try
            {
            switch (ViewsList.SelectedIndex)
            {
                case 0:
                    switch (NumDifTasks.SelectedIndex)
                    {
                        case 0:
                            Calcualte_ForwardDif();
                            break;
                        case 1:
                            Calculate_CentralDif();
                            break;
                        case 2:
                            Calculate_SecondDerivativeCentral();
                            break;
                        case 3:
                            Calculate_LagrangeFirstOrderDif();
                            break;
                            case 4:
                            Calculate_LagrangeDifSecondOrder();
                            break;
                        case 5:
                            Calculate_NewtonForwardDif();
                            break;
                            case 6:
                            Calculate_NewtonBackwardDif();
                            break;
                            case 7:
                            Calculate_newtonSecondDerivate();
                            break;
                    }
                    break;
                case 2:
                    switch (NumRootTasks.SelectedIndex)
                    {
                        case 0:
                            Calculate_BisectionMethod();
                            break;
                        case 1:
                            Calculate_FixPointIteration();
                            break;
                    }
                    break;
            }


                if (SelectedTask != null)
            {
                SelectedTask.Calculate();
                SolutionBox.Text = SelectedTask.TaskSolution.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

private void ListBox_DrawItem(object? sender, DrawItemEventArgs e)
    {
        if (sender == null || e == null || e.Font == null || e.Index < 0) return;

        ListBox listBox = (ListBox)sender;

        e.DrawBackground();

        var text = listBox.Items[e.Index].ToString();
        if (text == null) return; Font font = e.Font;
        Size textSize = TextRenderer.MeasureText(text, font);
        int x = e.Bounds.X + (e.Bounds.Width - textSize.Width) / 2;
        int y = e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2;


        using (Brush textBrush = new SolidBrush(e.ForeColor))
        {
            e.Graphics.DrawString(text, font, textBrush, x, y);
        }

        e.DrawFocusRectangle();
    }

    private void ViewsList_SelectionChanged(object? sender, EventArgs e)
    {
        try
        {
            ResetTaskArgs();
            int index = ViewsList.SelectedIndex;

            for (int i = 0; i < _views.Count; i++)
            {
                if (i == index)
                {
                    _views[i].Visible = true;
                    _taskSelectors[i].SelectedIndex = 0;
                }
                else
                {
                    _views[i].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    internal void ResetTaskArgs()
    {
        SelectedTask = null;
        SolutionBox.Text = _defSolutionBoxText;
        Arg1Box.Text = string.Empty;
        Arg2Box.Text = string.Empty;
        Arg3Box.Text = string.Empty;
        Arg4Box.Text = string.Empty;
        Arg5Box.Text = string.Empty;
        Arg6Box.Text = string.Empty;
        ArgsList.Text = string.Empty;
        Arg1Box.PlaceholderText = string.Empty;
        Arg2Box.PlaceholderText= string.Empty;
        Arg3Box.PlaceholderText= string.Empty;
        Arg4Box.PlaceholderText = string.Empty;
        Arg5Box.PlaceholderText = string.Empty;
        Arg6Box.PlaceholderText = string.Empty;
        Arg1Box.Visible = false;
        Arg2Box.Visible = false;
        Arg3Box.Visible = false;
        Arg4Box.Visible = false;
        Arg5Box.Visible = false;
        Arg6Box.Visible = false;
        ArgsList.Visible = false;
    }

    private void NumDifTasks_SelectionChanged(object? sender, EventArgs e)
    {
        ResetTaskArgs();

        int index = NumDifTasks.SelectedIndex;

        if ((index >= 0 && index <= 2) || (index >= 5 && index <= 7))
        {
            SetArgsVisibilityOfNormalNumDif();
        }
        else
        {
            Arg1Box.Visible = true;
            Arg1Box.PlaceholderText = "x of dif";
            ArgsList.Visible = true;
        }
    }

    private void SetArgsVisibilityOfNormalNumDif()
    {
        Arg1Box.Visible = true;
        Arg1Box.PlaceholderText = "fx";
        Arg2Box.Visible = true;
        Arg2Box.PlaceholderText = "x of dif";
        Arg3Box.Visible = true;
        Arg3Box.PlaceholderText = "h";
    }

    private void Calcualte_ForwardDif()
    {
        string fx = Arg1Box.Text;
        double x = double.Parse(Arg2Box.Text);
        double h = double.Parse(Arg3Box.Text);
        SelectedTask = new ForwardDifferenceTask(fx, x, h);
    }

    private void Calculate_CentralDif()
    {
        string fx = Arg1Box.Text;
        double x = double.Parse(Arg2Box.Text);
        double h = double.Parse(Arg3Box.Text);
        SelectedTask = new CentralDifferenceTask(fx, x, h);
    }

    private void Calculate_SecondDerivativeCentral()
    {
        string fx = Arg1Box.Text;
        double x = double.Parse(Arg2Box.Text);
        double h = double.Parse(Arg3Box.Text);
        SelectedTask = new SecondDerivativeCentralTask(fx, x, h);
    }

    private void Calculate_NewtonForwardDif()
    {
        string fx = Arg1Box.Text;
        double x = double.Parse(Arg2Box.Text);
        double h = double.Parse(Arg3Box.Text);
        SelectedTask = new NewtonForwardDifferenceTask(fx, x, h);
    }

    private void Calculate_NewtonBackwardDif()
    {
        string fx = Arg1Box.Text;
        double x = double.Parse(Arg2Box.Text);
        double h = double.Parse(Arg3Box.Text);
        SelectedTask = new NewtonBackwardDifferenceTask(fx, x, h);
    }

    private void Calculate_newtonSecondDerivate()
    {
        string fx = Arg1Box.Text;
        double x = double.Parse(Arg2Box.Text);
        double h = double.Parse(Arg3Box.Text);
        SelectedTask = new NewtonSecondDerivativeTask(fx, x, h); 
    }

    private void Calculate_LagrangeFirstOrderDif()
    {
        double x = double.Parse(Arg1Box.Text);
        List<PointData> interpolationPoints = GetLagrangeDifInterpolationPoints();
        SelectedTask = new LagrangeFirstOrderTask(x, interpolationPoints);
    }

    private void Calculate_LagrangeDifSecondOrder()
    {
        double x = double.Parse(Arg1Box.Text);
        List<PointData> interpolationPoints = GetLagrangeDifInterpolationPoints();
        SelectedTask = new LagrangeSecondOrderTask(x, interpolationPoints);
    }

    private List<PointData> GetLagrangeDifInterpolationPoints()
    {
        string[] lines = ArgsList.Lines;

        if (lines.Length < 2)
        {
            throw new FormatException("You must give at least 2 interpolation points!");
        }

        List<PointData> interpolationPoints = new List<PointData>();
        char splitChar = ' ';

        foreach (string line in lines)
        {
            string[] nums = line.Split(splitChar);
            if (nums.Length != 2)
            {
                throw new FormatException("Interpolation points must contain a valid pont in each line! Numbers must be separated by spaces!");
            }
            double xCord = double.Parse(nums[0]);
            double yCord = double.Parse(nums[1]);
            PointData point = new PointData(xCord, yCord, Color.Green);
            interpolationPoints.Add(point);
        }
        return interpolationPoints;
    }

    private void NumIntTasks_SelectionChanged(object? sender, EventArgs e)
    {

    }

    private void NumRootTasks_SelectionChanged(object? sender, EventArgs e)
    {
        ResetTaskArgs();
        switch (NumRootTasks.SelectedIndex)
        {
            case 0:
                Arg1Box.Visible = true;
                Arg2Box.Visible = true;
                Arg3Box.Visible = true;
                Arg4Box.Visible = true;
                Arg1Box.PlaceholderText = "fx";
                Arg2Box.PlaceholderText = "a";
                Arg3Box.PlaceholderText = "b";
                Arg4Box.PlaceholderText = "epsilon";
                break;

            case 1:
                Arg1Box.Visible = true;
                Arg2Box.Visible = true;
                Arg3Box.Visible = true;
                Arg4Box.Visible = true;
                Arg1Box.PlaceholderText = "fx";
                Arg2Box.PlaceholderText = "x0";
                Arg3Box.PlaceholderText = "epsilon";
                Arg4Box.PlaceholderText = "maxIter";
                break;
        }
    }

    private void Calculate_BisectionMethod()
    {
        string fx = Arg1Box.Text;
        double a = double.Parse(Arg2Box.Text);
        double b = double.Parse(Arg3Box.Text);
        double epsilon = double.Parse(Arg4Box.Text);
        SelectedTask = new BisectionMethodTask(fx, a, b, epsilon);
    }

    private void Calculate_FixPointIteration()
    {
        string fx = Arg1Box.Text;
        double x0 = double.Parse(Arg2Box.Text);
        double epsilon = double.Parse (Arg3Box.Text);
        int maxIter = int.Parse(Arg4Box.Text);
        SelectedTask = new FixPointIterationTask(fx, x0, epsilon, maxIter);
    }


}