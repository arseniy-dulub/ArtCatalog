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
            GeoSetBS.DataSource = new GeoSet();
            btnAttachFiles.Click += BtnAttachFiles_Click;
            btnDeleteFile.Click += BtnDeleteFile_Click;
            lvFiles.SelectedIndexChanged += LvFiles_SelectedIndexChanged;
            GeoSetBS.CurrentChanged += GeoSetBS_CurrentChanged;
        }       

        private void GeoSetBS_CurrentChanged(object sender, EventArgs e)
        {
            rtbFileContains.Clear();
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
            List<GeoFile> FilesToAdd = FileManager.GenarateGeoFileList(ofdAttachFiles.FileNames);

            if (Parent.GetType() == typeof(AddingProjectForm))
            {
                (GeoSetBS.DataSource as GeoSet).Files = new List<GeoFile>();
                (GeoSetBS.DataSource as GeoSet).Files.AddRange(FilesToAdd);
                AddFilesToListBox(FilesToAdd);
            }
            else if (Parent.GetType() == typeof(MainForm))
            {
                using (var db = new GeoSetContext())
                {
                    db.GeoSets.Find((GeoSetBS.DataSource as GeoSet).GeoSetId).Files.AddRange(FilesToAdd);
                    db.SaveChanges();
                    AddFilesToListBox(FilesToAdd);
                }
            }            
        }

        private void BtnDeleteFile_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                if (lvFiles.SelectedItems[0].Focused)
                {
                    GeoSet currentSet;

                    using (var db = new GeoSetContext())
                    {
                        currentSet = db.GeoSets.Find((GeoSetBS.DataSource as GeoSet).GeoSetId);

                        if (currentSet != null)
                        {
                            GeoFile currentFile = currentSet.Files.Find(file =>
                                    FileManager.GetFileNameWithExtensionFromPath(file.GeoFilePath) ==
                                    lvFiles.SelectedItems[0].Text);

                            DialogResult dr = MessageBox.Show("Вы дейсвительно ходите удалить " +
                                FileManager.GetFileNameWithExtensionFromPath(currentFile.GeoFilePath) + "?",
                                "GEOArchive: Удаление файла",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            if (dr == DialogResult.Yes)
                            {
                                db.GeoFiles.Remove(currentFile);
                                db.SaveChanges();
                                lvFiles.Items.Remove(lvFiles.SelectedItems[0]);
                            }
                        }
                    }
                }
                else MessageBox.Show("Файл не выбран.", "GEOArchive: Удаление файла",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void AddFilesToListBox(IEnumerable<GeoFile> files)
        {
            foreach (var file in files)
            {
                lvFiles.Items.Add(GenerateListBoxItem(file));
            }
        }

        private void LvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbFileContains.Clear();
            try
            {
                GeoSet currentSet;

                using (var db = new GeoSetContext())
                {
                    currentSet = db.GeoSets.Find((GeoSetBS.DataSource as GeoSet).GeoSetId);

                    if (currentSet != null)
                    rtbFileContains.Text += GeoFileReader.IndentifyGeoFile(
                        (currentSet.Files.Find(file =>
                                FileManager.GetFileNameWithExtensionFromPath(file.GeoFilePath) ==
                                lvFiles.SelectedItems[0].Text))
                        );
                }
            }
            catch { }
        }

        public GeoSet GetCurrentGeoSet()
        {
            return GeoSetBS.DataSource as GeoSet;
        }

        public ListViewItem GenerateListBoxItem(GeoFile file)
        {
            ListViewItem result = new ListViewItem();

            result.Text = FileManager.GetFileNameWithExtensionFromPath(file.GeoFilePath);
            result.ToolTipText = FileManager.GetFileFullType(file);

            List<string> fileExts = new List<string>(){".xgeoobj",".xgeolab", ".labdata",".igelist",".cutlist"};

            if (fileExts.Contains(file.GeoFileType))
                result.ImageIndex = 0;
            else result.ImageIndex = 1;           

            return result;
        }

        public void Fill(GeoSet currentGeoSet)
        {
            GeoSetBS.DataSource = currentGeoSet;
            lvFiles.Clear();
            using (var db = new GeoSetContext())
            {
                AddFilesToListBox(db.GeoFiles.Where(file => file.GeoSetId == currentGeoSet.GeoSetId));
            }
        }
    }
}
