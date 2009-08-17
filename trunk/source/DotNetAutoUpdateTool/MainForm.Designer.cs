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
            this.keyPairLabel = new System.Windows.Forms.Label();
            this.keyPairTextBox = new System.Windows.Forms.TextBox();
            this.browseKeyPairButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.browseInputFileButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // keyPairLabel
            // 
            this.keyPairLabel.AutoSize = true;
            this.keyPairLabel.Location = new System.Drawing.Point(13, 13);
            this.keyPairLabel.Name = "keyPairLabel";
            this.keyPairLabel.Size = new System.Drawing.Size(49, 13);
            this.keyPairLabel.TabIndex = 0;
            this.keyPairLabel.Text = "Key Pair:";
            // 
            // keyPairTextBox
            // 
            this.keyPairTextBox.Location = new System.Drawing.Point(72, 10);
            this.keyPairTextBox.Name = "keyPairTextBox";
            this.keyPairTextBox.Size = new System.Drawing.Size(201, 20);
            this.keyPairTextBox.TabIndex = 1;
            // 
            // browseKeyPairButton
            // 
            this.browseKeyPairButton.Location = new System.Drawing.Point(280, 8);
            this.browseKeyPairButton.Name = "browseKeyPairButton";
            this.browseKeyPairButton.Size = new System.Drawing.Size(31, 23);
            this.browseKeyPairButton.TabIndex = 2;
            this.browseKeyPairButton.Text = "...";
            this.browseKeyPairButton.UseVisualStyleBackColor = true;
            this.browseKeyPairButton.Click += new System.EventHandler(this.browseKeyPairButton_Click);
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(317, 55);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(82, 23);
            this.signButton.TabIndex = 7;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // browseInputFileButton
            // 
            this.browseInputFileButton.Location = new System.Drawing.Point(280, 55);
            this.browseInputFileButton.Name = "browseInputFileButton";
            this.browseInputFileButton.Size = new System.Drawing.Size(31, 23);
            this.browseInputFileButton.TabIndex = 6;
            this.browseInputFileButton.Text = "...";
            this.browseInputFileButton.UseVisualStyleBackColor = true;
            this.browseInputFileButton.Click += new System.EventHandler(this.browseInputFileButton_Click);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(72, 57);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(201, 20);
            this.inputFileTextBox.TabIndex = 5;
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(13, 60);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(53, 13);
            this.inputFileLabel.TabIndex = 4;
            this.inputFileLabel.Text = "Input File:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 102);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.browseInputFileButton);
            this.Controls.Add(this.inputFileTextBox);
            this.Controls.Add(this.inputFileLabel);
            this.Controls.Add(this.browseKeyPairButton);
            this.Controls.Add(this.keyPairTextBox);
            this.Controls.Add(this.keyPairLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Dot Net Auto Update Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyPairLabel;
        private System.Windows.Forms.TextBox keyPairTextBox;
        private System.Windows.Forms.Button browseKeyPairButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button browseInputFileButton;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.Label inputFileLabel;
    }
}

