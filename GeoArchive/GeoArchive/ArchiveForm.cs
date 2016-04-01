using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoArchive.Tools;

namespace GeoArchive
{
    public partial class ArchiveForm : Form
    {
        OpenFileDialog ofd;
        GeoProjectManager manager = new GeoProjectManager(); 

        public ArchiveForm()
        {
            InitializeComponent();

            this.tsbAttachNew.Click += tsbAttachNew_Click;
        }

        void tsbAttachNew_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.FileOk += ofd_FileOk;
            ofd.ShowDialog(this);
        }

        void ofd_FileOk(object sender, CancelEventArgs e)
        {
            string result = string.Empty;
            foreach (var fileName in ofd.FileNames)
            {
                result += fileName + '\n';
            }

            if (manager.Create(result, ofd.FileNames.First()))
            {
                MessageBox.Show("Добавлено успешно.", "Добавление нового проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не добавлено.", "Добавление нового проекта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
