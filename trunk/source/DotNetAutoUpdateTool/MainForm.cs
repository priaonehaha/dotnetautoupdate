using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNetAutoUpdate;
using System.Security.Cryptography;
using System.IO;

namespace DotNetAutoUpdateTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void browseKeyPairButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keyPairTextBox.Text = ofd.FileName;
            }
        }

        private void browseInputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputFileTextBox.Text = ofd.FileName;
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            var signatureFile = inputFileTextBox.Text + ".signature";
            var keys = UpdateKeys.FromStrongNameKey(keyPairTextBox.Text);
            keys.SignFile(inputFileTextBox.Text, signatureFile);
        }
    }
}
