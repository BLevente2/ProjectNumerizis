namespace ProjectNumerizis.MainProgram
{
    partial class TasksWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ViewsPanel = new Panel();
            ViewsList = new ListBox();
            NumDifTasksPanel = new Panel();
            NumDifTasks = new ListBox();
            NumIntTasksPanel = new Panel();
            NumIntTasks = new ListBox();
            NumRootTasksPanel = new Panel();
            NumRootTasks = new ListBox();
            TaskArgumentsPanel = new Panel();
            ArgsList = new RichTextBox();
            Arg6Box = new TextBox();
            Arg5Box = new TextBox();
            Arg4Box = new TextBox();
            Arg3Box = new TextBox();
            Arg2Box = new TextBox();
            Arg1Box = new TextBox();
            TaskArgumentsLabel = new Label();
            ControlPanel = new Panel();
            CancelButton = new Button();
            CalculateButton = new Button();
            DrawButton = new Button();
            SolutionPanel = new Panel();
            SolutionBox = new RichTextBox();
            SolutionHeaderPanel = new Panel();
            CopySolutionButton = new Button();
            SolutionLabel = new Label();
            ViewsPanel.SuspendLayout();
            NumDifTasksPanel.SuspendLayout();
            NumIntTasksPanel.SuspendLayout();
            NumRootTasksPanel.SuspendLayout();
            TaskArgumentsPanel.SuspendLayout();
            ControlPanel.SuspendLayout();
            SolutionPanel.SuspendLayout();
            SolutionHeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ViewsPanel
            // 
            ViewsPanel.BorderStyle = BorderStyle.FixedSingle;
            ViewsPanel.Controls.Add(ViewsList);
            ViewsPanel.Dock = DockStyle.Left;
            ViewsPanel.Location = new Point(0, 0);
            ViewsPanel.Name = "ViewsPanel";
            ViewsPanel.Size = new Size(213, 510);
            ViewsPanel.TabIndex = 0;
            // 
            // ViewsList
            // 
            ViewsList.BorderStyle = BorderStyle.None;
            ViewsList.DisplayMember = "0";
            ViewsList.Dock = DockStyle.Fill;
            ViewsList.DrawMode = DrawMode.OwnerDrawFixed;
            ViewsList.Font = new Font("Nirmala UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ViewsList.FormattingEnabled = true;
            ViewsList.ItemHeight = 150;
            ViewsList.Items.AddRange(new object[] { "Num Dif", "Num Int", "Num Root" });
            ViewsList.Location = new Point(0, 0);
            ViewsList.MaximumSize = new Size(400, 700);
            ViewsList.Name = "ViewsList";
            ViewsList.Size = new Size(211, 508);
            ViewsList.TabIndex = 0;
            // 
            // NumDifTasksPanel
            // 
            NumDifTasksPanel.BorderStyle = BorderStyle.FixedSingle;
            NumDifTasksPanel.Controls.Add(NumDifTasks);
            NumDifTasksPanel.Dock = DockStyle.Left;
            NumDifTasksPanel.Location = new Point(213, 0);
            NumDifTasksPanel.Name = "NumDifTasksPanel";
            NumDifTasksPanel.Size = new Size(213, 510);
            NumDifTasksPanel.TabIndex = 2;
            // 
            // NumDifTasks
            // 
            NumDifTasks.BorderStyle = BorderStyle.None;
            NumDifTasks.DisplayMember = "0";
            NumDifTasks.Dock = DockStyle.Fill;
            NumDifTasks.DrawMode = DrawMode.OwnerDrawFixed;
            NumDifTasks.Font = new Font("Nirmala UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumDifTasks.FormattingEnabled = true;
            NumDifTasks.ItemHeight = 60;
            NumDifTasks.Items.AddRange(new object[] { "Forward dif", "Central dif", "Central 2.dif", "Lagrange 1o.", "Lagrange 2o.", "Newton forw.", "Newton backw.", "Newton 2.dif" });
            NumDifTasks.Location = new Point(0, 0);
            NumDifTasks.MaximumSize = new Size(400, 700);
            NumDifTasks.Name = "NumDifTasks";
            NumDifTasks.Size = new Size(211, 508);
            NumDifTasks.TabIndex = 1;
            // 
            // NumIntTasksPanel
            // 
            NumIntTasksPanel.BorderStyle = BorderStyle.FixedSingle;
            NumIntTasksPanel.Controls.Add(NumIntTasks);
            NumIntTasksPanel.Dock = DockStyle.Left;
            NumIntTasksPanel.Location = new Point(426, 0);
            NumIntTasksPanel.Name = "NumIntTasksPanel";
            NumIntTasksPanel.Size = new Size(213, 510);
            NumIntTasksPanel.TabIndex = 3;
            // 
            // NumIntTasks
            // 
            NumIntTasks.BorderStyle = BorderStyle.None;
            NumIntTasks.DisplayMember = "0";
            NumIntTasks.Dock = DockStyle.Fill;
            NumIntTasks.DrawMode = DrawMode.OwnerDrawFixed;
            NumIntTasks.Font = new Font("Nirmala UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumIntTasks.FormattingEnabled = true;
            NumIntTasks.ItemHeight = 55;
            NumIntTasks.Items.AddRange(new object[] { "Task1" });
            NumIntTasks.Location = new Point(0, 0);
            NumIntTasks.MaximumSize = new Size(400, 700);
            NumIntTasks.Name = "NumIntTasks";
            NumIntTasks.Size = new Size(211, 508);
            NumIntTasks.TabIndex = 2;
            // 
            // NumRootTasksPanel
            // 
            NumRootTasksPanel.BorderStyle = BorderStyle.FixedSingle;
            NumRootTasksPanel.Controls.Add(NumRootTasks);
            NumRootTasksPanel.Dock = DockStyle.Left;
            NumRootTasksPanel.Location = new Point(639, 0);
            NumRootTasksPanel.Name = "NumRootTasksPanel";
            NumRootTasksPanel.Size = new Size(213, 510);
            NumRootTasksPanel.TabIndex = 4;
            // 
            // NumRootTasks
            // 
            NumRootTasks.BorderStyle = BorderStyle.None;
            NumRootTasks.DisplayMember = "0";
            NumRootTasks.Dock = DockStyle.Fill;
            NumRootTasks.DrawMode = DrawMode.OwnerDrawFixed;
            NumRootTasks.Font = new Font("Nirmala UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumRootTasks.FormattingEnabled = true;
            NumRootTasks.ItemHeight = 55;
            NumRootTasks.Items.AddRange(new object[] { "BisectionMethod", "FixPointIteration" });
            NumRootTasks.Location = new Point(0, 0);
            NumRootTasks.MaximumSize = new Size(400, 700);
            NumRootTasks.Name = "NumRootTasks";
            NumRootTasks.Size = new Size(211, 508);
            NumRootTasks.TabIndex = 2;
            // 
            // TaskArgumentsPanel
            // 
            TaskArgumentsPanel.BorderStyle = BorderStyle.FixedSingle;
            TaskArgumentsPanel.Controls.Add(ArgsList);
            TaskArgumentsPanel.Controls.Add(Arg6Box);
            TaskArgumentsPanel.Controls.Add(Arg5Box);
            TaskArgumentsPanel.Controls.Add(Arg4Box);
            TaskArgumentsPanel.Controls.Add(Arg3Box);
            TaskArgumentsPanel.Controls.Add(Arg2Box);
            TaskArgumentsPanel.Controls.Add(Arg1Box);
            TaskArgumentsPanel.Controls.Add(TaskArgumentsLabel);
            TaskArgumentsPanel.Dock = DockStyle.Left;
            TaskArgumentsPanel.Location = new Point(852, 0);
            TaskArgumentsPanel.Name = "TaskArgumentsPanel";
            TaskArgumentsPanel.Size = new Size(275, 510);
            TaskArgumentsPanel.TabIndex = 5;
            // 
            // ArgsList
            // 
            ArgsList.Dock = DockStyle.Fill;
            ArgsList.Location = new Point(0, 285);
            ArgsList.Name = "ArgsList";
            ArgsList.Size = new Size(273, 223);
            ArgsList.TabIndex = 7;
            ArgsList.Text = "";
            // 
            // Arg6Box
            // 
            Arg6Box.Dock = DockStyle.Top;
            Arg6Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Arg6Box.Location = new Point(0, 246);
            Arg6Box.Name = "Arg6Box";
            Arg6Box.Size = new Size(273, 39);
            Arg6Box.TabIndex = 6;
            Arg6Box.TextAlign = HorizontalAlignment.Center;
            // 
            // Arg5Box
            // 
            Arg5Box.Dock = DockStyle.Top;
            Arg5Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Arg5Box.Location = new Point(0, 207);
            Arg5Box.Name = "Arg5Box";
            Arg5Box.Size = new Size(273, 39);
            Arg5Box.TabIndex = 5;
            Arg5Box.TextAlign = HorizontalAlignment.Center;
            // 
            // Arg4Box
            // 
            Arg4Box.Dock = DockStyle.Top;
            Arg4Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Arg4Box.Location = new Point(0, 168);
            Arg4Box.Name = "Arg4Box";
            Arg4Box.Size = new Size(273, 39);
            Arg4Box.TabIndex = 4;
            Arg4Box.TextAlign = HorizontalAlignment.Center;
            // 
            // Arg3Box
            // 
            Arg3Box.Dock = DockStyle.Top;
            Arg3Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Arg3Box.Location = new Point(0, 129);
            Arg3Box.Name = "Arg3Box";
            Arg3Box.Size = new Size(273, 39);
            Arg3Box.TabIndex = 3;
            Arg3Box.TextAlign = HorizontalAlignment.Center;
            // 
            // Arg2Box
            // 
            Arg2Box.Dock = DockStyle.Top;
            Arg2Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Arg2Box.Location = new Point(0, 90);
            Arg2Box.Name = "Arg2Box";
            Arg2Box.Size = new Size(273, 39);
            Arg2Box.TabIndex = 2;
            Arg2Box.TextAlign = HorizontalAlignment.Center;
            // 
            // Arg1Box
            // 
            Arg1Box.Dock = DockStyle.Top;
            Arg1Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Arg1Box.Location = new Point(0, 51);
            Arg1Box.Name = "Arg1Box";
            Arg1Box.Size = new Size(273, 39);
            Arg1Box.TabIndex = 1;
            Arg1Box.TextAlign = HorizontalAlignment.Center;
            // 
            // TaskArgumentsLabel
            // 
            TaskArgumentsLabel.AutoSize = true;
            TaskArgumentsLabel.Dock = DockStyle.Top;
            TaskArgumentsLabel.Font = new Font("Nirmala UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TaskArgumentsLabel.Location = new Point(0, 0);
            TaskArgumentsLabel.Name = "TaskArgumentsLabel";
            TaskArgumentsLabel.Padding = new Padding(25, 5, 0, 10);
            TaskArgumentsLabel.Size = new Size(234, 51);
            TaskArgumentsLabel.TabIndex = 0;
            TaskArgumentsLabel.Text = "Task Arguments";
            TaskArgumentsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ControlPanel
            // 
            ControlPanel.BorderStyle = BorderStyle.FixedSingle;
            ControlPanel.Controls.Add(CancelButton);
            ControlPanel.Controls.Add(CalculateButton);
            ControlPanel.Controls.Add(DrawButton);
            ControlPanel.Dock = DockStyle.Bottom;
            ControlPanel.Location = new Point(1127, 437);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(568, 73);
            ControlPanel.TabIndex = 6;
            // 
            // CancelButton
            // 
            CancelButton.Dock = DockStyle.Right;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 238);
            CancelButton.Location = new Point(-97, 0);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(221, 71);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // CalculateButton
            // 
            CalculateButton.Dock = DockStyle.Right;
            CalculateButton.FlatStyle = FlatStyle.Flat;
            CalculateButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 238);
            CalculateButton.Location = new Point(124, 0);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(221, 71);
            CalculateButton.TabIndex = 1;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // DrawButton
            // 
            DrawButton.Dock = DockStyle.Right;
            DrawButton.FlatStyle = FlatStyle.Flat;
            DrawButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 238);
            DrawButton.Location = new Point(345, 0);
            DrawButton.Name = "DrawButton";
            DrawButton.Size = new Size(221, 71);
            DrawButton.TabIndex = 0;
            DrawButton.Text = "Draw";
            DrawButton.UseVisualStyleBackColor = true;
            DrawButton.Click += DrawButton_Click;
            // 
            // SolutionPanel
            // 
            SolutionPanel.BorderStyle = BorderStyle.FixedSingle;
            SolutionPanel.Controls.Add(SolutionBox);
            SolutionPanel.Controls.Add(SolutionHeaderPanel);
            SolutionPanel.Dock = DockStyle.Fill;
            SolutionPanel.Location = new Point(1127, 0);
            SolutionPanel.Name = "SolutionPanel";
            SolutionPanel.Padding = new Padding(20, 0, 0, 0);
            SolutionPanel.Size = new Size(568, 437);
            SolutionPanel.TabIndex = 7;
            // 
            // SolutionBox
            // 
            SolutionBox.BorderStyle = BorderStyle.None;
            SolutionBox.Dock = DockStyle.Fill;
            SolutionBox.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            SolutionBox.Location = new Point(20, 63);
            SolutionBox.Name = "SolutionBox";
            SolutionBox.ReadOnly = true;
            SolutionBox.Size = new Size(546, 372);
            SolutionBox.TabIndex = 1;
            SolutionBox.Text = "You will se the solution of the task here!";
            // 
            // SolutionHeaderPanel
            // 
            SolutionHeaderPanel.Controls.Add(CopySolutionButton);
            SolutionHeaderPanel.Controls.Add(SolutionLabel);
            SolutionHeaderPanel.Dock = DockStyle.Top;
            SolutionHeaderPanel.Location = new Point(20, 0);
            SolutionHeaderPanel.Name = "SolutionHeaderPanel";
            SolutionHeaderPanel.Size = new Size(546, 63);
            SolutionHeaderPanel.TabIndex = 0;
            // 
            // CopySolutionButton
            // 
            CopySolutionButton.Dock = DockStyle.Right;
            CopySolutionButton.FlatStyle = FlatStyle.Flat;
            CopySolutionButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 238);
            CopySolutionButton.Location = new Point(252, 0);
            CopySolutionButton.Name = "CopySolutionButton";
            CopySolutionButton.Size = new Size(294, 63);
            CopySolutionButton.TabIndex = 3;
            CopySolutionButton.Text = "Copy Solution";
            CopySolutionButton.UseVisualStyleBackColor = true;
            CopySolutionButton.Click += CopySolutionButton_Click;
            // 
            // SolutionLabel
            // 
            SolutionLabel.AutoSize = true;
            SolutionLabel.Dock = DockStyle.Left;
            SolutionLabel.FlatStyle = FlatStyle.System;
            SolutionLabel.Font = new Font("Nirmala UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SolutionLabel.Location = new Point(0, 0);
            SolutionLabel.Name = "SolutionLabel";
            SolutionLabel.Padding = new Padding(200, 10, 0, 0);
            SolutionLabel.Size = new Size(384, 46);
            SolutionLabel.TabIndex = 1;
            SolutionLabel.Text = "Task Solution:";
            SolutionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TasksWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1695, 510);
            ControlBox = false;
            Controls.Add(SolutionPanel);
            Controls.Add(ControlPanel);
            Controls.Add(TaskArgumentsPanel);
            Controls.Add(NumRootTasksPanel);
            Controls.Add(NumIntTasksPanel);
            Controls.Add(NumDifTasksPanel);
            Controls.Add(ViewsPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TasksWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tasks";
            ViewsPanel.ResumeLayout(false);
            NumDifTasksPanel.ResumeLayout(false);
            NumIntTasksPanel.ResumeLayout(false);
            NumRootTasksPanel.ResumeLayout(false);
            TaskArgumentsPanel.ResumeLayout(false);
            TaskArgumentsPanel.PerformLayout();
            ControlPanel.ResumeLayout(false);
            SolutionPanel.ResumeLayout(false);
            SolutionHeaderPanel.ResumeLayout(false);
            SolutionHeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ViewsPanel;
        private Panel NumDifTasksPanel;
        private Panel NumIntTasksPanel;
        private Panel NumRootTasksPanel;
        private Panel TaskArgumentsPanel;
        private Label TaskArgumentsLabel;
        private Panel ControlPanel;
        private Button DrawButton;
        private Button CancelButton;
        private Button CalculateButton;
        private Panel SolutionPanel;
        private RichTextBox SolutionBox;
        private Panel SolutionHeaderPanel;
        private Button CopySolutionButton;
        private Label SolutionLabel;
        private ListBox ViewsList;
        private ListBox NumDifTasks;
        private TextBox Arg1Box;
        private TextBox Arg6Box;
        private TextBox Arg5Box;
        private TextBox Arg4Box;
        private TextBox Arg3Box;
        private TextBox Arg2Box;
        private RichTextBox ArgsList;
        private ListBox NumIntTasks;
        private ListBox NumRootTasks;
    }
}