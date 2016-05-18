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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoSetView));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.tbGeoSetDateCreate = new System.Windows.Forms.TextBox();
            this.tbGeoSetCreator = new System.Windows.Forms.TextBox();
            this.tbGeoSetName = new System.Windows.Forms.RichTextBox();
            this.tbGeoSetNum = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lGeoSetDateCreate = new System.Windows.Forms.Label();
            this.lGeoSetCreator = new System.Windows.Forms.Label();
            this.lGeoSetName = new System.Windows.Forms.Label();
            this.lGeoSetNum = new System.Windows.Forms.Label();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.fileIcons = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.rtbFileContains = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDowload = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAttachFiles = new System.Windows.Forms.Button();
            this.GeoSetBS = new System.Windows.Forms.BindingSource(this.components);
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeoSetBS)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.tbGeoSetDateCreate);
            this.gbInfo.Controls.Add(this.tbGeoSetCreator);
            this.gbInfo.Controls.Add(this.tbGeoSetName);
            this.gbInfo.Controls.Add(this.tbGeoSetNum);
            this.gbInfo.Controls.Add(this.tbDescription);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.lGeoSetDateCreate);
            this.gbInfo.Controls.Add(this.lGeoSetCreator);
            this.gbInfo.Controls.Add(this.lGeoSetName);
            this.gbInfo.Controls.Add(this.lGeoSetNum);
            this.gbInfo.Location = new System.Drawing.Point(3, 3);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(830, 225);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация о проекте";
            // 
            // tbGeoSetDateCreate
            // 
            this.tbGeoSetDateCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeoSetDateCreate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GeoSetBS, "GeoSetDateCreate", true));
            this.tbGeoSetDateCreate.Location = new System.Drawing.Point(128, 123);
            this.tbGeoSetDateCreate.Name = "tbGeoSetDateCreate";
            this.tbGeoSetDateCreate.Size = new System.Drawing.Size(696, 20);
            this.tbGeoSetDateCreate.TabIndex = 3;
            // 
            // tbGeoSetCreator
            // 
            this.tbGeoSetCreator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeoSetCreator.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GeoSetBS, "GeoSetCreator", true));
            this.tbGeoSetCreator.Location = new System.Drawing.Point(128, 97);
            this.tbGeoSetCreator.Name = "tbGeoSetCreator";
            this.tbGeoSetCreator.Size = new System.Drawing.Size(696, 20);
            this.tbGeoSetCreator.TabIndex = 2;
            // 
            // tbGeoSetName
            // 
            this.tbGeoSetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeoSetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGeoSetName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GeoSetBS, "GeoSetName", true));
            this.tbGeoSetName.Location = new System.Drawing.Point(128, 49);
            this.tbGeoSetName.Name = "tbGeoSetName";
            this.tbGeoSetName.Size = new System.Drawing.Size(696, 42);
            this.tbGeoSetName.TabIndex = 1;
            this.tbGeoSetName.Text = "";
            // 
            // tbGeoSetNum
            // 
            this.tbGeoSetNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeoSetNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GeoSetBS, "GeoSetNum", true));
            this.tbGeoSetNum.Location = new System.Drawing.Point(128, 23);
            this.tbGeoSetNum.Name = "tbGeoSetNum";
            this.tbGeoSetNum.Size = new System.Drawing.Size(696, 20);
            this.tbGeoSetNum.TabIndex = 0;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.BackColor = System.Drawing.SystemColors.Window;
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GeoSetBS, "Description", true));
            this.tbDescription.Location = new System.Drawing.Point(128, 147);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(696, 72);
            this.tbDescription.TabIndex = 4;
            this.tbDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Описание:";
            // 
            // lGeoSetDateCreate
            // 
            this.lGeoSetDateCreate.AutoSize = true;
            this.lGeoSetDateCreate.Location = new System.Drawing.Point(35, 122);
            this.lGeoSetDateCreate.Name = "lGeoSetDateCreate";
            this.lGeoSetDateCreate.Size = new System.Drawing.Size(87, 13);
            this.lGeoSetDateCreate.TabIndex = 3;
            this.lGeoSetDateCreate.Text = "Дата создания:";
            // 
            // lGeoSetCreator
            // 
            this.lGeoSetCreator.AutoSize = true;
            this.lGeoSetCreator.Location = new System.Drawing.Point(45, 97);
            this.lGeoSetCreator.Name = "lGeoSetCreator";
            this.lGeoSetCreator.Size = new System.Drawing.Size(77, 13);
            this.lGeoSetCreator.TabIndex = 2;
            this.lGeoSetCreator.Text = "Исполнитель:";
            // 
            // lGeoSetName
            // 
            this.lGeoSetName.AutoSize = true;
            this.lGeoSetName.Location = new System.Drawing.Point(36, 61);
            this.lGeoSetName.Name = "lGeoSetName";
            this.lGeoSetName.Size = new System.Drawing.Size(86, 13);
            this.lGeoSetName.TabIndex = 1;
            this.lGeoSetName.Text = "Наименование:";
            // 
            // lGeoSetNum
            // 
            this.lGeoSetNum.AutoSize = true;
            this.lGeoSetNum.Location = new System.Drawing.Point(57, 26);
            this.lGeoSetNum.Name = "lGeoSetNum";
            this.lGeoSetNum.Size = new System.Drawing.Size(65, 13);
            this.lGeoSetNum.TabIndex = 0;
            this.lGeoSetNum.Text = "№ проекта:";
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvFiles.LargeImageList = this.fileIcons;
            this.lvFiles.Location = new System.Drawing.Point(15, 276);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.ShowItemToolTips = true;
            this.lvFiles.Size = new System.Drawing.Size(401, 179);
            this.lvFiles.SmallImageList = this.fileIcons;
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            // 
            // fileIcons
            // 
            this.fileIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileIcons.ImageStream")));
            this.fileIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.fileIcons.Images.SetKeyName(0, "xml-file");
            this.fileIcons.Images.SetKeyName(1, "default-file");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Состав проекта:";
            // 
            // rtbFileContains
            // 
            this.rtbFileContains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFileContains.Location = new System.Drawing.Point(422, 276);
            this.rtbFileContains.Name = "rtbFileContains";
            this.rtbFileContains.ShowSelectionMargin = true;
            this.rtbFileContains.Size = new System.Drawing.Size(411, 179);
            this.rtbFileContains.TabIndex = 6;
            this.rtbFileContains.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Содержримое файла:";
            // 
            // btnDowload
            // 
            this.btnDowload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDowload.Image = global::GEOArchive.Properties.Resources.down;
            this.btnDowload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDowload.Location = new System.Drawing.Point(217, 234);
            this.btnDowload.Name = "btnDowload";
            this.btnDowload.Size = new System.Drawing.Size(95, 23);
            this.btnDowload.TabIndex = 9;
            this.btnDowload.Text = "Скачать";
            this.btnDowload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDowload.UseVisualStyleBackColor = true;
            this.btnDowload.Visible = false;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFile.Image = global::GEOArchive.Properties.Resources.crossout;
            this.btnDeleteFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFile.Location = new System.Drawing.Point(116, 234);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(95, 23);
            this.btnDeleteFile.TabIndex = 8;
            this.btnDeleteFile.Text = "Удалить";
            this.btnDeleteFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            // 
            // btnAttachFiles
            // 
            this.btnAttachFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAttachFiles.Image = global::GEOArchive.Properties.Resources.attachment;
            this.btnAttachFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttachFiles.Location = new System.Drawing.Point(15, 234);
            this.btnAttachFiles.Name = "btnAttachFiles";
            this.btnAttachFiles.Size = new System.Drawing.Size(95, 23);
            this.btnAttachFiles.TabIndex = 5;
            this.btnAttachFiles.Text = "Прикрепить";
            this.btnAttachFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttachFiles.UseVisualStyleBackColor = true;
            // 
            // GeoSetBS
            // 
            this.GeoSetBS.DataSource = typeof(GEOArchive.Entity.GeoSet);
            // 
            // GeoSetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDowload);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbFileContains);
            this.Controls.Add(this.btnAttachFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.gbInfo);
            this.Name = "GeoSetView";
            this.Size = new System.Drawing.Size(843, 464);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeoSetBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lGeoSetDateCreate;
        private System.Windows.Forms.Label lGeoSetCreator;
        private System.Windows.Forms.Label lGeoSetName;
        private System.Windows.Forms.Label lGeoSetNum;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGeoSetDateCreate;
        private System.Windows.Forms.TextBox tbGeoSetCreator;
        private System.Windows.Forms.RichTextBox tbGeoSetName;
        private System.Windows.Forms.TextBox tbGeoSetNum;
        private System.Windows.Forms.Button btnAttachFiles;
        private System.Windows.Forms.ImageList fileIcons;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.BindingSource GeoSetBS;
        private System.Windows.Forms.RichTextBox rtbFileContains;
        public System.Windows.Forms.Button btnDeleteFile;
        public System.Windows.Forms.Button btnDowload;
    }
}
