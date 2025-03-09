namespace ProjectNumerizis.MainProgram;

public partial class TasksWindow : Form
{
    private List<Button> _viewButtonsList;
    private List<Panel> _views;

    public TasksWindow()
    {
        InitializeComponent();

        _viewButtonsList = new List<Button>();
        _viewButtonsList.Add(NumDifViewButton);
        _viewButtonsList.Add(NumIntViewButton);
        _viewButtonsList.Add(NumRootViewButton);
        _views = new List<Panel>();
        _views.Add(NumDifTasksPanel);
        _views.Add(NumIntTasksPanel);
        _views.Add(NumRootTasksPanel);

        foreach (Button button in _viewButtonsList)
        {
            button.FlatAppearance.BorderSize = 0;
            button.Click += SelectView;
        }

        SelectView(_viewButtonsList[0], EventArgs.Empty);

        SetButtonStyle(DrawButton);
        SetButtonStyle(CalculateButton);
        SetButtonStyle(CancelButton);
        SetButtonStyle(CopySolutionButton);
    }

    private void SelectView(object? sender, EventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        Button buttonClicked = (Button)sender;

        for (int i = 0; i < _viewButtonsList.Count; i++)
        {
            if (_viewButtonsList[i] == buttonClicked)
            {
                _viewButtonsList[i].BackColor = SystemColors.Highlight;
                _views[i].Visible = true;
            }
            else
            {
                _viewButtonsList[i].BackColor = SystemColors.Control;
                _views[i].Visible = false;
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

    private void SetButtonStyle(Button button)
    {
        button.FlatAppearance.BorderSize = 1;
        button.MouseEnter += Button_MouseEnter;
        button.MouseLeave += Button_MouseLeave;
    }

    private void Button_MouseEnter1(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
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
        DialogResult = DialogResult.OK;
        this.Close();
    }

    private void CalculateButton_Click(object sender, EventArgs e)
    {

    }
}