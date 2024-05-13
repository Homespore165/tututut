namespace ScenarioGenerator
{
    partial class CoordsPickerForm
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
            worldMap = new PictureBox();
            coordsLabel = new Label();
            posLabel = new Label();
            debugLabel = new Label();
            closeBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)worldMap).BeginInit();
            SuspendLayout();
            // 
            // worldMap
            // 
            worldMap.Image = Properties.Resources.world_map;
            worldMap.Location = new Point(2, 1);
            worldMap.Name = "worldMap";
            worldMap.Size = new Size(786, 395);
            worldMap.SizeMode = PictureBoxSizeMode.Zoom;
            worldMap.TabIndex = 0;
            worldMap.TabStop = false;
            worldMap.Click += worldMap_Click;
            worldMap.Paint += worldMap_Paint;
            // 
            // coordsLabel
            // 
            coordsLabel.AutoSize = true;
            coordsLabel.Location = new Point(202, 415);
            coordsLabel.Name = "coordsLabel";
            coordsLabel.Size = new Size(131, 15);
            coordsLabel.TabIndex = 1;
            coordsLabel.Text = "Coordinates: 0° N, 0° W";
            // 
            // posLabel
            // 
            posLabel.AutoSize = true;
            posLabel.Location = new Point(447, 415);
            posLabel.Name = "posLabel";
            posLabel.Size = new Size(88, 15);
            posLabel.TabIndex = 2;
            posLabel.Text = "Position: 0X, 0Y";
            // 
            // debugLabel
            // 
            debugLabel.AutoSize = true;
            debugLabel.Location = new Point(2, 434);
            debugLabel.Name = "debugLabel";
            debugLabel.Size = new Size(57, 15);
            debugLabel.TabIndex = 3;
            debugLabel.Text = "<debug>";
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(683, 411);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(75, 23);
            closeBtn.TabIndex = 4;
            closeBtn.Text = "Done";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // CoordsPickerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 450);
            Controls.Add(closeBtn);
            Controls.Add(debugLabel);
            Controls.Add(posLabel);
            Controls.Add(coordsLabel);
            Controls.Add(worldMap);
            Cursor = Cursors.Cross;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CoordsPickerForm";
            ShowIcon = false;
            Text = "Coordinate Picker";
            ((System.ComponentModel.ISupportInitialize)worldMap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox worldMap;
        private Label coordsLabel;
        private Label posLabel;
        private Label debugLabel;
        private Button closeBtn;
    }
}