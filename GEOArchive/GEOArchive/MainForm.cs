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

        public MainForm()
        {
            InitializeComponent();
            tsbAddProject.Click += TsbAddProject_Click;
        }

        private void InitializeProjectList()
        {
            using (var db = new GeoSetContext())
            {
                foreach (var set in db.GeoSets)
                {
                    lbProjects.Items.Add(set);
                }
            }

            lbProjects.Refresh();
        }

        private void TsbAddProject_Click(object sender, EventArgs e)
        {
            ofdAddProject = new OpenFileDialog();
            ofdAddProject.Multiselect = true;
            ofdAddProject.Title = "GEOArchive: Выберите файлы проекта";
            ofdAddProject.FileOk += OfdAddProject_FileOk;
        }

        private void OfdAddProject_FileOk(object sender, CancelEventArgs e)
        {
            if (!ofdAddProject.FileNames.ToList().Exists(file => File)
        }
    }
}
