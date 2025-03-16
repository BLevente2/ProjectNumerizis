using ProjectNumerizis.Tasks;
using ProjectNumerizis.Tasks.NumDifTasks;
using System.Windows.Forms;

namespace ProjectNumerizis.MainProgram;

public partial class TasksWindow : Form
{
    private List<Panel> _views;
    private List<ListBox> _taskSelectors;

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
        switch (NumDifTasks.SelectedIndex)
        {
            case 0:
                Arg1Box.Visible = true;
                Arg1Box.PlaceholderText = "fx";
                Arg2Box.Visible = true;
                Arg2Box.PlaceholderText = "x of dif";
                Arg3Box.Visible = true;
                Arg3Box.PlaceholderText = "h";
                break;
                case 1:
                Arg1Box.Visible = true;
                Arg1Box.PlaceholderText = "fx";
                Arg2Box.Visible = true;
                Arg2Box.PlaceholderText = "x of dif";
                Arg3Box.Visible = true;
                Arg3Box.PlaceholderText = "h";
                break;
        }
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

}