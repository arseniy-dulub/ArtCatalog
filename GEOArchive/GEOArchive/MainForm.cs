using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEOArchive.Entity;
using GEOArchive.DB;
using System.Data.Entity;
using GEOArchive.Tools;

namespace GEOArchive
{
    public partial class MainForm : Form
    {
        private OpenFileDialog ofdAddProject = new OpenFileDialog();
        private AddingProjectForm addingProjectForm;

        public MainForm()
        {
            InitializeComponent();
            tsbAddProject.Click += TsbAddProject_Click;
            tsbAttachFiles.Click += TsbAttachFiles_Click;

            InitializeProjectList();
        }

        private void InitializeProjectList()
        {
            using (var db = new GeoSetContext())
            {
                lbProjects.Items.Clear();

                foreach (var set in db.GeoSets)
                {
                    lbProjects.Items.Add(set);
                }
            }

            lbProjects.Refresh();
        }

        private void TsbAddProject_Click(object sender, EventArgs e)
        {
            addingProjectForm = new AddingProjectForm();
            addingProjectForm.Text = "Добавление нового проекта";
            addingProjectForm.FormClosed += AddingProjectForm_FormClosed;
            addingProjectForm.btnOK.Click += AddingProjectForm_BtnOK_Click;
            addingProjectForm.ShowDialog(this);
        }

        private void AddingProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitializeProjectList();
        }

        private void AddingProjectForm_BtnOK_Click(object sender, EventArgs e)
        {
            if (addingProjectForm.tbGeoSetNum.Text != string.Empty)
            {
                GeoSet geoSet = new GeoSet();
                geoSet.GeoSetNum = addingProjectForm.tbGeoSetNum.Text;
                if (addingProjectForm.lbFiles.Items.Count > 0)
                {

                }

                using (var db = new GeoSetContext())
                {
                    db.GeoSets.Add(geoSet);
                    db.SaveChanges();
                }

                addingProjectForm.Close();
            }
            else MessageBox.Show("Не указан № проекта. Введите номер.", 
                "GEOArchive: Ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TsbAttachFiles_Click(object sender, EventArgs e)
        {
            ofdAddProject = new OpenFileDialog();
            ofdAddProject.Multiselect = true;
            ofdAddProject.Title = "GEOArchive: Выберите файлы проекта";
            ofdAddProject.FileOk += OfdAddProject_FileOk;
        }


        private void OfdAddProject_FileOk(object sender, CancelEventArgs e)
        {
            // Если набор файлов не содержит
            if (!ofdAddProject.FileNames.ToList().Exists(file => FileManager.GetFileExtension(file) == ".xgeoobj"))
            {

            }
        }
    }
}
