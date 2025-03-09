namespace MainProgram;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        toggleButton = new Button();
        PropertiesPanel = new Panel();
        ChangeAllPointsColorButton = new Button();
        PointBrushColorIndicator = new Panel();
        PointBrushColorButton = new Button();
        PointSizeBar = new TrackBar();
        PointSizeLabel = new Label();
        GridSpacingBar = new TrackBar();
        GridSpacingLabel = new Label();
        RenderAxisLabelsBox = new CheckBox();
        RenderAxesBox = new CheckBox();
        RenderGridLinesBox = new CheckBox();
        propertiesLabel = new Label();
        AddPanel = new Panel();
        FunctionsList = new Panel();
        FunctionsLabel = new Label();
        AddNewFunctionButton = new Button();
        AddFunctionExpressionBox = new TextBox();
        AddFunctionColorIndicator = new Panel();
        AddFunctionColorSelector = new Button();
        AddFunctionNameBox = new TextBox();
        AddNewFunctionLabel = new Label();
        AddRandomPointsButton = new Button();
        AddRandomPointsBox = new TextBox();
        AddRandomPointsLabel = new Label();
        AddPointXBox = new TextBox();
        AddPointYBox = new TextBox();
        AddPointButton = new Button();
        AddPointLabel = new Label();
        AddButton = new Button();
        AddLabel = new Label();
        AddPointSignBox = new Label();
        AddFunctionSignLabel = new Label();
        TasksButton = new Button();
        PropertiesPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PointSizeBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)GridSpacingBar).BeginInit();
        AddPanel.SuspendLayout();
        SuspendLayout();
        // 
        // toggleButton
        // 
        toggleButton.FlatStyle = FlatStyle.Flat;
        toggleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
        toggleButton.Location = new Point(222, 29);
        toggleButton.Name = "toggleButton";
        toggleButton.Size = new Size(45, 45);
        toggleButton.TabIndex = 0;
        toggleButton.Text = "≡";
        toggleButton.UseVisualStyleBackColor = true;
        toggleButton.Click += toggleButton_Click;
        // 
        // PropertiesPanel
        // 
        PropertiesPanel.BorderStyle = BorderStyle.FixedSingle;
        PropertiesPanel.Controls.Add(ChangeAllPointsColorButton);
        PropertiesPanel.Controls.Add(PointBrushColorIndicator);
        PropertiesPanel.Controls.Add(PointBrushColorButton);
        PropertiesPanel.Controls.Add(PointSizeBar);
        PropertiesPanel.Controls.Add(PointSizeLabel);
        PropertiesPanel.Controls.Add(GridSpacingBar);
        PropertiesPanel.Controls.Add(GridSpacingLabel);
        PropertiesPanel.Controls.Add(RenderAxisLabelsBox);
        PropertiesPanel.Controls.Add(RenderAxesBox);
        PropertiesPanel.Controls.Add(toggleButton);
        PropertiesPanel.Controls.Add(RenderGridLinesBox);
        PropertiesPanel.Controls.Add(propertiesLabel);
        PropertiesPanel.Dock = DockStyle.Right;
        PropertiesPanel.Location = new Point(500, 0);
        PropertiesPanel.Name = "PropertiesPanel";
        PropertiesPanel.Size = new Size(300, 779);
        PropertiesPanel.TabIndex = 1;
        PropertiesPanel.Visible = false;
        // 
        // ChangeAllPointsColorButton
        // 
        ChangeAllPointsColorButton.Dock = DockStyle.Top;
        ChangeAllPointsColorButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
        ChangeAllPointsColorButton.ForeColor = SystemColors.WindowText;
        ChangeAllPointsColorButton.Location = new Point(0, 470);
        ChangeAllPointsColorButton.Name = "ChangeAllPointsColorButton";
        ChangeAllPointsColorButton.Size = new Size(298, 45);
        ChangeAllPointsColorButton.TabIndex = 12;
        ChangeAllPointsColorButton.Text = "Change Color Of All Points";
        ChangeAllPointsColorButton.UseVisualStyleBackColor = true;
        ChangeAllPointsColorButton.Click += ChangeAllPointsButton_Click;
        // 
        // PointBrushColorIndicator
        // 
        PointBrushColorIndicator.BackColor = Color.Blue;
        PointBrushColorIndicator.Location = new Point(246, 433);
        PointBrushColorIndicator.Name = "PointBrushColorIndicator";
        PointBrushColorIndicator.Size = new Size(45, 29);
        PointBrushColorIndicator.TabIndex = 11;
        PointBrushColorIndicator.Click += PointBrushColorButton_Click;
        // 
        // PointBrushColorButton
        // 
        PointBrushColorButton.Dock = DockStyle.Top;
        PointBrushColorButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
        PointBrushColorButton.ForeColor = SystemColors.WindowText;
        PointBrushColorButton.Location = new Point(0, 425);
        PointBrushColorButton.Name = "PointBrushColorButton";
        PointBrushColorButton.Size = new Size(298, 45);
        PointBrushColorButton.TabIndex = 10;
        PointBrushColorButton.Text = "Change Point Brush Color";
        PointBrushColorButton.TextAlign = ContentAlignment.MiddleLeft;
        PointBrushColorButton.UseVisualStyleBackColor = true;
        PointBrushColorButton.Click += PointBrushColorButton_Click;
        // 
        // PointSizeBar
        // 
        PointSizeBar.Dock = DockStyle.Top;
        PointSizeBar.Location = new Point(0, 356);
        PointSizeBar.Maximum = 100;
        PointSizeBar.Minimum = 1;
        PointSizeBar.Name = "PointSizeBar";
        PointSizeBar.Size = new Size(298, 69);
        PointSizeBar.TabIndex = 9;
        PointSizeBar.TickFrequency = 5;
        PointSizeBar.Value = 1;
        PointSizeBar.ValueChanged += PointSizeBar_ValueChanged;
        // 
        // PointSizeLabel
        // 
        PointSizeLabel.AutoSize = true;
        PointSizeLabel.Dock = DockStyle.Top;
        PointSizeLabel.FlatStyle = FlatStyle.Flat;
        PointSizeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        PointSizeLabel.ForeColor = SystemColors.WindowText;
        PointSizeLabel.Location = new Point(0, 324);
        PointSizeLabel.Name = "PointSizeLabel";
        PointSizeLabel.Padding = new Padding(30, 0, 0, 0);
        PointSizeLabel.Size = new Size(191, 32);
        PointSizeLabel.TabIndex = 8;
        PointSizeLabel.Text = "Point Size:  1x";
        // 
        // GridSpacingBar
        // 
        GridSpacingBar.BackColor = SystemColors.Control;
        GridSpacingBar.Dock = DockStyle.Top;
        GridSpacingBar.Location = new Point(0, 255);
        GridSpacingBar.Maximum = 110;
        GridSpacingBar.Minimum = 15;
        GridSpacingBar.Name = "GridSpacingBar";
        GridSpacingBar.Size = new Size(298, 69);
        GridSpacingBar.TabIndex = 7;
        GridSpacingBar.TickFrequency = 5;
        GridSpacingBar.Value = 30;
        GridSpacingBar.ValueChanged += GridSpacingBar_ValueChanged;
        // 
        // GridSpacingLabel
        // 
        GridSpacingLabel.AutoSize = true;
        GridSpacingLabel.Dock = DockStyle.Top;
        GridSpacingLabel.FlatStyle = FlatStyle.Flat;
        GridSpacingLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        GridSpacingLabel.ForeColor = SystemColors.WindowText;
        GridSpacingLabel.Location = new Point(0, 223);
        GridSpacingLabel.Name = "GridSpacingLabel";
        GridSpacingLabel.Padding = new Padding(30, 0, 0, 0);
        GridSpacingLabel.Size = new Size(288, 32);
        GridSpacingLabel.TabIndex = 6;
        GridSpacingLabel.Text = "Grid Spacing:  30  pixel";
        // 
        // RenderAxisLabelsBox
        // 
        RenderAxisLabelsBox.AutoSize = true;
        RenderAxisLabelsBox.Checked = true;
        RenderAxisLabelsBox.CheckState = CheckState.Checked;
        RenderAxisLabelsBox.Dock = DockStyle.Top;
        RenderAxisLabelsBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        RenderAxisLabelsBox.ForeColor = SystemColors.WindowText;
        RenderAxisLabelsBox.Location = new Point(0, 162);
        RenderAxisLabelsBox.Name = "RenderAxisLabelsBox";
        RenderAxisLabelsBox.Padding = new Padding(60, 0, 0, 25);
        RenderAxisLabelsBox.Size = new Size(298, 61);
        RenderAxisLabelsBox.TabIndex = 4;
        RenderAxisLabelsBox.Text = "Render Axis Labels";
        RenderAxisLabelsBox.UseVisualStyleBackColor = true;
        RenderAxisLabelsBox.CheckedChanged += RenderAxisLabelsBox_CheckedChanged;
        // 
        // RenderAxesBox
        // 
        RenderAxesBox.AutoSize = true;
        RenderAxesBox.Checked = true;
        RenderAxesBox.CheckState = CheckState.Checked;
        RenderAxesBox.Dock = DockStyle.Top;
        RenderAxesBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        RenderAxesBox.ForeColor = SystemColors.WindowText;
        RenderAxesBox.Location = new Point(0, 126);
        RenderAxesBox.Name = "RenderAxesBox";
        RenderAxesBox.Padding = new Padding(30, 0, 0, 0);
        RenderAxesBox.Size = new Size(298, 36);
        RenderAxesBox.TabIndex = 3;
        RenderAxesBox.Text = "Render Axes";
        RenderAxesBox.UseVisualStyleBackColor = true;
        RenderAxesBox.CheckedChanged += RenderAxesBox_CheckedChanged;
        // 
        // RenderGridLinesBox
        // 
        RenderGridLinesBox.AutoSize = true;
        RenderGridLinesBox.Checked = true;
        RenderGridLinesBox.CheckState = CheckState.Checked;
        RenderGridLinesBox.Dock = DockStyle.Top;
        RenderGridLinesBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        RenderGridLinesBox.ForeColor = SystemColors.WindowText;
        RenderGridLinesBox.Location = new Point(0, 75);
        RenderGridLinesBox.Name = "RenderGridLinesBox";
        RenderGridLinesBox.Padding = new Padding(30, 0, 0, 15);
        RenderGridLinesBox.Size = new Size(298, 51);
        RenderGridLinesBox.TabIndex = 2;
        RenderGridLinesBox.Text = "Render Grid Lines";
        RenderGridLinesBox.UseVisualStyleBackColor = true;
        RenderGridLinesBox.CheckedChanged += RenderGridLinesBox_CheckedChanged;
        // 
        // propertiesLabel
        // 
        propertiesLabel.AutoSize = true;
        propertiesLabel.Dock = DockStyle.Top;
        propertiesLabel.FlatStyle = FlatStyle.Flat;
        propertiesLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 238);
        propertiesLabel.Location = new Point(0, 0);
        propertiesLabel.Name = "propertiesLabel";
        propertiesLabel.Padding = new Padding(30, 0, 0, 30);
        propertiesLabel.Size = new Size(206, 75);
        propertiesLabel.TabIndex = 1;
        propertiesLabel.Text = "Properties";
        // 
        // AddPanel
        // 
        AddPanel.BorderStyle = BorderStyle.FixedSingle;
        AddPanel.Controls.Add(FunctionsList);
        AddPanel.Controls.Add(FunctionsLabel);
        AddPanel.Controls.Add(AddNewFunctionButton);
        AddPanel.Controls.Add(AddFunctionExpressionBox);
        AddPanel.Controls.Add(AddFunctionColorIndicator);
        AddPanel.Controls.Add(AddFunctionColorSelector);
        AddPanel.Controls.Add(AddFunctionNameBox);
        AddPanel.Controls.Add(AddNewFunctionLabel);
        AddPanel.Controls.Add(AddRandomPointsButton);
        AddPanel.Controls.Add(AddRandomPointsBox);
        AddPanel.Controls.Add(AddRandomPointsLabel);
        AddPanel.Controls.Add(AddPointXBox);
        AddPanel.Controls.Add(AddPointYBox);
        AddPanel.Controls.Add(AddPointButton);
        AddPanel.Controls.Add(AddPointLabel);
        AddPanel.Controls.Add(AddButton);
        AddPanel.Controls.Add(AddLabel);
        AddPanel.Controls.Add(AddPointSignBox);
        AddPanel.Controls.Add(AddFunctionSignLabel);
        AddPanel.Dock = DockStyle.Left;
        AddPanel.Location = new Point(0, 0);
        AddPanel.Name = "AddPanel";
        AddPanel.Size = new Size(300, 779);
        AddPanel.TabIndex = 2;
        AddPanel.Visible = false;
        // 
        // FunctionsList
        // 
        FunctionsList.AutoScroll = true;
        FunctionsList.AutoSize = true;
        FunctionsList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        FunctionsList.ForeColor = SystemColors.WindowText;
        FunctionsList.Location = new Point(19, 473);
        FunctionsList.Name = "FunctionsList";
        FunctionsList.Size = new Size(265, 59);
        FunctionsList.TabIndex = 33;
        // 
        // FunctionsLabel
        // 
        FunctionsLabel.AutoSize = true;
        FunctionsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        FunctionsLabel.ForeColor = SystemColors.WindowText;
        FunctionsLabel.Location = new Point(19, 438);
        FunctionsLabel.Name = "FunctionsLabel";
        FunctionsLabel.Size = new Size(122, 32);
        FunctionsLabel.TabIndex = 32;
        FunctionsLabel.Text = "Functions:";
        // 
        // AddNewFunctionButton
        // 
        AddNewFunctionButton.FlatStyle = FlatStyle.Flat;
        AddNewFunctionButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddNewFunctionButton.ForeColor = SystemColors.WindowText;
        AddNewFunctionButton.Location = new Point(245, 376);
        AddNewFunctionButton.Margin = new Padding(0);
        AddNewFunctionButton.Name = "AddNewFunctionButton";
        AddNewFunctionButton.Size = new Size(39, 39);
        AddNewFunctionButton.TabIndex = 30;
        AddNewFunctionButton.Text = "+";
        AddNewFunctionButton.UseVisualStyleBackColor = true;
        AddNewFunctionButton.Click += AddNewFunctionButton_Click;
        // 
        // AddFunctionExpressionBox
        // 
        AddFunctionExpressionBox.BorderStyle = BorderStyle.FixedSingle;
        AddFunctionExpressionBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddFunctionExpressionBox.Location = new Point(19, 376);
        AddFunctionExpressionBox.MaxLength = 50;
        AddFunctionExpressionBox.Name = "AddFunctionExpressionBox";
        AddFunctionExpressionBox.PlaceholderText = "Function Expression";
        AddFunctionExpressionBox.Size = new Size(226, 39);
        AddFunctionExpressionBox.TabIndex = 29;
        AddFunctionExpressionBox.TextAlign = HorizontalAlignment.Center;
        // 
        // AddFunctionColorIndicator
        // 
        AddFunctionColorIndicator.BackColor = Color.Orange;
        AddFunctionColorIndicator.Location = new Point(240, 335);
        AddFunctionColorIndicator.Name = "AddFunctionColorIndicator";
        AddFunctionColorIndicator.Size = new Size(37, 26);
        AddFunctionColorIndicator.TabIndex = 28;
        AddFunctionColorIndicator.Click += AddFunctionColorSelector_Click;
        // 
        // AddFunctionColorSelector
        // 
        AddFunctionColorSelector.FlatStyle = FlatStyle.Flat;
        AddFunctionColorSelector.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddFunctionColorSelector.ForeColor = SystemColors.WindowText;
        AddFunctionColorSelector.Location = new Point(127, 329);
        AddFunctionColorSelector.Name = "AddFunctionColorSelector";
        AddFunctionColorSelector.Size = new Size(157, 39);
        AddFunctionColorSelector.TabIndex = 27;
        AddFunctionColorSelector.Text = "Set Color";
        AddFunctionColorSelector.TextAlign = ContentAlignment.MiddleLeft;
        AddFunctionColorSelector.UseVisualStyleBackColor = true;
        AddFunctionColorSelector.Click += AddFunctionColorSelector_Click;
        // 
        // AddFunctionNameBox
        // 
        AddFunctionNameBox.BorderStyle = BorderStyle.FixedSingle;
        AddFunctionNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddFunctionNameBox.Location = new Point(19, 329);
        AddFunctionNameBox.MaxLength = 17;
        AddFunctionNameBox.Name = "AddFunctionNameBox";
        AddFunctionNameBox.PlaceholderText = "Name";
        AddFunctionNameBox.Size = new Size(76, 39);
        AddFunctionNameBox.TabIndex = 25;
        AddFunctionNameBox.TextAlign = HorizontalAlignment.Center;
        // 
        // AddNewFunctionLabel
        // 
        AddNewFunctionLabel.AutoSize = true;
        AddNewFunctionLabel.FlatStyle = FlatStyle.Flat;
        AddNewFunctionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddNewFunctionLabel.ForeColor = SystemColors.WindowText;
        AddNewFunctionLabel.Location = new Point(29, 292);
        AddNewFunctionLabel.Name = "AddNewFunctionLabel";
        AddNewFunctionLabel.Size = new Size(236, 32);
        AddNewFunctionLabel.TabIndex = 24;
        AddNewFunctionLabel.Text = "Add a New Function:";
        // 
        // AddRandomPointsButton
        // 
        AddRandomPointsButton.FlatStyle = FlatStyle.Flat;
        AddRandomPointsButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddRandomPointsButton.ForeColor = SystemColors.WindowText;
        AddRandomPointsButton.Location = new Point(245, 221);
        AddRandomPointsButton.Margin = new Padding(0);
        AddRandomPointsButton.Name = "AddRandomPointsButton";
        AddRandomPointsButton.Size = new Size(39, 39);
        AddRandomPointsButton.TabIndex = 23;
        AddRandomPointsButton.Text = "+";
        AddRandomPointsButton.UseVisualStyleBackColor = true;
        AddRandomPointsButton.Click += AddRandomPointsButton_Click;
        // 
        // AddRandomPointsBox
        // 
        AddRandomPointsBox.BorderStyle = BorderStyle.FixedSingle;
        AddRandomPointsBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddRandomPointsBox.Location = new Point(19, 221);
        AddRandomPointsBox.MaxLength = 17;
        AddRandomPointsBox.Name = "AddRandomPointsBox";
        AddRandomPointsBox.PlaceholderText = "Number of Points";
        AddRandomPointsBox.Size = new Size(226, 39);
        AddRandomPointsBox.TabIndex = 22;
        AddRandomPointsBox.TextAlign = HorizontalAlignment.Center;
        // 
        // AddRandomPointsLabel
        // 
        AddRandomPointsLabel.AutoSize = true;
        AddRandomPointsLabel.FlatStyle = FlatStyle.Flat;
        AddRandomPointsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddRandomPointsLabel.ForeColor = SystemColors.WindowText;
        AddRandomPointsLabel.Location = new Point(19, 183);
        AddRandomPointsLabel.Name = "AddRandomPointsLabel";
        AddRandomPointsLabel.Size = new Size(229, 32);
        AddRandomPointsLabel.TabIndex = 20;
        AddRandomPointsLabel.Text = "Add Random Points:";
        AddRandomPointsLabel.TextAlign = ContentAlignment.TopCenter;
        // 
        // AddPointXBox
        // 
        AddPointXBox.BorderStyle = BorderStyle.FixedSingle;
        AddPointXBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddPointXBox.Location = new Point(19, 123);
        AddPointXBox.MaxLength = 8;
        AddPointXBox.Name = "AddPointXBox";
        AddPointXBox.PlaceholderText = "x";
        AddPointXBox.Size = new Size(105, 39);
        AddPointXBox.TabIndex = 17;
        AddPointXBox.TextAlign = HorizontalAlignment.Center;
        // 
        // AddPointYBox
        // 
        AddPointYBox.BorderStyle = BorderStyle.FixedSingle;
        AddPointYBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddPointYBox.Location = new Point(140, 123);
        AddPointYBox.MaxLength = 8;
        AddPointYBox.Name = "AddPointYBox";
        AddPointYBox.PlaceholderText = "y";
        AddPointYBox.Size = new Size(105, 39);
        AddPointYBox.TabIndex = 18;
        AddPointYBox.TextAlign = HorizontalAlignment.Center;
        // 
        // AddPointButton
        // 
        AddPointButton.FlatStyle = FlatStyle.Flat;
        AddPointButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddPointButton.ForeColor = SystemColors.WindowText;
        AddPointButton.Location = new Point(245, 123);
        AddPointButton.Margin = new Padding(0);
        AddPointButton.Name = "AddPointButton";
        AddPointButton.Size = new Size(39, 39);
        AddPointButton.TabIndex = 16;
        AddPointButton.Text = "+";
        AddPointButton.UseVisualStyleBackColor = true;
        AddPointButton.Click += AddPointButton_Click;
        // 
        // AddPointLabel
        // 
        AddPointLabel.AutoSize = true;
        AddPointLabel.Dock = DockStyle.Top;
        AddPointLabel.FlatStyle = FlatStyle.Flat;
        AddPointLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddPointLabel.ForeColor = SystemColors.WindowText;
        AddPointLabel.Location = new Point(0, 75);
        AddPointLabel.Name = "AddPointLabel";
        AddPointLabel.Padding = new Padding(20, 0, 0, 0);
        AddPointLabel.Size = new Size(217, 32);
        AddPointLabel.TabIndex = 15;
        AddPointLabel.Text = "Add a New Point:";
        // 
        // AddButton
        // 
        AddButton.FlatStyle = FlatStyle.Flat;
        AddButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
        AddButton.Location = new Point(29, 11);
        AddButton.Name = "AddButton";
        AddButton.Size = new Size(45, 45);
        AddButton.TabIndex = 13;
        AddButton.Text = "+";
        AddButton.UseVisualStyleBackColor = true;
        AddButton.Click += AddButton_Click;
        // 
        // AddLabel
        // 
        AddLabel.AutoSize = true;
        AddLabel.Dock = DockStyle.Top;
        AddLabel.FlatStyle = FlatStyle.Flat;
        AddLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 238);
        AddLabel.Location = new Point(0, 0);
        AddLabel.Name = "AddLabel";
        AddLabel.Padding = new Padding(150, 0, 0, 30);
        AddLabel.Size = new Size(233, 75);
        AddLabel.TabIndex = 14;
        AddLabel.Text = "Add";
        // 
        // AddPointSignBox
        // 
        AddPointSignBox.AutoSize = true;
        AddPointSignBox.FlatStyle = FlatStyle.Flat;
        AddPointSignBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddPointSignBox.ForeColor = SystemColors.WindowText;
        AddPointSignBox.Location = new Point(121, 124);
        AddPointSignBox.Name = "AddPointSignBox";
        AddPointSignBox.Size = new Size(19, 32);
        AddPointSignBox.TabIndex = 19;
        AddPointSignBox.Text = ";";
        // 
        // AddFunctionSignLabel
        // 
        AddFunctionSignLabel.AutoSize = true;
        AddFunctionSignLabel.FlatStyle = FlatStyle.Flat;
        AddFunctionSignLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
        AddFunctionSignLabel.ForeColor = SystemColors.WindowText;
        AddFunctionSignLabel.Location = new Point(93, 331);
        AddFunctionSignLabel.Name = "AddFunctionSignLabel";
        AddFunctionSignLabel.Size = new Size(30, 32);
        AddFunctionSignLabel.TabIndex = 26;
        AddFunctionSignLabel.Text = "x;";
        // 
        // TasksButton
        // 
        TasksButton.Dock = DockStyle.Bottom;
        TasksButton.FlatStyle = FlatStyle.Flat;
        TasksButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
        TasksButton.Location = new Point(300, 730);
        TasksButton.Name = "TasksButton";
        TasksButton.Size = new Size(200, 49);
        TasksButton.TabIndex = 3;
        TasksButton.Text = "Tasks";
        TasksButton.UseVisualStyleBackColor = true;
        TasksButton.Click += TasksButton_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(800, 779);
        Controls.Add(TasksButton);
        Controls.Add(PropertiesPanel);
        Controls.Add(AddPanel);
        DoubleBuffered = true;
        KeyPreview = true;
        Name = "MainWindow";
        ShowIcon = false;
        Text = "ProjectNumerizis";
        WindowState = FormWindowState.Maximized;
        KeyDown += Form1_KeyDown;
        KeyUp += Form1_KeyUp;
        MouseClick += Form1_MouseClick;
        MouseDoubleClick += Form1_MouseDoubleClick;
        MouseDown += Form1_MouseDown;
        MouseMove += Form1_MouseMove;
        MouseUp += Form1_MouseUp;
        PropertiesPanel.ResumeLayout(false);
        PropertiesPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PointSizeBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)GridSpacingBar).EndInit();
        AddPanel.ResumeLayout(false);
        AddPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button toggleButton;
    private Panel PropertiesPanel;
    private Label propertiesLabel;
    private CheckBox RenderGridLinesBox;
    private CheckBox RenderAxisLabelsBox;
    private CheckBox RenderAxesBox;
    private Label GridSpacingLabel;
    private TrackBar GridSpacingBar;
    private Label PointSizeLabel;
    private TrackBar PointSizeBar;
    private Panel PointBrushColorIndicator;
    private Button PointBrushColorButton;
    private Button ChangeAllPointsColorButton;
    private Panel AddPanel;
    private Button AddButton;
    private Label AddLabel;
    private Label AddPointLabel;
    private Button AddPointButton;
    private TextBox AddPointXBox;
    private Label AddPointSignBox;
    private TextBox AddPointYBox;
    private Button AddRandomPointsButton;
    private TextBox AddRandomPointsBox;
    private Label AddRandomPointsLabel;
    private Label AddNewFunctionLabel;
    private Label AddFunctionSignLabel;
    private TextBox AddFunctionNameBox;
    private Button AddFunctionColorSelector;
    private Panel AddFunctionColorIndicator;
    private TextBox AddFunctionExpressionBox;
    private Button AddNewFunctionButton;
    private Label FunctionsLabel;
    private Panel FunctionsList;
    private Button TasksButton;
}