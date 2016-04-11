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

            InitializeProjectList();
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
            addingProjectForm.ShowDialog(this);
        }
    }
}
