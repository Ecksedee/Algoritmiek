namespace Containerschip
{
    partial class FreighterConfiguration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudLengthInContainers = new System.Windows.Forms.NumericUpDown();
            this.nudWidthInContainers = new System.Windows.Forms.NumericUpDown();
            this.nudHeightInContainers = new System.Windows.Forms.NumericUpDown();
            this.nudLoadCapacity = new System.Windows.Forms.NumericUpDown();
            this.btnSet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthInContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthInContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightInContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoadCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSet);
            this.groupBox1.Controls.Add(this.nudLoadCapacity);
            this.groupBox1.Controls.Add(this.nudHeightInContainers);
            this.groupBox1.Controls.Add(this.nudWidthInContainers);
            this.groupBox1.Controls.Add(this.nudLengthInContainers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Length in containers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width in containers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height in containers:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maximum load capacity in kg:";
            // 
            // nudLengthInContainers
            // 
            this.nudLengthInContainers.Location = new System.Drawing.Point(6, 46);
            this.nudLengthInContainers.Name = "nudLengthInContainers";
            this.nudLengthInContainers.Size = new System.Drawing.Size(120, 20);
            this.nudLengthInContainers.TabIndex = 7;
            this.nudLengthInContainers.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudWidthInContainers
            // 
            this.nudWidthInContainers.Location = new System.Drawing.Point(6, 99);
            this.nudWidthInContainers.Name = "nudWidthInContainers";
            this.nudWidthInContainers.Size = new System.Drawing.Size(120, 20);
            this.nudWidthInContainers.TabIndex = 8;
            this.nudWidthInContainers.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudHeightInContainers
            // 
            this.nudHeightInContainers.Location = new System.Drawing.Point(6, 151);
            this.nudHeightInContainers.Name = "nudHeightInContainers";
            this.nudHeightInContainers.Size = new System.Drawing.Size(120, 20);
            this.nudHeightInContainers.TabIndex = 9;
            this.nudHeightInContainers.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudLoadCapacity
            // 
            this.nudLoadCapacity.Location = new System.Drawing.Point(6, 205);
            this.nudLoadCapacity.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudLoadCapacity.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudLoadCapacity.Name = "nudLoadCapacity";
            this.nudLoadCapacity.Size = new System.Drawing.Size(120, 20);
            this.nudLoadCapacity.TabIndex = 10;
            this.nudLoadCapacity.Value = new decimal(new int[] {
            900000,
            0,
            0,
            0});
            // 
            // btnSet
            // 
            this.btnSet.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnSet.Location = new System.Drawing.Point(158, 125);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 11;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // FreighterConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(296, 279);
            this.Controls.Add(this.groupBox1);
            this.Name = "FreighterConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Freighter Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthInContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthInContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightInContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoadCapacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.NumericUpDown nudLoadCapacity;
        private System.Windows.Forms.NumericUpDown nudHeightInContainers;
        private System.Windows.Forms.NumericUpDown nudWidthInContainers;
        private System.Windows.Forms.NumericUpDown nudLengthInContainers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}