namespace MainUI
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxMainBox = new System.Windows.Forms.PictureBox();
            this.openFileDialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonEnergy = new System.Windows.Forms.Button();
            this.textBoxSeamNumber = new System.Windows.Forms.TextBox();
            this.checkBoxDrawSeam = new System.Windows.Forms.CheckBox();
            this.buttonSeamDynamic = new System.Windows.Forms.Button();
            this.comboBoxSeamDirection = new System.Windows.Forms.ComboBox();
            this.buttonSeam = new System.Windows.Forms.Button();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.toolTipDelay = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMainBox
            // 
            this.pictureBoxMainBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMainBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMainBox.Name = "pictureBoxMainBox";
            this.pictureBoxMainBox.Size = new System.Drawing.Size(765, 683);
            this.pictureBoxMainBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainBox.TabIndex = 0;
            this.pictureBoxMainBox.TabStop = false;
            // 
            // openFileDialogOpenFile
            // 
            this.openFileDialogOpenFile.Filter = "JPEG|*.jpg";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(793, 531);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 2;
            this.buttonOpenFile.Text = "Open";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonEnergy
            // 
            this.buttonEnergy.Enabled = false;
            this.buttonEnergy.Location = new System.Drawing.Point(793, 12);
            this.buttonEnergy.Name = "buttonEnergy";
            this.buttonEnergy.Size = new System.Drawing.Size(75, 23);
            this.buttonEnergy.TabIndex = 3;
            this.buttonEnergy.Text = "Energy";
            this.buttonEnergy.UseVisualStyleBackColor = true;
            this.buttonEnergy.Click += new System.EventHandler(this.buttonEnergy_Click);
            // 
            // textBoxSeamNumber
            // 
            this.textBoxSeamNumber.Location = new System.Drawing.Point(793, 120);
            this.textBoxSeamNumber.Name = "textBoxSeamNumber";
            this.textBoxSeamNumber.Size = new System.Drawing.Size(86, 20);
            this.textBoxSeamNumber.TabIndex = 4;
            this.textBoxSeamNumber.Text = "10";
            // 
            // checkBoxDrawSeam
            // 
            this.checkBoxDrawSeam.AutoSize = true;
            this.checkBoxDrawSeam.Checked = true;
            this.checkBoxDrawSeam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDrawSeam.Location = new System.Drawing.Point(793, 146);
            this.checkBoxDrawSeam.Name = "checkBoxDrawSeam";
            this.checkBoxDrawSeam.Size = new System.Drawing.Size(90, 17);
            this.checkBoxDrawSeam.TabIndex = 5;
            this.checkBoxDrawSeam.Text = "Draw Seam ?";
            this.checkBoxDrawSeam.UseVisualStyleBackColor = true;
            // 
            // buttonSeamDynamic
            // 
            this.buttonSeamDynamic.Enabled = false;
            this.buttonSeamDynamic.Location = new System.Drawing.Point(793, 53);
            this.buttonSeamDynamic.Name = "buttonSeamDynamic";
            this.buttonSeamDynamic.Size = new System.Drawing.Size(75, 23);
            this.buttonSeamDynamic.TabIndex = 6;
            this.buttonSeamDynamic.Text = "SeamDynamic";
            this.buttonSeamDynamic.UseVisualStyleBackColor = true;
            this.buttonSeamDynamic.Click += new System.EventHandler(this.buttonSeam_Click);
            // 
            // comboBoxSeamDirection
            // 
            this.comboBoxSeamDirection.Enabled = false;
            this.comboBoxSeamDirection.FormattingEnabled = true;
            this.comboBoxSeamDirection.Items.AddRange(new object[] {
            "Vertical",
            "Horizontal"});
            this.comboBoxSeamDirection.Location = new System.Drawing.Point(793, 300);
            this.comboBoxSeamDirection.Name = "comboBoxSeamDirection";
            this.comboBoxSeamDirection.Size = new System.Drawing.Size(92, 21);
            this.comboBoxSeamDirection.TabIndex = 9;
            this.comboBoxSeamDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeamDirection_SelectedIndexChanged);
            // 
            // buttonSeam
            // 
            this.buttonSeam.Enabled = false;
            this.buttonSeam.Location = new System.Drawing.Point(793, 91);
            this.buttonSeam.Name = "buttonSeam";
            this.buttonSeam.Size = new System.Drawing.Size(75, 23);
            this.buttonSeam.TabIndex = 1;
            this.buttonSeam.Text = "Seam";
            this.buttonSeam.UseVisualStyleBackColor = true;
            this.buttonSeam.Click += new System.EventHandler(this.buttonSeam_Click);
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(793, 186);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(32, 20);
            this.textBoxDelay.TabIndex = 10;
            this.textBoxDelay.Text = "10";
            this.toolTipDelay.SetToolTip(this.textBoxDelay, "toolTipDelay");
            this.textBoxDelay.TextChanged += new System.EventHandler(this.textBoxDelay_TextChanged);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(790, 170);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(56, 13);
            this.labelDelay.TabIndex = 11;
            this.labelDelay.Text = "Delay [ms]";
            // 
            // toolTipDelay
            // 
            this.toolTipDelay.AutomaticDelay = 100;
            this.toolTipDelay.ToolTipTitle = "0-999 ms";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 707);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.comboBoxSeamDirection);
            this.Controls.Add(this.buttonSeamDynamic);
            this.Controls.Add(this.checkBoxDrawSeam);
            this.Controls.Add(this.textBoxSeamNumber);
            this.Controls.Add(this.buttonEnergy);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonSeam);
            this.Controls.Add(this.pictureBoxMainBox);
            this.Name = "MainForm";
            this.Text = "Seam Carving";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMainBox;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpenFile;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonEnergy;
        private System.Windows.Forms.TextBox textBoxSeamNumber;
        private System.Windows.Forms.CheckBox checkBoxDrawSeam;
        private System.Windows.Forms.Button buttonSeamDynamic;
        private System.Windows.Forms.ComboBox comboBoxSeamDirection;
        private System.Windows.Forms.Button buttonSeam;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.ToolTip toolTipDelay;
    }
}

