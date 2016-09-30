namespace HoneySelectBoneSliderUI
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.minSliderValue = new System.Windows.Forms.NumericUpDown();
            this.maxSliderValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadBoneInfoFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minSliderValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSliderValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // minSliderValue
            // 
            this.minSliderValue.DecimalPlaces = 1;
            this.minSliderValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.minSliderValue.Location = new System.Drawing.Point(105, 17);
            this.minSliderValue.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.minSliderValue.Name = "minSliderValue";
            this.minSliderValue.Size = new System.Drawing.Size(48, 20);
            this.minSliderValue.TabIndex = 1;
            this.minSliderValue.ValueChanged += new System.EventHandler(this.minMaxSliderShowToolTip);
            // 
            // maxSliderValue
            // 
            this.maxSliderValue.DecimalPlaces = 1;
            this.maxSliderValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxSliderValue.Location = new System.Drawing.Point(189, 17);
            this.maxSliderValue.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.maxSliderValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxSliderValue.Name = "maxSliderValue";
            this.maxSliderValue.Size = new System.Drawing.Size(48, 20);
            this.maxSliderValue.TabIndex = 2;
            this.maxSliderValue.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.maxSliderValue.ValueChanged += new System.EventHandler(this.minMaxSliderShowToolTip);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max";
            // 
            // loadBoneInfoFile
            // 
            this.loadBoneInfoFile.Location = new System.Drawing.Point(403, 17);
            this.loadBoneInfoFile.Name = "loadBoneInfoFile";
            this.loadBoneInfoFile.Size = new System.Drawing.Size(186, 22);
            this.loadBoneInfoFile.TabIndex = 8;
            this.loadBoneInfoFile.Text = "Load/Reload Bonemod File";
            this.loadBoneInfoFile.UseVisualStyleBackColor = true;
            this.loadBoneInfoFile.Click += new System.EventHandler(this.loadBoneInfoFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.loadBoneInfoFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.minSliderValue);
            this.groupBox1.Controls.Add(this.maxSliderValue);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 48);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customization";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Changing the values on the left\r\nrequires the file to be reloaded.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Slider Values |";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(649, 561);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(665, 600);
            this.Name = "mainForm";
            this.Text = "Honey Select :: Bone Slider UI";
            this.ResizeEnd += new System.EventHandler(this.changeTableWidth);
            ((System.ComponentModel.ISupportInitialize)(this.minSliderValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSliderValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown minSliderValue;
        private System.Windows.Forms.NumericUpDown maxSliderValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadBoneInfoFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

