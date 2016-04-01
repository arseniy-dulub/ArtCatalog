using GEOArchive.Db;
using GEOArchive.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEOArchive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            using (var db = new ArchiveContext())
            {
                var project = new GeoProject() { GeoProjectNum = "00000" };
                db.Projects.Add(project);
                db.SaveChanges();

                var query = from p in db.Projects
                            orderby p.GeoProjectNum
                            select p;

                foreach (var item in query)
                {
                    MessageBox.Show(item.GeoProjectNum);
                }
            }
        }
    }
}
