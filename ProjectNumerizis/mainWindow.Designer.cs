namespace ProjectNumerizis
{
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
            ControlPanel = new Panel();
            DetailedSolutionButton = new Button();
            DerivativesButton = new Button();
            IntegralsButton = new Button();
            RootsButton = new Button();
            MainPanel = new Panel();
            RootsConfigPanel = new Panel();
            RootsConfigLabel = new Label();
            ControlPanel.SuspendLayout();
            MainPanel.SuspendLayout();
            RootsConfigPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ControlPanel
            // 
            ControlPanel.BorderStyle = BorderStyle.FixedSingle;
            ControlPanel.Controls.Add(DetailedSolutionButton);
            ControlPanel.Controls.Add(DerivativesButton);
            ControlPanel.Controls.Add(IntegralsButton);
            ControlPanel.Controls.Add(RootsButton);
            ControlPanel.Dock = DockStyle.Top;
            ControlPanel.Location = new Point(0, 0);
            ControlPanel.Margin = new Padding(4);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(1904, 41);
            ControlPanel.TabIndex = 0;
            // 
            // DetailedSolutionButton
            // 
            DetailedSolutionButton.Dock = DockStyle.Right;
            DetailedSolutionButton.FlatStyle = FlatStyle.Flat;
            DetailedSolutionButton.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DetailedSolutionButton.Location = new Point(1693, 0);
            DetailedSolutionButton.Margin = new Padding(0);
            DetailedSolutionButton.Name = "DetailedSolutionButton";
            DetailedSolutionButton.Size = new Size(209, 39);
            DetailedSolutionButton.TabIndex = 3;
            DetailedSolutionButton.Text = "Detailed Solution";
            DetailedSolutionButton.TextAlign = ContentAlignment.TopCenter;
            DetailedSolutionButton.UseVisualStyleBackColor = true;
            DetailedSolutionButton.Click += DetailedSolutionButton_Click;
            // 
            // DerivativesButton
            // 
            DerivativesButton.Dock = DockStyle.Left;
            DerivativesButton.FlatStyle = FlatStyle.Flat;
            DerivativesButton.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DerivativesButton.Location = new Point(260, 0);
            DerivativesButton.Margin = new Padding(0);
            DerivativesButton.Name = "DerivativesButton";
            DerivativesButton.Size = new Size(130, 39);
            DerivativesButton.TabIndex = 2;
            DerivativesButton.Text = "Derivatives";
            DerivativesButton.TextAlign = ContentAlignment.TopCenter;
            DerivativesButton.UseVisualStyleBackColor = true;
            DerivativesButton.Click += DerivativesButton_Click;
            // 
            // IntegralsButton
            // 
            IntegralsButton.Dock = DockStyle.Left;
            IntegralsButton.FlatStyle = FlatStyle.Flat;
            IntegralsButton.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IntegralsButton.Location = new Point(130, 0);
            IntegralsButton.Margin = new Padding(0);
            IntegralsButton.Name = "IntegralsButton";
            IntegralsButton.Size = new Size(130, 39);
            IntegralsButton.TabIndex = 1;
            IntegralsButton.Text = "Integrals";
            IntegralsButton.TextAlign = ContentAlignment.TopCenter;
            IntegralsButton.UseVisualStyleBackColor = true;
            IntegralsButton.Click += IntegralsButton_Click;
            // 
            // RootsButton
            // 
            RootsButton.Dock = DockStyle.Left;
            RootsButton.FlatStyle = FlatStyle.Flat;
            RootsButton.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RootsButton.Location = new Point(0, 0);
            RootsButton.Margin = new Padding(0);
            RootsButton.Name = "RootsButton";
            RootsButton.Size = new Size(130, 39);
            RootsButton.TabIndex = 0;
            RootsButton.Text = "Roots";
            RootsButton.TextAlign = ContentAlignment.TopCenter;
            RootsButton.UseVisualStyleBackColor = true;
            RootsButton.Click += RootsButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(RootsConfigPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 41);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1904, 752);
            MainPanel.TabIndex = 1;
            // 
            // RootsConfigPanel
            // 
            RootsConfigPanel.BorderStyle = BorderStyle.FixedSingle;
            RootsConfigPanel.Controls.Add(RootsConfigLabel);
            RootsConfigPanel.Dock = DockStyle.Left;
            RootsConfigPanel.Location = new Point(0, 0);
            RootsConfigPanel.Name = "RootsConfigPanel";
            RootsConfigPanel.Size = new Size(250, 752);
            RootsConfigPanel.TabIndex = 0;
            // 
            // RootsConfigLabel
            // 
            RootsConfigLabel.AutoSize = true;
            RootsConfigLabel.Dock = DockStyle.Top;
            RootsConfigLabel.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RootsConfigLabel.Location = new Point(0, 0);
            RootsConfigLabel.Name = "RootsConfigLabel";
            RootsConfigLabel.Padding = new Padding(45, 2, 0, 0);
            RootsConfigLabel.Size = new Size(198, 33);
            RootsConfigLabel.TabIndex = 0;
            RootsConfigLabel.Text = "Roots Config";
            RootsConfigLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1904, 793);
            Controls.Add(MainPanel);
            Controls.Add(ControlPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "MainWindow";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProjectNumerizis";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ControlPanel.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            RootsConfigPanel.ResumeLayout(false);
            RootsConfigPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ControlPanel;
        private Button RootsButton;
        private Button DetailedSolutionButton;
        private Button DerivativesButton;
        private Button IntegralsButton;
        private Panel MainPanel;
        private Panel RootsConfigPanel;
        private Label RootsConfigLabel;
    }
}
