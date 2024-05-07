namespace ScenarioGenerator;

partial class Form1
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
        lvwAirport = new ListView();
        lblAirportName = new Label();
        lblAirportPositionX = new Label();
        numAirportPositionX = new NumericUpDown();
        numAirportPositionY = new NumericUpDown();
        lblAirportPositionY = new Label();
        txbAirportName = new TextBox();
        numAirportPassengerTraffic = new NumericUpDown();
        lblAirportPassengerTraffic = new Label();
        numAirportCargoTraffic = new NumericUpDown();
        lblAirportCargoTraffic = new Label();
        btnAddAirport = new Button();
        lvwAirplane = new ListView();
        btnEditAirport = new Button();
        btnRemoveAirport = new Button();
        txbPlaneName = new TextBox();
        lblPlaneName = new Label();
        lblPlaneType = new Label();
        cbxPlaneType = new ComboBox();
        numPlaneSpeed = new NumericUpDown();
        lblPlaneSpeed = new Label();
        numPlaneBoardingTime = new NumericUpDown();
        lblPlaneBoardingTime = new Label();
        numPlaneUnboardingTime = new NumericUpDown();
        lblPlaneUnboardingTime = new Label();
        btnPlaneAdd = new Button();
        numPlaneMaintenanceTime = new NumericUpDown();
        lblPlaneMaintenanceTime = new Label();
        lblFrequencyFire = new Label();
        numFrequencyFire = new NumericUpDown();
        numFrequencyRecon = new NumericUpDown();
        lblFrequencyRecon = new Label();
        numFrequencyRescue = new NumericUpDown();
        lblFrequencyRescue = new Label();
        btnSave = new Button();
        btnLoad = new Button();
        btnEmpty = new Button();
        ((System.ComponentModel.ISupportInitialize)numAirportPassengerTraffic).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numAirportCargoTraffic).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneSpeed).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneBoardingTime).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneUnboardingTime).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneMaintenanceTime).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numFrequencyFire).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numFrequencyRecon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numFrequencyRescue).BeginInit();
        SuspendLayout();
        // 
        // lvwAirport
        // 
        lvwAirport.Location = new Point(49, 26);
        lvwAirport.Margin = new Padding(4, 5, 4, 5);
        lvwAirport.Name = "lvwAirport";
        lvwAirport.Size = new Size(1343, 166);
        lvwAirport.TabIndex = 0;
        lvwAirport.UseCompatibleStateImageBehavior = false;
        lvwAirport.MultiSelect = false;
        lvwAirport.View = View.Details;
        lvwAirport.Columns.Add("Airports", lvwAirport.Width - 4);
        lvwAirport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        // 
        // lblAirportName
        // 
        lblAirportName.AutoSize = true;
        lblAirportName.Location = new Point(49, 200);
        lblAirportName.Name = "lblAirportName";
        lblAirportName.Size = new Size(68, 25);
        lblAirportName.TabIndex = 2;
        lblAirportName.Text = "Name :";
        // 
        // lblAirportPositionX
        // 
        lblAirportPositionX.AutoSize = true;
        lblAirportPositionX.Location = new Point(279, 200);
        lblAirportPositionX.Name = "lblAirportPositionX";
        lblAirportPositionX.Size = new Size(100, 25);
        lblAirportPositionX.TabIndex = 3;
        lblAirportPositionX.Text = "Position X :";
        // 
        // txbAirportPositionX
        // 
        numAirportPositionX.Location = new Point(386, 200);
        numAirportPositionX.Name = "numAirportPositionX";
        numAirportPositionX.Size = new Size(57, 31);
        numAirportPositionX.TabIndex = 4;
        // 
        // txbAirportPositionY
        // 
        this.numAirportPositionY.Location = new Point(555, 200);
        this.numAirportPositionY.Name = "numAirportPositionY";
        this.numAirportPositionY.Size = new Size(48, 31);
        this.numAirportPositionY.TabIndex = 6;
        // 
        // lblAirportPositionY
        // 
        lblAirportPositionY.AutoSize = true;
        lblAirportPositionY.Location = new Point(449, 200);
        lblAirportPositionY.Name = "lblAirportPositionY";
        lblAirportPositionY.Size = new Size(99, 25);
        lblAirportPositionY.TabIndex = 5;
        lblAirportPositionY.Text = "Position Y :";
        // 
        // txbAirportName
        // 
        txbAirportName.Location = new Point(123, 200);
        txbAirportName.Name = "txbAirportName";
        txbAirportName.Size = new Size(150, 31);
        txbAirportName.TabIndex = 7;
        // 
        // numAirportMaxPassenger
        // 
        numAirportPassengerTraffic.Location = new Point(780, 200);
        numAirportPassengerTraffic.Name = "numAirportPassengerTraffic";
        numAirportPassengerTraffic.Size = new Size(68, 31);
        numAirportPassengerTraffic.Maximum = Int32.MaxValue;
        numAirportPassengerTraffic.TabIndex = 11;
        // 
        // lblAirportPassengerTraffic
        // 
        lblAirportPassengerTraffic.AutoSize = true;
        lblAirportPassengerTraffic.Location = new Point(620, 200);
        lblAirportPassengerTraffic.Name = "lblAirportPassengerTraffic";
        lblAirportPassengerTraffic.Size = new Size(102, 25);
        lblAirportPassengerTraffic.TabIndex = 14;
        lblAirportPassengerTraffic.Text = "Passenger Traffic :";
        // 
        // numAirportMinCargo
        // 
        numAirportCargoTraffic.Location = new Point(980, 200);
        numAirportCargoTraffic.Name = "numAirportCargoTraffic";
        numAirportCargoTraffic.Size = new Size(72, 31);
        numAirportCargoTraffic.TabIndex = 13;
        // 
        // lblAirportMinCargo
        // 
        lblAirportCargoTraffic.AutoSize = true;
        lblAirportCargoTraffic.Location = new Point(860, 200);
        lblAirportCargoTraffic.Name = "lblAirportCargoTraffic";
        lblAirportCargoTraffic.Size = new Size(99, 25);
        lblAirportCargoTraffic.TabIndex = 12;
        lblAirportCargoTraffic.Text = "Cargo Traffic :";
        // 
        // btnAddAirport
        // 
        btnAddAirport.Location = new Point(49, 237);
        btnAddAirport.Name = "btnAddAirport";
        btnAddAirport.Size = new Size(1343, 34);
        btnAddAirport.TabIndex = 16;
        btnAddAirport.Text = "Add";
        btnAddAirport.UseVisualStyleBackColor = true;
        btnAddAirport.Click += btnAddAirport_Click;
        // 
        // lvwAirplane
        // 
        lvwAirplane.Location = new Point(49, 359);
        lvwAirplane.Margin = new Padding(4, 5, 4, 5);
        lvwAirplane.Name = "lvwAirplane";
        lvwAirplane.Size = new Size(1343, 166);
        lvwAirplane.TabIndex = 18;
        lvwAirplane.UseCompatibleStateImageBehavior = false;
        lvwAirplane.MultiSelect = false;
        lvwAirplane.View = View.Details;
        lvwAirplane.Columns.Add("Airplanes", lvwAirplane.Width - 4);
        lvwAirplane.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        // 
        // btnEditAirport
        // 
        btnEditAirport.Location = new Point(49, 277);
        btnEditAirport.Name = "btnEditAirport";
        btnEditAirport.Size = new Size(1343, 34);
        btnEditAirport.TabIndex = 17;
        btnEditAirport.Text = "Edit";
        btnEditAirport.UseVisualStyleBackColor = true;
        btnEditAirport.Click += btnEditAirport_Click;
        // 
        // btnRemoveAirport
        // 
        btnRemoveAirport.Location = new Point(49, 317);
        btnRemoveAirport.Name = "btnRemoveAirport";
        btnRemoveAirport.Size = new Size(1343, 34);
        btnRemoveAirport.TabIndex = 19;
        btnRemoveAirport.Text = "Remove";
        btnRemoveAirport.UseVisualStyleBackColor = true;
        btnRemoveAirport.Click += btnDeleteAirport_Click;
        // 
        // txbPlaneName
        // 
        txbPlaneName.Location = new Point(123, 530);
        txbPlaneName.Name = "txbPlaneName";
        txbPlaneName.Size = new Size(150, 31);
        txbPlaneName.TabIndex = 21;
        // 
        // lblPlaneName
        // 
        lblPlaneName.AutoSize = true;
        lblPlaneName.Location = new Point(49, 530);
        lblPlaneName.Name = "lblPlaneName";
        lblPlaneName.Size = new Size(68, 25);
        lblPlaneName.TabIndex = 20;
        lblPlaneName.Text = "Name :";
        // 
        // lblPlaneType
        // 
        lblPlaneType.AutoSize = true;
        lblPlaneType.Location = new Point(279, 530);
        lblPlaneType.Name = "lblPlaneType";
        lblPlaneType.Size = new Size(58, 25);
        lblPlaneType.TabIndex = 22;
        lblPlaneType.Text = "Type :";
        // 
        // cbxPlaneType
        // 
        cbxPlaneType.FormattingEnabled = true;
        cbxPlaneType.Items.AddRange(new object[] { "Passenger", "Cargo", "Fire", "Recon", "Rescue" });
        cbxPlaneType.Location = new Point(343, 530);
        cbxPlaneType.Name = "cbxPlaneType";
        cbxPlaneType.Size = new Size(182, 33);
        cbxPlaneType.TabIndex = 23;
        // 
        // numPlaneSpeed
        // 
        numPlaneSpeed.Location = new Point(609, 530);
        numPlaneSpeed.Name = "numPlaneSpeed";
        numPlaneSpeed.Size = new Size(72, 31);
        numPlaneSpeed.TabIndex = 25;
        // 
        // lblPlaneSpeed
        // 
        lblPlaneSpeed.AutoSize = true;
        lblPlaneSpeed.Location = new Point(531, 530);
        lblPlaneSpeed.Name = "lblPlaneSpeed";
        lblPlaneSpeed.Size = new Size(71, 25);
        lblPlaneSpeed.TabIndex = 24;
        lblPlaneSpeed.Text = "Speed :";
        // 
        // numPlaneBoardingTime
        // 
        numPlaneBoardingTime.Location = new Point(824, 530);
        numPlaneBoardingTime.Name = "numPlaneBoardingTime";
        numPlaneBoardingTime.Size = new Size(72, 31);
        numPlaneBoardingTime.TabIndex = 27;
        // 
        // lblPlaneBoardingTime
        // 
        lblPlaneBoardingTime.AutoSize = true;
        lblPlaneBoardingTime.Location = new Point(687, 530);
        lblPlaneBoardingTime.Name = "lblPlaneBoardingTime";
        lblPlaneBoardingTime.Size = new Size(131, 25);
        lblPlaneBoardingTime.TabIndex = 26;
        lblPlaneBoardingTime.Text = "BoardingTime :";
        lblPlaneBoardingTime.UseMnemonic = false;
        // 
        // numPlaneUnboardingTime
        // 
        numPlaneUnboardingTime.Location = new Point(1062, 530);
        numPlaneUnboardingTime.Name = "numPlaneUnboardingTime";
        numPlaneUnboardingTime.Size = new Size(72, 31);
        numPlaneUnboardingTime.TabIndex = 29;
        // 
        // lblPlaneUnboardingTime
        // 
        lblPlaneUnboardingTime.AutoSize = true;
        lblPlaneUnboardingTime.Location = new Point(902, 530);
        lblPlaneUnboardingTime.Name = "lblPlaneUnboardingTime";
        lblPlaneUnboardingTime.Size = new Size(154, 25);
        lblPlaneUnboardingTime.TabIndex = 28;
        lblPlaneUnboardingTime.Text = "UnboardingTime :";
        lblPlaneUnboardingTime.UseMnemonic = false;
        // 
        // btnPlaneAdd
        // 
        btnPlaneAdd.Location = new Point(49, 569);
        btnPlaneAdd.Name = "btnPlaneAdd";
        btnPlaneAdd.Size = new Size(1343, 34);
        btnPlaneAdd.TabIndex = 30;
        btnPlaneAdd.Text = "Add";
        btnPlaneAdd.UseVisualStyleBackColor = true;
        btnPlaneAdd.Click += btnAddPlane_Click;
        // 
        // numPlaneMaintenanceTime
        // 
        numPlaneMaintenanceTime.Location = new Point(1305, 531);
        numPlaneMaintenanceTime.Name = "numPlaneMaintenanceTime";
        numPlaneMaintenanceTime.Size = new Size(72, 31);
        numPlaneMaintenanceTime.TabIndex = 32;
        // 
        // lblPlaneMaintenanceTime
        // 
        lblPlaneMaintenanceTime.AutoSize = true;
        lblPlaneMaintenanceTime.Location = new Point(1140, 530);
        lblPlaneMaintenanceTime.Name = "lblPlaneMaintenanceTime";
        lblPlaneMaintenanceTime.Size = new Size(159, 25);
        lblPlaneMaintenanceTime.TabIndex = 31;
        lblPlaneMaintenanceTime.Text = "MaintenanceTime :";
        lblPlaneMaintenanceTime.UseMnemonic = false;
        // 
        // lblFrequencyFire
        // 
        lblFrequencyFire.AutoSize = true;
        lblFrequencyFire.Location = new Point(49, 615);
        lblFrequencyFire.Name = "lblFrequencyFire";
        lblFrequencyFire.Size = new Size(130, 25);
        lblFrequencyFire.TabIndex = 33;
        lblFrequencyFire.Text = "FrequencyFire :";
        // 
        // numFrequencyFire
        // 
        numFrequencyFire.Location = new Point(185, 615);
        numFrequencyFire.Name = "numFrequencyFire";
        numFrequencyFire.Size = new Size(72, 31);
        numFrequencyFire.TabIndex = 34;
        // 
        // numFrequencyRecon
        // 
        numFrequencyRecon.Location = new Point(435, 615);
        numFrequencyRecon.Name = "numFrequencyRecon";
        numFrequencyRecon.Size = new Size(72, 31);
        numFrequencyRecon.TabIndex = 36;
        // 
        // lblFrequencyRecon
        // 
        lblFrequencyRecon.AutoSize = true;
        lblFrequencyRecon.Location = new Point(279, 615);
        lblFrequencyRecon.Name = "lblFrequencyRecon";
        lblFrequencyRecon.Size = new Size(150, 25);
        lblFrequencyRecon.TabIndex = 35;
        lblFrequencyRecon.Text = "FrequencyRecon :";
        // 
        // numFrequencyRescue
        // 
        numFrequencyRescue.Location = new Point(675, 615);
        numFrequencyRescue.Name = "numFrequencyRescue";
        numFrequencyRescue.Size = new Size(72, 31);
        numFrequencyRescue.TabIndex = 38;
        // 
        // lblFrequencyRescue
        // 
        lblFrequencyRescue.AutoSize = true;
        lblFrequencyRescue.Location = new Point(513, 615);
        lblFrequencyRescue.Name = "lblFrequencyRescue";
        lblFrequencyRescue.Size = new Size(156, 25);
        lblFrequencyRescue.TabIndex = 37;
        lblFrequencyRescue.Text = "FrequencyRescue :";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(49, 652);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(1343, 34);
        btnSave.TabIndex = 39;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(49, 692);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(1343, 34);
        btnLoad.TabIndex = 40;
        btnLoad.Text = "Load";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // btnEmpty
        // 
        btnEmpty.Location = new Point(49, 732);
        btnEmpty.Name = "btnEmpty";
        btnEmpty.Size = new Size(1343, 34);
        btnEmpty.TabIndex = 41;
        btnEmpty.Text = "Empty";
        btnEmpty.UseVisualStyleBackColor = true;
        btnEmpty.Click += btnEmpty_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1436, 800);
        Controls.Add(btnEmpty);
        Controls.Add(btnLoad);
        Controls.Add(btnSave);
        Controls.Add(numFrequencyRescue);
        Controls.Add(lblFrequencyRescue);
        Controls.Add(numFrequencyRecon);
        Controls.Add(lblFrequencyRecon);
        Controls.Add(numFrequencyFire);
        Controls.Add(lblFrequencyFire);
        Controls.Add(numPlaneMaintenanceTime);
        Controls.Add(lblPlaneMaintenanceTime);
        Controls.Add(btnPlaneAdd);
        Controls.Add(numPlaneUnboardingTime);
        Controls.Add(lblPlaneUnboardingTime);
        Controls.Add(numPlaneBoardingTime);
        Controls.Add(lblPlaneBoardingTime);
        Controls.Add(numPlaneSpeed);
        Controls.Add(lblPlaneSpeed);
        Controls.Add(cbxPlaneType);
        Controls.Add(lblPlaneType);
        Controls.Add(txbPlaneName);
        Controls.Add(lblPlaneName);
        Controls.Add(btnRemoveAirport);
        Controls.Add(btnEditAirport);
        Controls.Add(lvwAirplane);
        Controls.Add(btnAddAirport);
        Controls.Add(lblAirportPassengerTraffic);
        Controls.Add(numAirportCargoTraffic);
        Controls.Add(lblAirportCargoTraffic);
        Controls.Add(numAirportPassengerTraffic);
        Controls.Add(txbAirportName);
        Controls.Add(numAirportPositionY);
        Controls.Add(lblAirportPositionY);
        Controls.Add(numAirportPositionX);
        Controls.Add(lblAirportPositionX);
        Controls.Add(lblAirportName);
        Controls.Add(lvwAirport);
        Margin = new Padding(4, 5, 4, 5);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)numAirportPassengerTraffic).EndInit();
        ((System.ComponentModel.ISupportInitialize)numAirportCargoTraffic).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneSpeed).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneBoardingTime).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneUnboardingTime).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPlaneMaintenanceTime).EndInit();
        ((System.ComponentModel.ISupportInitialize)numFrequencyFire).EndInit();
        ((System.ComponentModel.ISupportInitialize)numFrequencyRecon).EndInit();
        ((System.ComponentModel.ISupportInitialize)numFrequencyRescue).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView lvwAirport;
    private Label lblAirportName;
    private Label lblAirportPositionX;
    private NumericUpDown numAirportPositionX;
    private NumericUpDown numAirportPositionY;
    private Label lblAirportPositionY;
    private TextBox txbAirportName;
    private NumericUpDown numAirportPassengerTraffic;
    private Label lblAirportPassengerTraffic;
    private NumericUpDown numAirportCargoTraffic;
    private Label lblAirportCargoTraffic;
    private Button btnAddAirport;
    private ListView lvwAirplane;
    private Button btnEditAirport;
    private Button btnRemoveAirport;
    private TextBox txbPlaneName;
    private Label lblPlaneName;
    private Label lblPlaneType;
    private ComboBox cbxPlaneType;
    private NumericUpDown numPlaneSpeed;
    private Label lblPlaneSpeed;
    private NumericUpDown numPlaneBoardingTime;
    private Label lblPlaneBoardingTime;
    private NumericUpDown numPlaneUnboardingTime;
    private Label lblPlaneUnboardingTime;
    private Button btnPlaneAdd;
    private NumericUpDown numPlaneMaintenanceTime;
    private Label lblPlaneMaintenanceTime;
    private Label lblFrequencyFire;
    private NumericUpDown numFrequencyFire;
    private NumericUpDown numFrequencyRecon;
    private Label lblFrequencyRecon;
    private NumericUpDown numFrequencyRescue;
    private Label lblFrequencyRescue;
    private Button btnSave;
    private Button btnLoad;
    private Button btnEmpty;
}