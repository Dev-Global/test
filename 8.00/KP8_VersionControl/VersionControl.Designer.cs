namespace KP8_VersionControl
{
    partial class VersionControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionControl));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.cmbBranchName = new System.Windows.Forms.ComboBox();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.ckBox = new System.Windows.Forms.CheckBox();
            this.lblStation = new System.Windows.Forms.Label();
            this.cmbStationNo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.DGdata = new System.Windows.Forms.DataGridView();
            this.txtBoxPerform = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBrancCode = new System.Windows.Forms.TextBox();
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGdata)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(192, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 56);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&S A V E";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(114, 50);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(176, 57);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "R E S E T";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Location = new System.Drawing.Point(70, 71);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(46, 16);
            this.lblRegion.TabIndex = 4;
            this.lblRegion.Text = "Region";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone.Location = new System.Drawing.Point(81, 43);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(35, 16);
            this.lblZone.TabIndex = 5;
            this.lblZone.Text = "Zone";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(85, 98);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(31, 16);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Area";
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchName.Location = new System.Drawing.Point(38, 125);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(78, 16);
            this.lblBranchName.TabIndex = 7;
            this.lblBranchName.Text = "Branch Name";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Enabled = false;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(141, 210);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(208, 21);
            this.cmbArea.TabIndex = 6;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // cmbRegion
            // 
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.Enabled = false;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(141, 183);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(208, 21);
            this.cmbRegion.TabIndex = 5;
            this.cmbRegion.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // cmbBranchName
            // 
            this.cmbBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchName.Enabled = false;
            this.cmbBranchName.FormattingEnabled = true;
            this.cmbBranchName.Location = new System.Drawing.Point(141, 237);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(208, 21);
            this.cmbBranchName.TabIndex = 7;
            this.cmbBranchName.SelectedIndexChanged += new System.EventHandler(this.cmbBranchName_SelectedIndexChanged);
            // 
            // cmbZone
            // 
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.Enabled = false;
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "USA"});
            this.cmbZone.Location = new System.Drawing.Point(141, 155);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(91, 21);
            this.cmbZone.TabIndex = 3;
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbZone_SelectedIndexChanged);
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.Location = new System.Drawing.Point(51, 13);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(65, 16);
            this.lblCategories.TabIndex = 13;
            this.lblCategories.Text = "Categories";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Enabled = false;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "BY NEW RELEASE",
            "BY NATIONWIDE",
            "BY ZONE",
            "BY REGION",
            "BY AREA",
            "BY BRANCH",
            "BY STATION"});
            this.cmbCategory.Location = new System.Drawing.Point(141, 125);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(208, 21);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // ckBox
            // 
            this.ckBox.AutoSize = true;
            this.ckBox.Enabled = false;
            this.ckBox.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBox.Location = new System.Drawing.Point(245, 156);
            this.ckBox.Name = "ckBox";
            this.ckBox.Size = new System.Drawing.Size(86, 20);
            this.ckBox.TabIndex = 4;
            this.ckBox.Text = "Nationwide";
            this.ckBox.UseVisualStyleBackColor = true;
            this.ckBox.Visible = false;
            this.ckBox.CheckedChanged += new System.EventHandler(this.ckBox_CheckedChanged);
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.Location = new System.Drawing.Point(48, 154);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(68, 16);
            this.lblStation.TabIndex = 17;
            this.lblStation.Text = "Station No.";
            // 
            // cmbStationNo
            // 
            this.cmbStationNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStationNo.Enabled = false;
            this.cmbStationNo.FormattingEnabled = true;
            this.cmbStationNo.Location = new System.Drawing.Point(141, 264);
            this.cmbStationNo.Name = "cmbStationNo";
            this.cmbStationNo.Size = new System.Drawing.Size(66, 21);
            this.cmbStationNo.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Location = new System.Drawing.Point(1, -7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(370, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Note: Reset branches first before updating files.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBoxDescription);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblStation);
            this.groupBox2.Controls.Add(this.cmbAction);
            this.groupBox2.Controls.Add(this.DGdata);
            this.groupBox2.Controls.Add(this.txtBoxPerform);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCategories);
            this.groupBox2.Controls.Add(this.txtVersion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtBrancCode);
            this.groupBox2.Controls.Add(this.lblZone);
            this.groupBox2.Controls.Add(this.lblArea);
            this.groupBox2.Controls.Add(this.lblRegion);
            this.groupBox2.Controls.Add(this.lblBranchName);
            this.groupBox2.Location = new System.Drawing.Point(1, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 391);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "Description:";
            // 
            // txtBoxDescription
            // 
            this.txtBoxDescription.Enabled = false;
            this.txtBoxDescription.Location = new System.Drawing.Point(141, 321);
            this.txtBoxDescription.MaxLength = 80;
            this.txtBoxDescription.Multiline = true;
            this.txtBoxDescription.Name = "txtBoxDescription";
            this.txtBoxDescription.Size = new System.Drawing.Size(208, 35);
            this.txtBoxDescription.TabIndex = 51;
            this.txtBoxDescription.TabStop = false;
            this.txtBoxDescription.Text = "Description Type Here..";
            this.txtBoxDescription.Enter += new System.EventHandler(this.txtBoxDescription_Enter);
            this.txtBoxDescription.Leave += new System.EventHandler(this.txtBoxDescription_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "Action:";
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.Enabled = false;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Items.AddRange(new object[] {
            "UPGRADE",
            "DOWNGRADE"});
            this.cmbAction.Location = new System.Drawing.Point(141, 362);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(208, 21);
            this.cmbAction.TabIndex = 15;
            // 
            // DGdata
            // 
            this.DGdata.AllowUserToAddRows = false;
            this.DGdata.AllowUserToResizeColumns = false;
            this.DGdata.AllowUserToResizeRows = false;
            this.DGdata.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGdata.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGdata.Location = new System.Drawing.Point(61, 177);
            this.DGdata.Name = "DGdata";
            this.DGdata.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGdata.Size = new System.Drawing.Size(288, 84);
            this.DGdata.TabIndex = 11;
            // 
            // txtBoxPerform
            // 
            this.txtBoxPerform.Enabled = false;
            this.txtBoxPerform.Location = new System.Drawing.Point(141, 295);
            this.txtBoxPerform.MaxLength = 40;
            this.txtBoxPerform.Name = "txtBoxPerform";
            this.txtBoxPerform.Size = new System.Drawing.Size(208, 20);
            this.txtBoxPerform.TabIndex = 14;
            this.txtBoxPerform.TabStop = false;
            this.txtBoxPerform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPerform_KeyPress);
            this.txtBoxPerform.Leave += new System.EventHandler(this.txtBoxPerform_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "Perform by:";
            // 
            // txtVersion
            // 
            this.txtVersion.Enabled = false;
            this.txtVersion.Location = new System.Drawing.Point(141, 267);
            this.txtVersion.MaxLength = 6;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(53, 20);
            this.txtVersion.TabIndex = 12;
            this.txtVersion.TabStop = false;
            this.txtVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVersion_KeyPress);
            this.txtVersion.Leave += new System.EventHandler(this.txtVersion_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Version No.:";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(285, 151);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(215, 151);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBrancCode
            // 
            this.txtBrancCode.Location = new System.Drawing.Point(220, 152);
            this.txtBrancCode.Name = "txtBrancCode";
            this.txtBrancCode.Size = new System.Drawing.Size(42, 20);
            this.txtBrancCode.TabIndex = 50;
            // 
            // linkClear
            // 
            this.linkClear.AutoSize = true;
            this.linkClear.Enabled = false;
            this.linkClear.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkClear.LinkColor = System.Drawing.Color.Black;
            this.linkClear.Location = new System.Drawing.Point(76, 533);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(57, 16);
            this.linkClear.TabIndex = 17;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "C L E A R";
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            this.linkClear.Click += new System.EventHandler(this.linkClear_Click);
            // 
            // VersionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 587);
            this.Controls.Add(this.linkClear);
            this.Controls.Add(this.cmbStationNo);
            this.Controls.Add(this.ckBox);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.cmbBranchName);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KP8 Version Control";
            this.Load += new System.EventHandler(this.VersionControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.CheckBox ckBox;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.ComboBox cmbStationNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAction;
        internal System.Windows.Forms.DataGridView DGdata;
        private System.Windows.Forms.TextBox txtBoxPerform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtBrancCode;
        private System.Windows.Forms.LinkLabel linkClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxDescription;
        private System.Windows.Forms.Label label5;
    }
}

