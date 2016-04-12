using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEOArchive.Entity;
using GEOArchive.DB;
using System.IO;
using GEOArchive.Tools;

namespace GEOArchive.UserControls
{
    public partial class GeoSetView : UserControl
    {
        OpenFileDialog ofdAttachFiles;

        public GeoSetView()
        {
            InitializeComponent();
            GeoSetBS.DataSource = new GeoSet() { Files = new List<GeoFile>() };
            btnAttachFiles.Click += BtnAttachFiles_Click;
            lvFiles.SelectedIndexChanged += LvFiles_SelectedIndexChanged;
        }


        private void BtnAttachFiles_Click(object sender, EventArgs e)
        {
            ofdAttachFiles = new OpenFileDialog();
            ofdAttachFiles.Multiselect = true;
            ofdAttachFiles.Title = "Выберите файл(ы) проекта.";
            ofdAttachFiles.FileOk += OfdAttachFiles_FileOk;
            ofdAttachFiles.ShowDialog();
        }

        private void OfdAttachFiles_FileOk(object sender, CancelEventArgs e)
        {
            int lastId;

            using (var db = new GeoSetContext())
            {
                lastId = db.GeoSets.ToList().Last().GeoSetId;
            }

            List<GeoFile> filesToAdd = new List<GeoFile>();

            foreach (var file in ofdAttachFiles.FileNames)
            {
                FileInfo pFile = new FileInfo(file);

                GeoFile newGeoFile = new GeoFile();
                newGeoFile.GeoSetId = lastId + 1;
                newGeoFile.GeoFileDateCreate = pFile.CreationTime.ToShortDateString();
                newGeoFile.GeoFilePath = pFile.FullName;
                newGeoFile.GeoFileType = pFile.Extension;
                filesToAdd.Add(newGeoFile);
                lvFiles.Items.Add(GenerateListBoxItem(newGeoFile));
            }

            (GeoSetBS.DataSource as GeoSet).Files.AddRange(filesToAdd);
            
        }

        private void LvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbFileContains.Clear();
            try {
                rtbFileContains.Text += GeoFileReader.IndentifyGeoFile(
                    ((GeoSetBS.DataSource as GeoSet).Files.Find(file =>
                            FileManager.GetFileNameWithExtensionFromPath(file.GeoFilePath) ==
                            lvFiles.SelectedItems[0].Text))
                    );
            }
            catch { }
        }

        public GeoSet GetFilledFields()
        {
            return GeoSetBS.DataSource as GeoSet;
        }

        public ListViewItem GenerateListBoxItem(GeoFile file)
        {
            ListViewItem result = new ListViewItem();

            result.Text = FileManager.GetFileNameWithExtensionFromPath(file.GeoFilePath);
            result.ToolTipText = FileManager.GetFileFullType(file);

            switch (file.GeoFileType)
            {
                case ".xgeoobj":
                    {
                        result.ImageIndex = 0;
                        break;
                    }
                case ".xgeolab":
                    {
                        result.ImageIndex = 0;
                        break;
                    }
                case ".labdata":
                    {
                        result.ImageIndex = 0;
                        break;
                    }
                case ".igelist":
                    {
                        result.ImageIndex = 0;
                        break;
                    }
                case ".cutlist":
                    {
                        result.ImageIndex = 0;
                        break;
                    }
                default:
                    {
                        result.ImageIndex = 1;
                        break;
                    }

            }

            return result;
        }
    }
}
