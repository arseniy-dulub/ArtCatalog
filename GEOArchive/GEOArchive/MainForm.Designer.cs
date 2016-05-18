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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddProject = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteProject = new System.Windows.Forms.ToolStripButton();
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.GeoSetBS = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.geoSetView1 = new GEOArchive.UserControls.GeoSetView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeoSetBS)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddProject,
            this.tsbDeleteProject});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddProject
            // 
            this.tsbAddProject.Image = global::GEOArchive.Properties.Resources.add;
            this.tsbAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddProject.Name = "tsbAddProject";
            this.tsbAddProject.Size = new System.Drawing.Size(79, 22);
            this.tsbAddProject.Text = "Добавить";
            // 
            // tsbDeleteProject
            // 
            this.tsbDeleteProject.Image = global::GEOArchive.Properties.Resources.del;
            this.tsbDeleteProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteProject.Name = "tsbDeleteProject";
            this.tsbDeleteProject.Size = new System.Drawing.Size(71, 22);
            this.tsbDeleteProject.Text = "Удалить";
            // 
            // lbProjects
            // 
            this.lbProjects.DataSource = this.GeoSetBS;
            this.lbProjects.DisplayMember = "GeoSetNum";
            this.lbProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.ItemHeight = 16;
            this.lbProjects.Location = new System.Drawing.Point(12, 57);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(144, 644);
            this.lbProjects.TabIndex = 2;
            this.lbProjects.ValueMember = "GeoSetId";
            // 
            // GeoSetBS
            // 
            this.GeoSetBS.DataSource = typeof(GEOArchive.Entity.GeoSet);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Проекты:";
            // 
            // geoSetView1
            // 
            this.geoSetView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geoSetView1.Location = new System.Drawing.Point(165, 41);
            this.geoSetView1.Name = "geoSetView1";
            this.geoSetView1.Size = new System.Drawing.Size(843, 677);
            this.geoSetView1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.geoSetView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProjects);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Архив проектов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeoSetBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddProject;
        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource GeoSetBS;
        private System.Windows.Forms.ToolStripButton tsbDeleteProject;
        private UserControls.GeoSetView geoSetView1;
    }
}

