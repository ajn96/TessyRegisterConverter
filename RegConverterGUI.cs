using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TessyRegisterConverter
{
    public partial class RegConverterGUI : Form
    {
        private Thread workerThread;

        public RegConverterGUI()
        {
            InitializeComponent();
            SourcePath.Click += SourcePath_Clicked;
            DestPath.Click += DestPath_Clicked;
            SizeChanged += this_SizeChanged;
        }

        private void bnt_Convert_Click(object sender, EventArgs e)
        {
            workerThread = new Thread(convertWork);
            workerThread.Start();
        }

        private void convertWork()
        {
            RegisterConverter converter = new RegisterConverter();
            btn_Convert.Invoke((MethodInvoker)delegate { btn_Convert.Enabled = false; });
            try
            {
                converter.Convert(SourcePath.Text, DestPath.Text, replaceExisting.Checked);
            }
            catch(Exception e)
            {
                MessageBox.Show("An error occurred while converting: " + e.Message);
            }
            btn_Convert.Invoke((MethodInvoker)delegate { btn_Convert.Enabled = true; });
            MessageBox.Show("Converted " + converter.NumReplacements.ToString() + " registers!");
        }

        private void SourcePath_Clicked(object sender, EventArgs e)
        {
            OpenFileDialog filePath = new OpenFileDialog();
            filePath.Filter = "Header Files|*.h|All Files|*.*";
            if (filePath.ShowDialog() != DialogResult.OK)
                return;
            SourcePath.Text = filePath.FileName;
        }

        private void DestPath_Clicked(object sender, EventArgs e)
        {
            SaveFileDialog savePath = new SaveFileDialog();
            savePath.Filter = "Header Files|*.h|All Files|*.*";
            if (savePath.ShowDialog() != DialogResult.OK)
                return;
            DestPath.Text = savePath.FileName;
        }

        private void this_SizeChanged(object sender, EventArgs e)
        {
            SourcePath.Width = this.Width - (109);
            DestPath.Width = this.Width - (109);
        }
    }
}
