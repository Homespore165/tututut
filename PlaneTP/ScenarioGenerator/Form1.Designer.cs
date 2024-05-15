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
        airportName = new ColumnHeader();
        xPos = new ColumnHeader();
        yPos = new ColumnHeader();
        passengerTraffic = new ColumnHeader();
        cargoTraffic = new ColumnHeader();
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
        planeName = new ColumnHeader();
        speed = new ColumnHeader();
        maintenanceTime = new ColumnHeader();
        boardingTime = new ColumnHeader();
        unboardingTime = new ColumnHeader();
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
        coordsPickerBtn = new Button();
        ((System.ComponentModel.ISupportInitialize)numAirportPositionX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numAirportPositionY).BeginInit();
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
        lvwAirport.Columns.AddRange(new ColumnHeader[] { airportName, xPos, yPos, passengerTraffic, cargoTraffic });
        lvwAirport.Location = new Point(34, 16);
        lvwAirport.MultiSelect = false;
        lvwAirport.Name = "lvwAirport";
        lvwAirport.Size = new Size(941, 101);
        lvwAirport.TabIndex = 0;
        lvwAirport.UseCompatibleStateImageBehavior = false;
        lvwAirport.View = View.Details;
        lvwAirport.SelectedIndexChanged += lvwAirport_SelectedIndexChanged;
        // 
        // airportName
        // 
        airportName.Text = "Airport Name";
        airportName.Width = 100;
        // 
        // xPos
        // 
        xPos.Text = "X position";
        xPos.Width = 70;
        // 
        // yPos
        // 
        yPos.Text = "Y position";
        yPos.Width = 70;
        // 
        // passengerTraffic
        // 
        passengerTraffic.Text = "Passenger Traffic";
        passengerTraffic.Width = 100;
        // 
        // cargoTraffic
        // 
        cargoTraffic.Text = "Cargo Traffic";
        cargoTraffic.Width = 100;
        // 
        // lblAirportName
        // 
        lblAirportName.AutoSize = true;
        lblAirportName.Location = new Point(34, 120);
        lblAirportName.Margin = new Padding(2, 0, 2, 0);
        lblAirportName.Name = "lblAirportName";
        lblAirportName.Size = new Size(45, 15);
        lblAirportName.TabIndex = 2;
        lblAirportName.Text = "Name :";
        // 
        // lblAirportPositionX
        // 
        lblAirportPositionX.AutoSize = true;
        lblAirportPositionX.Location = new Point(259, 120);
        lblAirportPositionX.Margin = new Padding(2, 0, 2, 0);
        lblAirportPositionX.Name = "lblAirportPositionX";
        lblAirportPositionX.Size = new Size(66, 15);
        lblAirportPositionX.TabIndex = 3;
        lblAirportPositionX.Text = "Position X :";
        // 
        // numAirportPositionX
        // 
        numAirportPositionX.Location = new Point(323, 120);
        numAirportPositionX.Margin = new Padding(2);
        numAirportPositionX.Maximum = new decimal(new int[] { 786, 0, 0, 0 });
        numAirportPositionX.Name = "numAirportPositionX";
        numAirportPositionX.Size = new Size(51, 23);
        numAirportPositionX.TabIndex = 4;
        // 
        // numAirportPositionY
        // 
        numAirportPositionY.Location = new Point(441, 120);
        numAirportPositionY.Margin = new Padding(2);
        numAirportPositionY.Maximum = new decimal(new int[] { 420, 0, 0, 0 });
        numAirportPositionY.Name = "numAirportPositionY";
        numAirportPositionY.Size = new Size(45, 23);
        numAirportPositionY.TabIndex = 6;
        // 
        // lblAirportPositionY
        // 
        lblAirportPositionY.AutoSize = true;
        lblAirportPositionY.Location = new Point(378, 120);
        lblAirportPositionY.Margin = new Padding(2, 0, 2, 0);
        lblAirportPositionY.Name = "lblAirportPositionY";
        lblAirportPositionY.Size = new Size(66, 15);
        lblAirportPositionY.TabIndex = 5;
        lblAirportPositionY.Text = "Position Y :";
        // 
        // txbAirportName
        // 
        txbAirportName.Location = new Point(86, 120);
        txbAirportName.Margin = new Padding(2);
        txbAirportName.Name = "txbAirportName";
        txbAirportName.Size = new Size(106, 23);
        txbAirportName.TabIndex = 7;
        // 
        // numAirportPassengerTraffic
        // 
        numAirportPassengerTraffic.Location = new Point(781, 120);
        numAirportPassengerTraffic.Margin = new Padding(2);
        numAirportPassengerTraffic.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
        numAirportPassengerTraffic.Name = "numAirportPassengerTraffic";
        numAirportPassengerTraffic.Size = new Size(48, 23);
        numAirportPassengerTraffic.TabIndex = 11;
        // 
        // lblAirportPassengerTraffic
        // 
        lblAirportPassengerTraffic.AutoSize = true;
        lblAirportPassengerTraffic.Location = new Point(669, 120);
        lblAirportPassengerTraffic.Margin = new Padding(2, 0, 2, 0);
        lblAirportPassengerTraffic.Name = "lblAirportPassengerTraffic";
        lblAirportPassengerTraffic.Size = new Size(101, 15);
        lblAirportPassengerTraffic.TabIndex = 14;
        lblAirportPassengerTraffic.Text = "Passenger Traffic :";
        // 
        // numAirportCargoTraffic
        // 
        numAirportCargoTraffic.Location = new Point(921, 120);
        numAirportCargoTraffic.Margin = new Padding(2);
        numAirportCargoTraffic.Name = "numAirportCargoTraffic";
        numAirportCargoTraffic.Size = new Size(50, 23);
        numAirportCargoTraffic.TabIndex = 13;
        // 
        // lblAirportCargoTraffic
        // 
        lblAirportCargoTraffic.AutoSize = true;
        lblAirportCargoTraffic.Location = new Point(837, 120);
        lblAirportCargoTraffic.Margin = new Padding(2, 0, 2, 0);
        lblAirportCargoTraffic.Name = "lblAirportCargoTraffic";
        lblAirportCargoTraffic.Size = new Size(80, 15);
        lblAirportCargoTraffic.TabIndex = 12;
        lblAirportCargoTraffic.Text = "Cargo Traffic :";
        // 
        // btnAddAirport
        // 
        btnAddAirport.Location = new Point(34, 142);
        btnAddAirport.Margin = new Padding(2);
        btnAddAirport.Name = "btnAddAirport";
        btnAddAirport.Size = new Size(940, 20);
        btnAddAirport.TabIndex = 16;
        btnAddAirport.Text = "Add";
        btnAddAirport.UseVisualStyleBackColor = true;
        btnAddAirport.Click += btnAddAirport_Click;
        // 
        // lvwAirplane
        // 
        lvwAirplane.Columns.AddRange(new ColumnHeader[] { planeName, speed, maintenanceTime, boardingTime, unboardingTime });
        lvwAirplane.Location = new Point(34, 215);
        lvwAirplane.MultiSelect = false;
        lvwAirplane.Name = "lvwAirplane";
        lvwAirplane.Size = new Size(941, 101);
        lvwAirplane.TabIndex = 18;
        lvwAirplane.UseCompatibleStateImageBehavior = false;
        lvwAirplane.View = View.Details;
        // 
        // planeName
        // 
        planeName.Text = "Plane Name";
        planeName.Width = 100;
        // 
        // speed
        // 
        speed.Text = "Speed";
        // 
        // maintenanceTime
        // 
        maintenanceTime.DisplayIndex = 4;
        maintenanceTime.Text = "Maintenance Time";
        maintenanceTime.Width = 120;
        // 
        // boardingTime
        // 
        boardingTime.DisplayIndex = 2;
        boardingTime.Text = "Boarding Time";
        boardingTime.Width = 120;
        // 
        // unboardingTime
        // 
        unboardingTime.DisplayIndex = 3;
        unboardingTime.Text = "Unboarding Time";
        unboardingTime.Width = 120;
        // 
        // btnEditAirport
        // 
        btnEditAirport.Location = new Point(34, 166);
        btnEditAirport.Margin = new Padding(2);
        btnEditAirport.Name = "btnEditAirport";
        btnEditAirport.Size = new Size(940, 20);
        btnEditAirport.TabIndex = 17;
        btnEditAirport.Text = "Edit";
        btnEditAirport.UseVisualStyleBackColor = true;
        btnEditAirport.Click += btnEditAirport_Click;
        // 
        // btnRemoveAirport
        // 
        btnRemoveAirport.Location = new Point(34, 190);
        btnRemoveAirport.Margin = new Padding(2);
        btnRemoveAirport.Name = "btnRemoveAirport";
        btnRemoveAirport.Size = new Size(940, 20);
        btnRemoveAirport.TabIndex = 19;
        btnRemoveAirport.Text = "Remove";
        btnRemoveAirport.UseVisualStyleBackColor = true;
        btnRemoveAirport.Click += btnDeleteAirport_Click;
        // 
        // txbPlaneName
        // 
        txbPlaneName.Location = new Point(86, 318);
        txbPlaneName.Margin = new Padding(2);
        txbPlaneName.Name = "txbPlaneName";
        txbPlaneName.Size = new Size(106, 23);
        txbPlaneName.TabIndex = 21;
        // 
        // lblPlaneName
        // 
        lblPlaneName.AutoSize = true;
        lblPlaneName.Location = new Point(34, 318);
        lblPlaneName.Margin = new Padding(2, 0, 2, 0);
        lblPlaneName.Name = "lblPlaneName";
        lblPlaneName.Size = new Size(45, 15);
        lblPlaneName.TabIndex = 20;
        lblPlaneName.Text = "Name :";
        // 
        // lblPlaneType
        // 
        lblPlaneType.AutoSize = true;
        lblPlaneType.Location = new Point(195, 318);
        lblPlaneType.Margin = new Padding(2, 0, 2, 0);
        lblPlaneType.Name = "lblPlaneType";
        lblPlaneType.Size = new Size(37, 15);
        lblPlaneType.TabIndex = 22;
        lblPlaneType.Text = "Type :";
        // 
        // cbxPlaneType
        // 
        cbxPlaneType.FormattingEnabled = true;
        cbxPlaneType.Items.AddRange(new object[] { "Passenger", "Cargo", "Fire", "Recon", "Rescue" });
        cbxPlaneType.Location = new Point(240, 318);
        cbxPlaneType.Margin = new Padding(2);
        cbxPlaneType.Name = "cbxPlaneType";
        cbxPlaneType.Size = new Size(129, 23);
        cbxPlaneType.TabIndex = 23;
        // 
        // numPlaneSpeed
        // 
        numPlaneSpeed.Location = new Point(426, 318);
        numPlaneSpeed.Margin = new Padding(2);
        numPlaneSpeed.Name = "numPlaneSpeed";
        numPlaneSpeed.Size = new Size(50, 23);
        numPlaneSpeed.TabIndex = 25;
        // 
        // lblPlaneSpeed
        // 
        lblPlaneSpeed.AutoSize = true;
        lblPlaneSpeed.Location = new Point(372, 318);
        lblPlaneSpeed.Margin = new Padding(2, 0, 2, 0);
        lblPlaneSpeed.Name = "lblPlaneSpeed";
        lblPlaneSpeed.Size = new Size(45, 15);
        lblPlaneSpeed.TabIndex = 24;
        lblPlaneSpeed.Text = "Speed :";
        // 
        // numPlaneBoardingTime
        // 
        numPlaneBoardingTime.Location = new Point(577, 318);
        numPlaneBoardingTime.Margin = new Padding(2);
        numPlaneBoardingTime.Name = "numPlaneBoardingTime";
        numPlaneBoardingTime.Size = new Size(50, 23);
        numPlaneBoardingTime.TabIndex = 27;
        // 
        // lblPlaneBoardingTime
        // 
        lblPlaneBoardingTime.AutoSize = true;
        lblPlaneBoardingTime.Location = new Point(481, 318);
        lblPlaneBoardingTime.Margin = new Padding(2, 0, 2, 0);
        lblPlaneBoardingTime.Name = "lblPlaneBoardingTime";
        lblPlaneBoardingTime.Size = new Size(87, 15);
        lblPlaneBoardingTime.TabIndex = 26;
        lblPlaneBoardingTime.Text = "BoardingTime :";
        lblPlaneBoardingTime.UseMnemonic = false;
        // 
        // numPlaneUnboardingTime
        // 
        numPlaneUnboardingTime.Location = new Point(743, 318);
        numPlaneUnboardingTime.Margin = new Padding(2);
        numPlaneUnboardingTime.Name = "numPlaneUnboardingTime";
        numPlaneUnboardingTime.Size = new Size(50, 23);
        numPlaneUnboardingTime.TabIndex = 29;
        // 
        // lblPlaneUnboardingTime
        // 
        lblPlaneUnboardingTime.AutoSize = true;
        lblPlaneUnboardingTime.Location = new Point(631, 318);
        lblPlaneUnboardingTime.Margin = new Padding(2, 0, 2, 0);
        lblPlaneUnboardingTime.Name = "lblPlaneUnboardingTime";
        lblPlaneUnboardingTime.Size = new Size(102, 15);
        lblPlaneUnboardingTime.TabIndex = 28;
        lblPlaneUnboardingTime.Text = "UnboardingTime :";
        lblPlaneUnboardingTime.UseMnemonic = false;
        // 
        // btnPlaneAdd
        // 
        btnPlaneAdd.Location = new Point(34, 341);
        btnPlaneAdd.Margin = new Padding(2);
        btnPlaneAdd.Name = "btnPlaneAdd";
        btnPlaneAdd.Size = new Size(940, 20);
        btnPlaneAdd.TabIndex = 30;
        btnPlaneAdd.Text = "Add";
        btnPlaneAdd.UseVisualStyleBackColor = true;
        btnPlaneAdd.Click += btnAddPlane_Click;
        // 
        // numPlaneMaintenanceTime
        // 
        numPlaneMaintenanceTime.Location = new Point(914, 319);
        numPlaneMaintenanceTime.Margin = new Padding(2);
        numPlaneMaintenanceTime.Name = "numPlaneMaintenanceTime";
        numPlaneMaintenanceTime.Size = new Size(50, 23);
        numPlaneMaintenanceTime.TabIndex = 32;
        // 
        // lblPlaneMaintenanceTime
        // 
        lblPlaneMaintenanceTime.AutoSize = true;
        lblPlaneMaintenanceTime.Location = new Point(798, 318);
        lblPlaneMaintenanceTime.Margin = new Padding(2, 0, 2, 0);
        lblPlaneMaintenanceTime.Name = "lblPlaneMaintenanceTime";
        lblPlaneMaintenanceTime.Size = new Size(108, 15);
        lblPlaneMaintenanceTime.TabIndex = 31;
        lblPlaneMaintenanceTime.Text = "MaintenanceTime :";
        lblPlaneMaintenanceTime.UseMnemonic = false;
        // 
        // lblFrequencyFire
        // 
        lblFrequencyFire.AutoSize = true;
        lblFrequencyFire.Location = new Point(34, 369);
        lblFrequencyFire.Margin = new Padding(2, 0, 2, 0);
        lblFrequencyFire.Name = "lblFrequencyFire";
        lblFrequencyFire.Size = new Size(87, 15);
        lblFrequencyFire.TabIndex = 33;
        lblFrequencyFire.Text = "FrequencyFire :";
        // 
        // numFrequencyFire
        // 
        numFrequencyFire.Location = new Point(130, 369);
        numFrequencyFire.Margin = new Padding(2);
        numFrequencyFire.Name = "numFrequencyFire";
        numFrequencyFire.Size = new Size(50, 23);
        numFrequencyFire.TabIndex = 34;
        // 
        // numFrequencyRecon
        // 
        numFrequencyRecon.Location = new Point(304, 369);
        numFrequencyRecon.Margin = new Padding(2);
        numFrequencyRecon.Name = "numFrequencyRecon";
        numFrequencyRecon.Size = new Size(50, 23);
        numFrequencyRecon.TabIndex = 36;
        // 
        // lblFrequencyRecon
        // 
        lblFrequencyRecon.AutoSize = true;
        lblFrequencyRecon.Location = new Point(195, 369);
        lblFrequencyRecon.Margin = new Padding(2, 0, 2, 0);
        lblFrequencyRecon.Name = "lblFrequencyRecon";
        lblFrequencyRecon.Size = new Size(101, 15);
        lblFrequencyRecon.TabIndex = 35;
        lblFrequencyRecon.Text = "FrequencyRecon :";
        // 
        // numFrequencyRescue
        // 
        numFrequencyRescue.Location = new Point(472, 369);
        numFrequencyRescue.Margin = new Padding(2);
        numFrequencyRescue.Name = "numFrequencyRescue";
        numFrequencyRescue.Size = new Size(50, 23);
        numFrequencyRescue.TabIndex = 38;
        // 
        // lblFrequencyRescue
        // 
        lblFrequencyRescue.AutoSize = true;
        lblFrequencyRescue.Location = new Point(359, 369);
        lblFrequencyRescue.Margin = new Padding(2, 0, 2, 0);
        lblFrequencyRescue.Name = "lblFrequencyRescue";
        lblFrequencyRescue.Size = new Size(105, 15);
        lblFrequencyRescue.TabIndex = 37;
        lblFrequencyRescue.Text = "FrequencyRescue :";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(34, 391);
        btnSave.Margin = new Padding(2);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(940, 20);
        btnSave.TabIndex = 39;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(34, 415);
        btnLoad.Margin = new Padding(2);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(940, 20);
        btnLoad.TabIndex = 40;
        btnLoad.Text = "Load";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // btnEmpty
        // 
        btnEmpty.Location = new Point(34, 439);
        btnEmpty.Margin = new Padding(2);
        btnEmpty.Name = "btnEmpty";
        btnEmpty.Size = new Size(940, 20);
        btnEmpty.TabIndex = 41;
        btnEmpty.Text = "Empty";
        btnEmpty.UseVisualStyleBackColor = true;
        btnEmpty.Click += btnEmpty_Click;
        // 
        // coordsPickerBtn
        // 
        coordsPickerBtn.Location = new Point(491, 118);
        coordsPickerBtn.Name = "coordsPickerBtn";
        coordsPickerBtn.Size = new Size(145, 23);
        coordsPickerBtn.TabIndex = 42;
        coordsPickerBtn.Text = "Open coordinate picker";
        coordsPickerBtn.UseVisualStyleBackColor = true;
        coordsPickerBtn.Click += coordsPickerBtn_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1005, 480);
        Controls.Add(coordsPickerBtn);
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
        Name = "Form1";
        Text = "Scenario Generator";
        ((System.ComponentModel.ISupportInitialize)numAirportPositionX).EndInit();
        ((System.ComponentModel.ISupportInitialize)numAirportPositionY).EndInit();
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
    private Button coordsPickerBtn;
    private ColumnHeader airportName;
    private ColumnHeader xPos;
    private ColumnHeader yPos;
    private ColumnHeader passengerTraffic;
    private ColumnHeader cargoTraffic;
    private ColumnHeader planeName;
    private ColumnHeader speed;
    private ColumnHeader boardingTime;
    private ColumnHeader unboardingTime;
    private ColumnHeader maintenanceTime;
}