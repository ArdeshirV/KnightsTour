
namespace ArdeshirV.Applications.KnightsTour
{
    partial class Chess_Board
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_grdEnvironment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_grdEnvironment)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grdEnvironment
            // 
            this.m_grdEnvironment.AllowUserToOrderColumns = true;
            this.m_grdEnvironment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.m_grdEnvironment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.m_grdEnvironment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grdEnvironment.ColumnHeadersVisible = false;
            this.m_grdEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grdEnvironment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.m_grdEnvironment.Location = new System.Drawing.Point(0, 0);
            this.m_grdEnvironment.Name = "m_grdEnvironment";
            this.m_grdEnvironment.ReadOnly = true;
            this.m_grdEnvironment.RowHeadersVisible = false;
            this.m_grdEnvironment.RowHeadersWidth = 20;
            this.m_grdEnvironment.RowTemplate.Height = 20;
            this.m_grdEnvironment.Size = new System.Drawing.Size(172, 164);
            this.m_grdEnvironment.TabIndex = 0;
            this.m_grdEnvironment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_grdEnvironment_CellClick);
            this.m_grdEnvironment.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.m_grdEnvironment_CellPainting);
            this.m_grdEnvironment.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_grdEnvironment_Scroll);
            // 
            // Chess_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.m_grdEnvironment);
            this.MinimumSize = new System.Drawing.Size(176, 168);
            this.Name = "Chess_Board";
            this.Size = new System.Drawing.Size(172, 164);
            ((System.ComponentModel.ISupportInitialize)(this.m_grdEnvironment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_grdEnvironment;
    }
}
