namespace Containerschip
{
    partial class ContainerConfiguration
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
            this.rdoCooled = new System.Windows.Forms.RadioButton();
            this.rdoValuable = new System.Windows.Forms.RadioButton();
            this.rdoStandard = new System.Windows.Forms.RadioButton();
            this.btnAddContainer = new System.Windows.Forms.Button();
            this.nudContainerWeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveContainer = new System.Windows.Forms.Button();
            this.lstContainers = new System.Windows.Forms.ListBox();
            this.btnStartSorting = new System.Windows.Forms.Button();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkRandomize = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtxVisual = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContainerWeight)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRandomize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudAmount);
            this.groupBox1.Controls.Add(this.rdoCooled);
            this.groupBox1.Controls.Add(this.rdoValuable);
            this.groupBox1.Controls.Add(this.rdoStandard);
            this.groupBox1.Controls.Add(this.btnAddContainer);
            this.groupBox1.Controls.Add(this.nudContainerWeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Container";
            // 
            // rdoCooled
            // 
            this.rdoCooled.AutoSize = true;
            this.rdoCooled.Location = new System.Drawing.Point(9, 153);
            this.rdoCooled.Name = "rdoCooled";
            this.rdoCooled.Size = new System.Drawing.Size(58, 17);
            this.rdoCooled.TabIndex = 14;
            this.rdoCooled.Text = "Cooled";
            this.rdoCooled.UseVisualStyleBackColor = true;
            // 
            // rdoValuable
            // 
            this.rdoValuable.AutoSize = true;
            this.rdoValuable.Location = new System.Drawing.Point(9, 130);
            this.rdoValuable.Name = "rdoValuable";
            this.rdoValuable.Size = new System.Drawing.Size(66, 17);
            this.rdoValuable.TabIndex = 13;
            this.rdoValuable.Text = "Valuable";
            this.rdoValuable.UseVisualStyleBackColor = true;
            // 
            // rdoStandard
            // 
            this.rdoStandard.AutoSize = true;
            this.rdoStandard.Checked = true;
            this.rdoStandard.Location = new System.Drawing.Point(9, 107);
            this.rdoStandard.Name = "rdoStandard";
            this.rdoStandard.Size = new System.Drawing.Size(68, 17);
            this.rdoStandard.TabIndex = 12;
            this.rdoStandard.TabStop = true;
            this.rdoStandard.Text = "Standard";
            this.rdoStandard.UseVisualStyleBackColor = true;
            // 
            // btnAddContainer
            // 
            this.btnAddContainer.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnAddContainer.Location = new System.Drawing.Point(132, 102);
            this.btnAddContainer.Name = "btnAddContainer";
            this.btnAddContainer.Size = new System.Drawing.Size(84, 26);
            this.btnAddContainer.TabIndex = 11;
            this.btnAddContainer.Text = "Add Container";
            this.btnAddContainer.UseVisualStyleBackColor = true;
            this.btnAddContainer.Click += new System.EventHandler(this.BtnAddContainer_Click);
            // 
            // nudContainerWeight
            // 
            this.nudContainerWeight.Location = new System.Drawing.Point(9, 49);
            this.nudContainerWeight.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.nudContainerWeight.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudContainerWeight.Name = "nudContainerWeight";
            this.nudContainerWeight.Size = new System.Drawing.Size(120, 20);
            this.nudContainerWeight.TabIndex = 7;
            this.nudContainerWeight.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Weight in kg:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxLog);
            this.groupBox2.Location = new System.Drawing.Point(517, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 257);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // rtxLog
            // 
            this.rtxLog.Location = new System.Drawing.Point(6, 19);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.Size = new System.Drawing.Size(258, 232);
            this.rtxLog.TabIndex = 12;
            this.rtxLog.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.lblTotalWeight);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnRemoveContainer);
            this.groupBox3.Controls.Add(this.lstContainers);
            this.groupBox3.Location = new System.Drawing.Point(268, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 230);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Containers";
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Location = new System.Drawing.Point(70, 168);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(0, 13);
            this.lblTotalWeight.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Total weight:";
            // 
            // btnRemoveContainer
            // 
            this.btnRemoveContainer.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnRemoveContainer.Location = new System.Drawing.Point(132, 159);
            this.btnRemoveContainer.Name = "btnRemoveContainer";
            this.btnRemoveContainer.Size = new System.Drawing.Size(105, 31);
            this.btnRemoveContainer.TabIndex = 16;
            this.btnRemoveContainer.Text = "Remove Container";
            this.btnRemoveContainer.UseVisualStyleBackColor = true;
            this.btnRemoveContainer.Click += new System.EventHandler(this.BtnRemoveContainer_Click);
            // 
            // lstContainers
            // 
            this.lstContainers.FormattingEnabled = true;
            this.lstContainers.Location = new System.Drawing.Point(6, 19);
            this.lstContainers.Name = "lstContainers";
            this.lstContainers.Size = new System.Drawing.Size(231, 134);
            this.lstContainers.TabIndex = 0;
            // 
            // btnStartSorting
            // 
            this.btnStartSorting.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnStartSorting.Location = new System.Drawing.Point(90, 205);
            this.btnStartSorting.Name = "btnStartSorting";
            this.btnStartSorting.Size = new System.Drawing.Size(93, 37);
            this.btnStartSorting.TabIndex = 15;
            this.btnStartSorting.Text = "Begin Sorting";
            this.btnStartSorting.UseVisualStyleBackColor = true;
            this.btnStartSorting.Click += new System.EventHandler(this.BtnStartSorting_Click);
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(151, 49);
            this.nudAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(65, 20);
            this.nudAmount.TabIndex = 15;
            this.nudAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Amount of containers:";
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnClear.Location = new System.Drawing.Point(132, 193);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 31);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // chkRandomize
            // 
            this.chkRandomize.AutoSize = true;
            this.chkRandomize.Location = new System.Drawing.Point(9, 75);
            this.chkRandomize.Name = "chkRandomize";
            this.chkRandomize.Size = new System.Drawing.Size(113, 17);
            this.chkRandomize.TabIndex = 17;
            this.chkRandomize.Text = "Randomize weight";
            this.chkRandomize.UseVisualStyleBackColor = true;
            this.chkRandomize.CheckedChanged += new System.EventHandler(this.ChkRandomize_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtxVisual);
            this.groupBox4.Location = new System.Drawing.Point(12, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(775, 357);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Visual";
            // 
            // rtxVisual
            // 
            this.rtxVisual.Location = new System.Drawing.Point(6, 19);
            this.rtxVisual.Name = "rtxVisual";
            this.rtxVisual.Size = new System.Drawing.Size(763, 332);
            this.rtxVisual.TabIndex = 12;
            this.rtxVisual.Text = "";
            // 
            // ContainerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(799, 638);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnStartSorting);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContainerConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContainerConfiguration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContainerWeight)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddContainer;
        private System.Windows.Forms.NumericUpDown nudContainerWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.RadioButton rdoCooled;
        private System.Windows.Forms.RadioButton rdoValuable;
        private System.Windows.Forms.RadioButton rdoStandard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStartSorting;
        private System.Windows.Forms.ListBox lstContainers;
        private System.Windows.Forms.Button btnRemoveContainer;
        private System.Windows.Forms.Label lblTotalWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkRandomize;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtxVisual;
    }
}