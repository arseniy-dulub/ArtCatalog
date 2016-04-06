namespace GEOArchive.UserControls
{
    partial class GeoSetView
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
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lGeoSetDateCreate = new System.Windows.Forms.Label();
            this.lGeoSetCreator = new System.Windows.Forms.Label();
            this.lGeoSetName = new System.Windows.Forms.Label();
            this.lGeoSetNum = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.geoFileInfoView1 = new GEOArchive.UserControls.GeoFileInfoView();
            this.label2 = new System.Windows.Forms.Label();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.rtbDescription);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.lGeoSetDateCreate);
            this.gbInfo.Controls.Add(this.lGeoSetCreator);
            this.gbInfo.Controls.Add(this.lGeoSetName);
            this.gbInfo.Controls.Add(this.lGeoSetNum);
            this.gbInfo.Location = new System.Drawing.Point(3, 3);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(743, 220);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация о проекте";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.BackColor = System.Drawing.SystemColors.Window;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescription.Location = new System.Drawing.Point(128, 122);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(609, 92);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Описание:";
            // 
            // lGeoSetDateCreate
            // 
            this.lGeoSetDateCreate.AutoSize = true;
            this.lGeoSetDateCreate.Location = new System.Drawing.Point(35, 97);
            this.lGeoSetDateCreate.Name = "lGeoSetDateCreate";
            this.lGeoSetDateCreate.Size = new System.Drawing.Size(87, 13);
            this.lGeoSetDateCreate.TabIndex = 3;
            this.lGeoSetDateCreate.Text = "Дата создания:";
            // 
            // lGeoSetCreator
            // 
            this.lGeoSetCreator.AutoSize = true;
            this.lGeoSetCreator.Location = new System.Drawing.Point(45, 72);
            this.lGeoSetCreator.Name = "lGeoSetCreator";
            this.lGeoSetCreator.Size = new System.Drawing.Size(77, 13);
            this.lGeoSetCreator.TabIndex = 2;
            this.lGeoSetCreator.Text = "Исполнитель:";
            // 
            // lGeoSetName
            // 
            this.lGeoSetName.AutoSize = true;
            this.lGeoSetName.Location = new System.Drawing.Point(36, 46);
            this.lGeoSetName.Name = "lGeoSetName";
            this.lGeoSetName.Size = new System.Drawing.Size(86, 13);
            this.lGeoSetName.TabIndex = 1;
            this.lGeoSetName.Text = "Наименование:";
            // 
            // lGeoSetNum
            // 
            this.lGeoSetNum.AutoSize = true;
            this.lGeoSetNum.Location = new System.Drawing.Point(57, 24);
            this.lGeoSetNum.Name = "lGeoSetNum";
            this.lGeoSetNum.Size = new System.Drawing.Size(65, 13);
            this.lGeoSetNum.TabIndex = 0;
            this.lGeoSetNum.Text = "№ проекта:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(15, 244);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(349, 192);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Состав проекта:";
            // 
            // geoFileInfoView1
            // 
            this.geoFileInfoView1.Location = new System.Drawing.Point(402, 259);
            this.geoFileInfoView1.Name = "geoFileInfoView1";
            this.geoFileInfoView1.Size = new System.Drawing.Size(264, 177);
            this.geoFileInfoView1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Содержание файла:";
            // 
            // GeoSetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.geoFileInfoView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.gbInfo);
            this.Name = "GeoSetView";
            this.Size = new System.Drawing.Size(748, 449);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lGeoSetDateCreate;
        private System.Windows.Forms.Label lGeoSetCreator;
        private System.Windows.Forms.Label lGeoSetName;
        private System.Windows.Forms.Label lGeoSetNum;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private GeoFileInfoView geoFileInfoView1;
        private System.Windows.Forms.Label label2;
    }
}
