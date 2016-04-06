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

namespace GEOArchive.UserControls
{
    public partial class GeoSetView : UserControl
    {
        public GeoSet CurrentSet { get; set; }

        public GeoSetView()
        {
            InitializeComponent();
        }

        public GeoSetView(GeoSet geoSet)
        {
            InitializeComponent();
            CurrentSet = geoSet;
        }

        public void Fill()
        {

        }
    }
}
