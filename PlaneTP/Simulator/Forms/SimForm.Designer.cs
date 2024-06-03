namespace Simulator;

partial class SimForm
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
        mapImage = new PictureBox();
        loadScenarioBtn = new Button();
        advanceTimeBtn = new Button();
        timeAdvanceSelector = new NumericUpDown();
        timeAdvanceLabel = new Label();
        airportTreeView = new TreeView();
        label1 = new Label();
        planeTreeView = new TreeView();
        label2 = new Label();
        ((System.ComponentModel.ISupportInitialize)mapImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)timeAdvanceSelector).BeginInit();
        SuspendLayout();
        // 
        // mapImage
        // 
        mapImage.Image = Properties.Resources.world_map;
        mapImage.Location = new Point(12, 41);
        mapImage.Name = "mapImage";
        mapImage.Size = new Size(1000, 500);
        mapImage.SizeMode = PictureBoxSizeMode.StretchImage;
        mapImage.TabIndex = 0;
        mapImage.TabStop = false;
        mapImage.Paint += mapImage_Paint;
        // 
        // loadScenarioBtn
        // 
        loadScenarioBtn.Location = new Point(12, 12);
        loadScenarioBtn.Name = "loadScenarioBtn";
        loadScenarioBtn.Size = new Size(296, 23);
        loadScenarioBtn.TabIndex = 1;
        loadScenarioBtn.Text = "Load Scenario";
        loadScenarioBtn.UseVisualStyleBackColor = true;
        loadScenarioBtn.Click += button1_Click;
        // 
        // advanceTimeBtn
        // 
        advanceTimeBtn.Location = new Point(895, 12);
        advanceTimeBtn.Name = "advanceTimeBtn";
        advanceTimeBtn.Size = new Size(117, 23);
        advanceTimeBtn.TabIndex = 2;
        advanceTimeBtn.Text = "Advance time";
        advanceTimeBtn.UseVisualStyleBackColor = true;
        advanceTimeBtn.Click += advanceTimeBtn_Click;
        // 
        // timeAdvanceSelector
        // 
        timeAdvanceSelector.Location = new Point(836, 12);
        timeAdvanceSelector.Name = "timeAdvanceSelector";
        timeAdvanceSelector.Size = new Size(53, 23);
        timeAdvanceSelector.TabIndex = 3;
        timeAdvanceSelector.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // timeAdvanceLabel
        // 
        timeAdvanceLabel.AutoSize = true;
        timeAdvanceLabel.Location = new Point(731, 16);
        timeAdvanceLabel.Name = "timeAdvanceLabel";
        timeAdvanceLabel.Size = new Size(99, 15);
        timeAdvanceLabel.TabIndex = 4;
        timeAdvanceLabel.Text = "Advance time by:";
        // airportTreeView
        // 
        airportTreeView.Location = new Point(12, 563);
        airportTreeView.Name = "airportTreeView";
        airportTreeView.ShowPlusMinus = false;
        airportTreeView.Size = new Size(1000, 274);
        airportTreeView.TabIndex = 6;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 544);
        label1.Name = "label1";
        label1.Size = new Size(109, 15);
        label1.TabIndex = 7;
        label1.Text = "Airports and clients";
        // 
        // planeTreeView
        // 
        planeTreeView.Location = new Point(516, 563);
        planeTreeView.Name = "planeTreeView";
        planeTreeView.ShowPlusMinus = false;
        planeTreeView.Size = new Size(496, 274);
        planeTreeView.TabIndex = 8;
        planeTreeView.Visible = true;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(516, 544);
        label2.Name = "label2";
        label2.Size = new Size(109, 15);
        label2.TabIndex = 9;
        label2.Text = "Airports and planes";
        label2.Visible = true;
        // 
        // SimForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1024, 849);
        Controls.Add(label2);
        Controls.Add(planeTreeView);
        Controls.Add(label1);
        Controls.Add(airportTreeView);
        Controls.Add(timeLabel);
        Controls.Add(timeAdvanceLabel);
        Controls.Add(timeAdvanceSelector);
        Controls.Add(advanceTimeBtn);
        Controls.Add(loadScenarioBtn);
        Controls.Add(mapImage);
        Name = "SimForm";
        Text = "Simulator";
        ((System.ComponentModel.ISupportInitialize)mapImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)timeAdvanceSelector).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox mapImage;
    private Button loadScenarioBtn;
    private Button advanceTimeBtn;
    private NumericUpDown timeAdvanceSelector;
    private Label timeAdvanceLabel;
    private Label timeLabel;
    private TreeView airportTreeView;
    private Label label1;
    private TreeView planeTreeView;
    private Label label2;
}