namespace GEOArchive
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddProject = new System.Windows.Forms.ToolStripButton();
            this.geoSetView1 = new GEOArchive.UserControls.GeoSetView();
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbAttachFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddProject,
            this.tsbAttachFiles});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddProject
            // 
            this.tsbAddProject.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddProject.Image")));
            this.tsbAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddProject.Name = "tsbAddProject";
            this.tsbAddProject.Size = new System.Drawing.Size(104, 35);
            this.tsbAddProject.Text = "Добавить проект";
            this.tsbAddProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // geoSetView1
            // 
            this.geoSetView1.Location = new System.Drawing.Point(260, 41);
            this.geoSetView1.Name = "geoSetView1";
            this.geoSetView1.Size = new System.Drawing.Size(748, 449);
            this.geoSetView1.TabIndex = 1;
            // 
            // lbProjects
            // 
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.Location = new System.Drawing.Point(12, 57);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(144, 407);
            this.lbProjects.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Проекты:";
            // 
            // tsbAttachFiles
            // 
            this.tsbAttachFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbAttachFiles.Image")));
            this.tsbAttachFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAttachFiles.Name = "tsbAttachFiles";
            this.tsbAttachFiles.Size = new System.Drawing.Size(127, 35);
            this.tsbAttachFiles.Text = "Прикрепить файл(ы)";
            this.tsbAttachFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAttachFiles.ToolTipText = "Прикрепить файл(ы)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProjects);
            this.Controls.Add(this.geoSetView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Архив проектов";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddProject;
        private UserControls.GeoSetView geoSetView1;
        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbAttachFiles;
    }
}

