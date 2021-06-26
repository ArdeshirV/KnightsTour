namespace ArdeshirV.Applications.KnightsTour
{
	using ArdeshirV.Applications.KnightsTour;

    partial class FormMain
    {
        #region Variables 

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Chess_Board m_chbFirst;
        private Chess_Board m_chbNormal;
        private Chess_Board m_chbWeights;
        private Chess_Board m_chbSolution;
        private System.Windows.Forms.Button m_btnExit;
        private System.Windows.Forms.ListBox m_lstAngels;
        private System.Windows.Forms.ImageList m_imgList;
        private System.Windows.Forms.ToolTip m_ttpToolTip;
        private System.Windows.Forms.GroupBox m_grpTopSide;
        private System.Windows.Forms.ComboBox m_cmbFirstCell;
        private System.Windows.Forms.GroupBox m_grpFirstCell;
        private System.Windows.Forms.PictureBox m_picTopSide;
        private System.Windows.Forms.Button m_btnSolveStepByStep;
        private System.Windows.Forms.Button m_btnFormAbout;

        #endregion
        //-------------------------------------------------------------------------------
        #region Overrided Functions

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }*/

        #endregion
        //-------------------------------------------------------------------------------
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        	this.m_btnExit = new System.Windows.Forms.Button();
        	this.m_ttpToolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.m_cmbFirstCell = new System.Windows.Forms.ComboBox();
        	this.m_btnSolveStepByStep = new System.Windows.Forms.Button();
        	this.m_chbWeights = new ArdeshirV.Applications.KnightsTour.Chess_Board();
        	this.m_chbFirst = new ArdeshirV.Applications.KnightsTour.Chess_Board();
        	this.m_chbNormal = new ArdeshirV.Applications.KnightsTour.Chess_Board();
        	this.m_chbSolution = new ArdeshirV.Applications.KnightsTour.Chess_Board();
        	this.m_btnFormAbout = new System.Windows.Forms.Button();
        	this.m_lstAngels = new System.Windows.Forms.ListBox();
        	this.m_imgList = new System.Windows.Forms.ImageList(this.components);
        	this.m_grpTopSide = new System.Windows.Forms.GroupBox();
        	this.m_picTopSide = new System.Windows.Forms.PictureBox();
        	this.m_grpFirstCell = new System.Windows.Forms.GroupBox();
        	this.m_grpTopSide.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.m_picTopSide)).BeginInit();
        	this.m_grpFirstCell.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// m_btnExit
        	// 
        	this.m_btnExit.Location = new System.Drawing.Point(444, 326);
        	this.m_btnExit.Name = "m_btnExit";
        	this.m_btnExit.Size = new System.Drawing.Size(38, 28);
        	this.m_btnExit.TabIndex = 0;
        	this.m_btnExit.Text = "E&xit";
        	this.m_ttpToolTip.SetToolTip(this.m_btnExit, "Quit program.");
        	this.m_btnExit.UseVisualStyleBackColor = true;
        	this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
        	// 
        	// m_ttpToolTip
        	// 
        	this.m_ttpToolTip.BackColor = System.Drawing.Color.Azure;
        	this.m_ttpToolTip.ForeColor = System.Drawing.Color.DarkSlateGray;
        	this.m_ttpToolTip.IsBalloon = true;
        	// 
        	// m_cmbFirstCell
        	// 
        	this.m_cmbFirstCell.FormattingEnabled = true;
        	this.m_cmbFirstCell.Location = new System.Drawing.Point(18, 19);
        	this.m_cmbFirstCell.Name = "m_cmbFirstCell";
        	this.m_cmbFirstCell.Size = new System.Drawing.Size(70, 21);
        	this.m_cmbFirstCell.TabIndex = 0;
        	this.m_ttpToolTip.SetToolTip(this.m_cmbFirstCell, "Show Cells That Can be First Cell.");
        	this.m_cmbFirstCell.SelectedIndexChanged += new System.EventHandler(this.m_cmbFirstCell_SelectedIndexChanged);
        	// 
        	// m_btnSolveStepByStep
        	// 
        	this.m_btnSolveStepByStep.Location = new System.Drawing.Point(376, 292);
        	this.m_btnSolveStepByStep.Name = "m_btnSolveStepByStep";
        	this.m_btnSolveStepByStep.Size = new System.Drawing.Size(106, 28);
        	this.m_btnSolveStepByStep.TabIndex = 7;
        	this.m_btnSolveStepByStep.Text = "&Solve Step by Step";
        	this.m_ttpToolTip.SetToolTip(this.m_btnSolveStepByStep, "Solve\\Stop The Selected Solution Step by Step.");
        	this.m_btnSolveStepByStep.UseVisualStyleBackColor = true;
        	this.m_btnSolveStepByStep.Click += new System.EventHandler(this.m_btnSolveStepByStep_Click);
        	// 
        	// m_chbWeights
        	// 
        	this.m_chbWeights.BoardMode = ArdeshirV.Applications.KnightsTour.BoardMode.bmShowCellWeights;
        	this.m_chbWeights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_chbWeights.Location = new System.Drawing.Point(12, 186);
        	this.m_chbWeights.MinimumSize = new System.Drawing.Size(176, 168);
        	this.m_chbWeights.Name = "m_chbWeights";
        	this.m_chbWeights.Size = new System.Drawing.Size(176, 168);
        	this.m_chbWeights.TabIndex = 2;
        	this.m_ttpToolTip.SetToolTip(this.m_chbWeights, "Cell Topside Weights.");
        	// 
        	// m_chbFirst
        	// 
        	this.m_chbFirst.BoardMode = ArdeshirV.Applications.KnightsTour.BoardMode.bmWhichCellCanBeFirst;
        	this.m_chbFirst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_chbFirst.Location = new System.Drawing.Point(194, 186);
        	this.m_chbFirst.MinimumSize = new System.Drawing.Size(176, 168);
        	this.m_chbFirst.Name = "m_chbFirst";
        	this.m_chbFirst.Size = new System.Drawing.Size(176, 168);
        	this.m_chbFirst.TabIndex = 3;
        	this.m_ttpToolTip.SetToolTip(this.m_chbFirst, "Which Cell Can be First Cell?");
        	this.m_chbFirst.OnFirstCellSelect += new ArdeshirV.Applications.KnightsTour.FirstChanged(this.m_chbFirst_OnFirstCellSelect);
        	// 
        	// m_chbNormal
        	// 
        	this.m_chbNormal.BoardMode = ArdeshirV.Applications.KnightsTour.BoardMode.bmNormalChessBoard;
        	this.m_chbNormal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_chbNormal.Location = new System.Drawing.Point(12, 12);
        	this.m_chbNormal.MinimumSize = new System.Drawing.Size(176, 168);
        	this.m_chbNormal.Name = "m_chbNormal";
        	this.m_chbNormal.Size = new System.Drawing.Size(176, 168);
        	this.m_chbNormal.TabIndex = 0;
        	this.m_ttpToolTip.SetToolTip(this.m_chbNormal, "Normal Chess Board.");
        	this.m_chbNormal.OnFinishAnimate += new System.EventHandler(this.m_chbNormal_OnFinishAnimate);
        	// 
        	// m_chbSolution
        	// 
        	this.m_chbSolution.BoardMode = ArdeshirV.Applications.KnightsTour.BoardMode.bmKnightsTourSolution;
        	this.m_chbSolution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_chbSolution.Location = new System.Drawing.Point(194, 12);
        	this.m_chbSolution.MinimumSize = new System.Drawing.Size(176, 168);
        	this.m_chbSolution.Name = "m_chbSolution";
        	this.m_chbSolution.Size = new System.Drawing.Size(176, 168);
        	this.m_chbSolution.TabIndex = 1;
        	this.m_ttpToolTip.SetToolTip(this.m_chbSolution, "Horse of Chess Solution.");
        	// 
        	// m_btnFormAbout
        	// 
        	this.m_btnFormAbout.Location = new System.Drawing.Point(376, 326);
        	this.m_btnFormAbout.Name = "m_btnFormAbout";
        	this.m_btnFormAbout.Size = new System.Drawing.Size(62, 28);
        	this.m_btnFormAbout.TabIndex = 8;
        	this.m_btnFormAbout.Text = " &About...";
        	this.m_ttpToolTip.SetToolTip(this.m_btnFormAbout, "Quit program.");
        	this.m_btnFormAbout.UseVisualStyleBackColor = true;
        	this.m_btnFormAbout.Click += new System.EventHandler(this.M_btnFormAboutClick);
        	// 
        	// m_lstAngels
        	// 
        	this.m_lstAngels.FormattingEnabled = true;
        	this.m_lstAngels.Items.AddRange(new object[] {
			"X + 2, Y + 1",
			"X + 1, Y + 2",
			"X  - 1, Y + 2",
			"X  - 2, Y + 1",
			"X  - 2, Y  - 1",
			"X  - 1, Y  - 2",
			"X + 1, Y  - 2",
			"X + 2, Y  - 1"});
        	this.m_lstAngels.Location = new System.Drawing.Point(18, 19);
        	this.m_lstAngels.Name = "m_lstAngels";
        	this.m_lstAngels.Size = new System.Drawing.Size(70, 108);
        	this.m_lstAngels.TabIndex = 0;
        	this.m_lstAngels.Click += new System.EventHandler(this.m_lstAngels_SelectedIndexChanged);
        	// 
        	// m_imgList
        	// 
        	this.m_imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgList.ImageStream")));
        	this.m_imgList.TransparentColor = System.Drawing.Color.Transparent;
        	this.m_imgList.Images.SetKeyName(0, "1.bmp");
        	this.m_imgList.Images.SetKeyName(1, "2.bmp");
        	this.m_imgList.Images.SetKeyName(2, "3.bmp");
        	this.m_imgList.Images.SetKeyName(3, "4.bmp");
        	this.m_imgList.Images.SetKeyName(4, "5.bmp");
        	this.m_imgList.Images.SetKeyName(5, "6.bmp");
        	this.m_imgList.Images.SetKeyName(6, "7.bmp");
        	this.m_imgList.Images.SetKeyName(7, "8.bmp");
        	// 
        	// m_grpTopSide
        	// 
        	this.m_grpTopSide.BackColor = System.Drawing.Color.Transparent;
        	this.m_grpTopSide.Controls.Add(this.m_picTopSide);
        	this.m_grpTopSide.Controls.Add(this.m_lstAngels);
        	this.m_grpTopSide.Location = new System.Drawing.Point(376, 69);
        	this.m_grpTopSide.Name = "m_grpTopSide";
        	this.m_grpTopSide.Size = new System.Drawing.Size(106, 213);
        	this.m_grpTopSide.TabIndex = 6;
        	this.m_grpTopSide.TabStop = false;
        	this.m_grpTopSide.Text = "Select &Topside :";
        	// 
        	// m_picTopSide
        	// 
        	this.m_picTopSide.BackColor = System.Drawing.Color.Silver;
        	this.m_picTopSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_picTopSide.Location = new System.Drawing.Point(18, 133);
        	this.m_picTopSide.Name = "m_picTopSide";
        	this.m_picTopSide.Size = new System.Drawing.Size(70, 69);
        	this.m_picTopSide.TabIndex = 19;
        	this.m_picTopSide.TabStop = false;
        	// 
        	// m_grpFirstCell
        	// 
        	this.m_grpFirstCell.BackColor = System.Drawing.Color.Transparent;
        	this.m_grpFirstCell.Controls.Add(this.m_cmbFirstCell);
        	this.m_grpFirstCell.Location = new System.Drawing.Point(376, 12);
        	this.m_grpFirstCell.Name = "m_grpFirstCell";
        	this.m_grpFirstCell.Size = new System.Drawing.Size(106, 51);
        	this.m_grpFirstCell.TabIndex = 4;
        	this.m_grpFirstCell.TabStop = false;
        	this.m_grpFirstCell.Text = "Select &First Cell :";
        	// 
        	// FormMain
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(494, 366);
        	this.Controls.Add(this.m_btnFormAbout);
        	this.Controls.Add(this.m_btnSolveStepByStep);
        	this.Controls.Add(this.m_grpFirstCell);
        	this.Controls.Add(this.m_grpTopSide);
        	this.Controls.Add(this.m_chbWeights);
        	this.Controls.Add(this.m_chbFirst);
        	this.Controls.Add(this.m_chbNormal);
        	this.Controls.Add(this.m_chbSolution);
        	this.Controls.Add(this.m_btnExit);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimumSize = new System.Drawing.Size(369, 222);
        	this.Name = "FormMain";
        	this.Text = "Knight\'s Tour";
        	this.m_grpTopSide.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.m_picTopSide)).EndInit();
        	this.m_grpFirstCell.ResumeLayout(false);
        	this.ResumeLayout(false);

        }

        #endregion
    }
}

