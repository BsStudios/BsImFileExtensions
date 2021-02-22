using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BsImFileExtensions
{
    public partial class SaveConfig : Form
    {
        public SaveConfig()
        {
            InitializeComponent();
        }

        public int imageWidth = 0;
        public int imageHeight = 0;
        public int intbitDepth = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bitDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bitDepth.SelectedIndex == 0)
            {
                intbitDepth = 32;
            }
            else if (bitDepth.SelectedIndex == 1)
            {
                intbitDepth = 24;
            }
        }

        private void SaveConfig_Load(object sender, EventArgs e)
        {
            resolutionLabel.Text = $"{imageWidth} x {imageHeight}";


            if(intbitDepth == 32)
            {
                fileSize.Text = $"{Math.Truncate((imageHeight * imageWidth * 4.0f + 16) / 1024.0f * 100)/100} KB";
            }
            else if(intbitDepth == 24) {
                fileSize.Text = $"{Math.Truncate((imageHeight * imageWidth * 3.0f + 16) / 1024.0f * 100) / 100} KB";
            }
        }
    }
}
