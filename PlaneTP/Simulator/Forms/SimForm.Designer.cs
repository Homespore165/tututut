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
        ((System.ComponentModel.ISupportInitialize)mapImage).BeginInit();
        SuspendLayout();
        // 
        // mapImage
        // 
        mapImage.Image = Properties.Resources.world_map;
        mapImage.Location = new Point(12, 12);
        mapImage.Name = "mapImage";
        mapImage.Size = new Size(1000, 500);
        mapImage.SizeMode = PictureBoxSizeMode.StretchImage;
        mapImage.TabIndex = 0;
        mapImage.TabStop = false;
        // 
        // SimForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1024, 529);
        Controls.Add(mapImage);
        Name = "SimForm";
        Text = "Simulateur";
        ((System.ComponentModel.ISupportInitialize)mapImage).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox mapImage;
}