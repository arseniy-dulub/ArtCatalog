namespace GEOArchive.UserControls
{
    partial class GeoFileInfoView
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
            this.rtbContains = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbContains
            // 
            this.rtbContains.Location = new System.Drawing.Point(3, 3);
            this.rtbContains.Name = "rtbContains";
            this.rtbContains.Size = new System.Drawing.Size(257, 218);
            this.rtbContains.TabIndex = 0;
            this.rtbContains.Text = "";
            // 
            // GeoFileInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbContains);
            this.Name = "GeoFileInfoView";
            this.Size = new System.Drawing.Size(263, 224);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContains;
    }
}
