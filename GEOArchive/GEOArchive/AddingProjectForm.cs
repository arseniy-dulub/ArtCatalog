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

namespace GEOArchive
{
    public partial class AddingProjectForm : Form
    {
        public AddingProjectForm()
        {
            InitializeComponent();
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            GeoSet newSetToAdd = geoSetView1.GetCurrentGeoSet();

            if (newSetToAdd != null)
            {
                using (var db = new GeoSetContext())
                {
                    db.GeoSets.Add(newSetToAdd);
                    if (db.SaveChanges() > 0)
                    {
                        MessageBox.Show("Успешно добавлено. {id=" +
                            db.GeoSets.ToList().Last().GeoSetId +
                            ", num=" + db.GeoSets.ToList().Last().GeoSetNum + "}");

                        Close();
                    }
                }
            }
        }
    }
}
