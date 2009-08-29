namespace DotNetAutoUpdateTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.updateSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.updateInfoLabel = new System.Windows.Forms.Label();
            this.updateInfoTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.categoriesLabel = new System.Windows.Forms.Label();
            this.categoriesTextBox = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.updateUrlLabel = new System.Windows.Forms.Label();
            this.updateUrlTextBox = new System.Windows.Forms.TextBox();
            this.signingGroupBox = new System.Windows.Forms.GroupBox();
            this.keyPairTextBox = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.keyPairLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.browseKeyPairButton = new System.Windows.Forms.Button();
            this.keyDetailsLabel = new System.Windows.Forms.Label();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.signButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.browseInputFileButton = new System.Windows.Forms.Button();
            this.manifestTab = new System.Windows.Forms.TabPage();
            this.saveManifestButton = new System.Windows.Forms.Button();
            this.manifestLabel = new System.Windows.Forms.Label();
            this.manifestTextBox = new System.Windows.Forms.TextBox();
            this.clientCodeTab = new System.Windows.Forms.TabPage();
            this.clientCodeLabel = new System.Windows.Forms.Label();
            this.clientCodeTextBox = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.updateSettingsGroupBox.SuspendLayout();
            this.signingGroupBox.SuspendLayout();
            this.manifestTab.SuspendLayout();
            this.clientCodeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Controls.Add(this.manifestTab);
            this.tabControl.Controls.Add(this.clientCodeTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(621, 482);
            this.tabControl.TabIndex = 15;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.updateSettingsGroupBox);
            this.settingsTab.Controls.Add(this.signingGroupBox);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(613, 456);
            this.settingsTab.TabIndex = 0;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // updateSettingsGroupBox
            // 
            this.updateSettingsGroupBox.Controls.Add(this.updateInfoLabel);
            this.updateSettingsGroupBox.Controls.Add(this.updateInfoTextBox);
            this.updateSettingsGroupBox.Controls.Add(this.descriptionTextBox);
            this.updateSettingsGroupBox.Controls.Add(this.descriptionLabel);
            this.updateSettingsGroupBox.Controls.Add(this.categoriesLabel);
            this.updateSettingsGroupBox.Controls.Add(this.categoriesTextBox);
            this.updateSettingsGroupBox.Controls.Add(this.versionLabel);
            this.updateSettingsGroupBox.Controls.Add(this.versionTextBox);
            this.updateSettingsGroupBox.Controls.Add(this.updateUrlLabel);
            this.updateSettingsGroupBox.Controls.Add(this.updateUrlTextBox);
            this.updateSettingsGroupBox.Location = new System.Drawing.Point(8, 194);
            this.updateSettingsGroupBox.Name = "updateSettingsGroupBox";
            this.updateSettingsGroupBox.Size = new System.Drawing.Size(597, 253);
            this.updateSettingsGroupBox.TabIndex = 26;
            this.updateSettingsGroupBox.TabStop = false;
            this.updateSettingsGroupBox.Text = "Update Settings";
            // 
            // updateInfoLabel
            // 
            this.updateInfoLabel.AutoSize = true;
            this.updateInfoLabel.Location = new System.Drawing.Point(8, 183);
            this.updateInfoLabel.Name = "updateInfoLabel";
            this.updateInfoLabel.Size = new System.Drawing.Size(66, 13);
            this.updateInfoLabel.TabIndex = 27;
            this.updateInfoLabel.Text = "Update Info:";
            // 
            // updateInfoTextBox
            // 
            this.updateInfoTextBox.Location = new System.Drawing.Point(80, 180);
            this.updateInfoTextBox.Name = "updateInfoTextBox";
            this.updateInfoTextBox.Size = new System.Drawing.Size(511, 20);
            this.updateInfoTextBox.TabIndex = 28;
            this.updateInfoTextBox.Text = "http://some.tld/update-info.html";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(80, 106);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(511, 68);
            this.descriptionTextBox.TabIndex = 26;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(11, 115);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 25;
            this.descriptionLabel.Text = "Description:";
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Location = new System.Drawing.Point(10, 83);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(60, 13);
            this.categoriesLabel.TabIndex = 24;
            this.categoriesLabel.Text = "Categories:";
            // 
            // categoriesTextBox
            // 
            this.categoriesTextBox.Location = new System.Drawing.Point(80, 80);
            this.categoriesTextBox.Name = "categoriesTextBox";
            this.categoriesTextBox.Size = new System.Drawing.Size(511, 20);
            this.categoriesTextBox.TabIndex = 25;
            this.categoriesTextBox.Text = "Stable, x86, etc";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(0, 57);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(70, 13);
            this.versionLabel.TabIndex = 22;
            this.versionLabel.Text = "New Version:";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(80, 54);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(160, 20);
            this.versionTextBox.TabIndex = 23;
            this.versionTextBox.Text = "1.0.0.0";
            // 
            // updateUrlLabel
            // 
            this.updateUrlLabel.AutoSize = true;
            this.updateUrlLabel.Location = new System.Drawing.Point(13, 31);
            this.updateUrlLabel.Name = "updateUrlLabel";
            this.updateUrlLabel.Size = new System.Drawing.Size(61, 13);
            this.updateUrlLabel.TabIndex = 20;
            this.updateUrlLabel.Text = "Update Url:";
            // 
            // updateUrlTextBox
            // 
            this.updateUrlTextBox.Location = new System.Drawing.Point(80, 28);
            this.updateUrlTextBox.Name = "updateUrlTextBox";
            this.updateUrlTextBox.Size = new System.Drawing.Size(511, 20);
            this.updateUrlTextBox.TabIndex = 21;
            this.updateUrlTextBox.Text = "http://some.tld/update.xml";
            // 
            // signingGroupBox
            // 
            this.signingGroupBox.Controls.Add(this.keyPairTextBox);
            this.signingGroupBox.Controls.Add(this.loadButton);
            this.signingGroupBox.Controls.Add(this.keyPairLabel);
            this.signingGroupBox.Controls.Add(this.keyTextBox);
            this.signingGroupBox.Controls.Add(this.browseKeyPairButton);
            this.signingGroupBox.Controls.Add(this.keyDetailsLabel);
            this.signingGroupBox.Controls.Add(this.inputFileLabel);
            this.signingGroupBox.Controls.Add(this.signButton);
            this.signingGroupBox.Controls.Add(this.inputFileTextBox);
            this.signingGroupBox.Controls.Add(this.browseInputFileButton);
            this.signingGroupBox.Location = new System.Drawing.Point(8, 6);
            this.signingGroupBox.Name = "signingGroupBox";
            this.signingGroupBox.Size = new System.Drawing.Size(597, 182);
            this.signingGroupBox.TabIndex = 25;
            this.signingGroupBox.TabStop = false;
            this.signingGroupBox.Text = "Keys and Signing";
            // 
            // keyPairTextBox
            // 
            this.keyPairTextBox.Location = new System.Drawing.Point(80, 19);
            this.keyPairTextBox.Name = "keyPairTextBox";
            this.keyPairTextBox.Size = new System.Drawing.Size(386, 20);
            this.keyPairTextBox.TabIndex = 16;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(509, 16);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(82, 23);
            this.loadButton.TabIndex = 24;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // keyPairLabel
            // 
            this.keyPairLabel.AutoSize = true;
            this.keyPairLabel.Location = new System.Drawing.Point(21, 22);
            this.keyPairLabel.Name = "keyPairLabel";
            this.keyPairLabel.Size = new System.Drawing.Size(49, 13);
            this.keyPairLabel.TabIndex = 15;
            this.keyPairLabel.Text = "Key Pair:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyTextBox.Location = new System.Drawing.Point(80, 46);
            this.keyTextBox.Multiline = true;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.ReadOnly = true;
            this.keyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keyTextBox.Size = new System.Drawing.Size(511, 68);
            this.keyTextBox.TabIndex = 23;
            // 
            // browseKeyPairButton
            // 
            this.browseKeyPairButton.Location = new System.Drawing.Point(472, 17);
            this.browseKeyPairButton.Name = "browseKeyPairButton";
            this.browseKeyPairButton.Size = new System.Drawing.Size(31, 23);
            this.browseKeyPairButton.TabIndex = 17;
            this.browseKeyPairButton.Text = "...";
            this.browseKeyPairButton.UseVisualStyleBackColor = true;
            this.browseKeyPairButton.Click += new System.EventHandler(this.browseKeyPairButton_Click);
            // 
            // keyDetailsLabel
            // 
            this.keyDetailsLabel.AutoSize = true;
            this.keyDetailsLabel.Location = new System.Drawing.Point(42, 55);
            this.keyDetailsLabel.Name = "keyDetailsLabel";
            this.keyDetailsLabel.Size = new System.Drawing.Size(28, 13);
            this.keyDetailsLabel.TabIndex = 22;
            this.keyDetailsLabel.Text = "Key:";
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(21, 123);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(53, 13);
            this.inputFileLabel.TabIndex = 18;
            this.inputFileLabel.Text = "Input File:";
            // 
            // signButton
            // 
            this.signButton.Enabled = false;
            this.signButton.Location = new System.Drawing.Point(509, 118);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(82, 23);
            this.signButton.TabIndex = 21;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(80, 120);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(386, 20);
            this.inputFileTextBox.TabIndex = 19;
            // 
            // browseInputFileButton
            // 
            this.browseInputFileButton.Location = new System.Drawing.Point(472, 118);
            this.browseInputFileButton.Name = "browseInputFileButton";
            this.browseInputFileButton.Size = new System.Drawing.Size(31, 23);
            this.browseInputFileButton.TabIndex = 20;
            this.browseInputFileButton.Text = "...";
            this.browseInputFileButton.UseVisualStyleBackColor = true;
            this.browseInputFileButton.Click += new System.EventHandler(this.browseInputFileButton_Click);
            // 
            // manifestTab
            // 
            this.manifestTab.Controls.Add(this.saveManifestButton);
            this.manifestTab.Controls.Add(this.manifestLabel);
            this.manifestTab.Controls.Add(this.manifestTextBox);
            this.manifestTab.Location = new System.Drawing.Point(4, 22);
            this.manifestTab.Name = "manifestTab";
            this.manifestTab.Padding = new System.Windows.Forms.Padding(3);
            this.manifestTab.Size = new System.Drawing.Size(613, 456);
            this.manifestTab.TabIndex = 1;
            this.manifestTab.Text = "Manifest";
            this.manifestTab.UseVisualStyleBackColor = true;
            // 
            // saveManifestButton
            // 
            this.saveManifestButton.Location = new System.Drawing.Point(97, 419);
            this.saveManifestButton.Name = "saveManifestButton";
            this.saveManifestButton.Size = new System.Drawing.Size(75, 23);
            this.saveManifestButton.TabIndex = 14;
            this.saveManifestButton.Text = "Save";
            this.saveManifestButton.UseVisualStyleBackColor = true;
            this.saveManifestButton.Click += new System.EventHandler(this.saveManifestButton_Click);
            // 
            // manifestLabel
            // 
            this.manifestLabel.AutoSize = true;
            this.manifestLabel.Location = new System.Drawing.Point(3, 9);
            this.manifestLabel.Name = "manifestLabel";
            this.manifestLabel.Size = new System.Drawing.Size(88, 13);
            this.manifestLabel.TabIndex = 13;
            this.manifestLabel.Text = "Update Manifest:";
            // 
            // manifestTextBox
            // 
            this.manifestTextBox.Location = new System.Drawing.Point(97, 6);
            this.manifestTextBox.Multiline = true;
            this.manifestTextBox.Name = "manifestTextBox";
            this.manifestTextBox.ReadOnly = true;
            this.manifestTextBox.Size = new System.Drawing.Size(508, 406);
            this.manifestTextBox.TabIndex = 12;
            // 
            // clientCodeTab
            // 
            this.clientCodeTab.Controls.Add(this.clientCodeLabel);
            this.clientCodeTab.Controls.Add(this.clientCodeTextBox);
            this.clientCodeTab.Location = new System.Drawing.Point(4, 22);
            this.clientCodeTab.Name = "clientCodeTab";
            this.clientCodeTab.Padding = new System.Windows.Forms.Padding(3);
            this.clientCodeTab.Size = new System.Drawing.Size(613, 456);
            this.clientCodeTab.TabIndex = 2;
            this.clientCodeTab.Text = "Client Code";
            this.clientCodeTab.UseVisualStyleBackColor = true;
            // 
            // clientCodeLabel
            // 
            this.clientCodeLabel.AutoSize = true;
            this.clientCodeLabel.Location = new System.Drawing.Point(19, 9);
            this.clientCodeLabel.Name = "clientCodeLabel";
            this.clientCodeLabel.Size = new System.Drawing.Size(63, 13);
            this.clientCodeLabel.TabIndex = 11;
            this.clientCodeLabel.Text = "Client code:";
            // 
            // clientCodeTextBox
            // 
            this.clientCodeTextBox.Location = new System.Drawing.Point(88, 6);
            this.clientCodeTextBox.Multiline = true;
            this.clientCodeTextBox.Name = "clientCodeTextBox";
            this.clientCodeTextBox.ReadOnly = true;
            this.clientCodeTextBox.Size = new System.Drawing.Size(517, 442);
            this.clientCodeTextBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 482);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Dot Net Auto Update Tool";
            this.tabControl.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.updateSettingsGroupBox.ResumeLayout(false);
            this.updateSettingsGroupBox.PerformLayout();
            this.signingGroupBox.ResumeLayout(false);
            this.signingGroupBox.PerformLayout();
            this.manifestTab.ResumeLayout(false);
            this.manifestTab.PerformLayout();
            this.clientCodeTab.ResumeLayout(false);
            this.clientCodeTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label keyDetailsLabel;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button browseInputFileButton;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Button browseKeyPairButton;
        private System.Windows.Forms.TextBox keyPairTextBox;
        private System.Windows.Forms.Label keyPairLabel;
        private System.Windows.Forms.TabPage manifestTab;
        private System.Windows.Forms.Label manifestLabel;
        private System.Windows.Forms.TextBox manifestTextBox;
        private System.Windows.Forms.TabPage clientCodeTab;
        private System.Windows.Forms.Label clientCodeLabel;
        private System.Windows.Forms.TextBox clientCodeTextBox;
        private System.Windows.Forms.GroupBox updateSettingsGroupBox;
        private System.Windows.Forms.Label updateUrlLabel;
        private System.Windows.Forms.TextBox updateUrlTextBox;
        private System.Windows.Forms.GroupBox signingGroupBox;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Label categoriesLabel;
        private System.Windows.Forms.TextBox categoriesTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label updateInfoLabel;
        private System.Windows.Forms.TextBox updateInfoTextBox;
        private System.Windows.Forms.Button saveManifestButton;

    }
}

