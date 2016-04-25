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
            tsbDeleteProject.Click += TsbDeleteProject_Click;

            GeoSetBS.CurrentChanged += GeoSetBS_CurrentChanged;

            InitializeProjectList();
        }

        private void TsbDeleteProject_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить проект №" + (GeoSetBS.Current as GeoSet).GeoSetNum + "?",
                "GEOArchive: Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                using (var db = new GeoSetContext())
                {             
                    db.GeoSets.Remove(db.GeoSets.Find((GeoSetBS.Current as GeoSet).GeoSetId));
                    db.SaveChanges();                   
                }

                InitializeProjectList();
            }
        }

        private void GeoSetBS_CurrentChanged(object sender, EventArgs e)
        {
            geoSetView1.Fill(GeoSetBS.Current as GeoSet);
        }

        private void InitializeProjectList()
        {
            using (var db = new GeoSetContext())
            {
                GeoSetBS.DataSource = db.GeoSets.ToList();
            }
        }

        private void TsbAddProject_Click(object sender, EventArgs e)
        {
            addingProjectForm = new AddingProjectForm();
            addingProjectForm.Text = "Добавление нового проекта";
            addingProjectForm.FormClosed += AddingProjectForm_FormClosed;
            addingProjectForm.ShowDialog(this);
        }

        private void AddingProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitializeProjectList();
        }
    }
}
