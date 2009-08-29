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
using System.Xml.Linq;
using System.Xml;

namespace DotNetAutoUpdateTool
{
    public partial class MainForm : Form
    {
        UpdateKeys updateKeys;

        public MainForm()
        {
            InitializeComponent();
        }

        private void browseKeyPairButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Strong name key files (*.snk)|*.snk|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keyPairTextBox.Text = ofd.FileName;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                updateKeys = UpdateKeys.FromStrongNameKey(keyPairTextBox.Text);

                var rsaParams = updateKeys.RSA.ExportParameters(false);
                var text = new StringBuilder();
                text.Append(rsaParams.Modulus.ToHexString());
                keyTextBox.Text = text.ToString();

                signButton.Enabled = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "Error loading key: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                signButton.Enabled = false;
            }
        }

        private void browseInputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputFileTextBox.Text = ofd.FileName;
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            var signatureFile = inputFileTextBox.Text + ".signature";
            updateKeys.SignFile(inputFileTextBox.Text, signatureFile);
        }

        private void saveManifestButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "XML files (*.xml)|*.snk|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, GetManifestXml(), Encoding.Unicode);

                var signatureFile = sfd.FileName + ".signature";
                updateKeys.SignFile(sfd.FileName, signatureFile);
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            manifestTextBox.Text = GetManifestXml();

            clientCodeTextBox.Text = string.Format(ClientCodeFormat,
                versionTextBox.Text,
                updateUrlTextBox.Text,
                GetPublicKeyForCode());
        }

        private string GetManifestXml()
        {
            var xml = new XElement("Updates",
                    new XElement("Update",
                        new XAttribute("NewVersion", versionTextBox.Text),
                        new XAttribute("UpdateFileUri", updateUrlTextBox.Text),
                        new XAttribute("UpdateInfoUri", updateInfoTextBox.Text),
                        new XAttribute("Categories", categoriesTextBox.Text),
                        new XElement("Description", descriptionTextBox.Text)
                    )
                );

            var writerSettings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "  ",
                    NewLineHandling = NewLineHandling.None,
                    NewLineChars = "\r\n",
                    NewLineOnAttributes = true
                };

            var textWriter = new StringWriter();

            using (var xmlWriter = XmlWriter.Create(textWriter, writerSettings))
            {
                xml.WriteTo(xmlWriter);
            }

            return textWriter.ToString();
        }

        private string GetPublicKeyForCode()
        {
            if (updateKeys == null)
            {
                return "No key loaded!";
            }

            return updateKeys.PublicKey
                .Select(b => string.Format("0x{0:x2}", b))
                .Aggregate((a, b) => a + "," + b);
        }

        public const string ClientCodeFormat =             
            "UpdateSettings updateSettings = new UpdateSettings(); \r\n" +
            "updateSettings.CurrentVersion = new Version(\"{0}\"); \r\n" + 
            "updateSettings.UpdatePath = new Uri(\"{1}\"); \r\n" + 
            "updateSettings.UpdateKeys = UpdateKeys.FromPublicKey(new byte[] {{ {2} }});";
    }
}
