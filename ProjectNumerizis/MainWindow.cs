using LeviDraw;

namespace ProjectNumerizis;

public partial class MainWindow : Form
{

    private CoordinateSystem _coordinateSystem;
    private bool _isDragging;
    private Point _lastMousePosition;
    private float _moveSpeedMultiplier;
    private System.Windows.Forms.Timer _moveTimer;
    private HashSet<Keys> _pressedKeys;

    public MainWindow()
    {
        InitializeComponent();

        SetButtonStyle(RootsButton);
        SetButtonStyle(IntegralsButton);
        SetButtonStyle(DerivativesButton);
        SetButtonStyle(DetailedSolutionButton);

        _isDragging = false;
        _moveSpeedMultiplier = 5.0f;

    }

    private void SetButtonStyle(Button button)
    {
        button.FlatAppearance.BorderSize = 0;
        button.MouseEnter += Button_MouseEnter;
        button.MouseLeave += Button_MouseLeave;
    }

    private void Button_MouseEnter(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            Button button = (Button)sender;
            button.FlatAppearance.BorderSize = 1;
            button.BackColor = SystemColors.Highlight;
        }
    }

    private void Button_MouseLeave(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            Button button = (Button)sender;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = SystemColors.Control;
        }
    }

    private void RootsButton_Click(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void IntegralsButton_Click(object sender, EventArgs e)
    {

    }

    private void DerivativesButton_Click(object sender, EventArgs e)
    {

    }

    private void DetailedSolutionButton_Click(object sender, EventArgs e)
    {

    }
}