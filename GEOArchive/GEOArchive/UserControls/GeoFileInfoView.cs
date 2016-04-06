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
using GEOArchive.Tools;

namespace GEOArchive.UserControls
{
    public partial class GeoFileInfoView : UserControl
    {
        public GeoFile CurrentFile { get; set; }

        public GeoFileInfoView()
        {
            InitializeComponent();
        }

        public GeoFileInfoView(GeoFile file)
        {
            InitializeComponent();
            CurrentFile = file;
        }

        public void Fill()
        {
            if (CurrentFile != null && CurrentFile != new GeoFile())
            { 
                string filename = FileManager.GetFileNameWithExtensionFromPath(CurrentFile.GeoFilePath);

                string contains = string.Empty;
                contains =
                    @"Файл: " + filename + '\n' +
                    @"Тип: " + FileManager.GetFileFullType(CurrentFile) + '\n' +
                    @"Дата создания: " + CurrentFile.GeoFileDateCreate + '\n' +
                    @"Содержание: " + '\n'
                ;

                this.rtbContains.Clear();
                this.rtbContains.Text = contains;
            }
        }
    }
}
