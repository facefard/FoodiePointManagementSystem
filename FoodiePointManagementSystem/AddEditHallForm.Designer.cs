namespace FoodiePointManagementSystem
{
    partial class AddEditHallForm
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
            this.grpHallDetails = new System.Windows.Forms.GroupBox();
            this.txtHallName = new System.Windows.Forms.TextBox();
            this.lblHallName = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpHallDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHallDetails
            // 
            this.grpHallDetails.Controls.Add(this.cboStatus);
            this.grpHallDetails.Controls.Add(this.lblStatus);
            this.grpHallDetails.Controls.Add(this.numCapacity);
            this.grpHallDetails.Controls.Add(this.lblCapacity);
            this.grpHallDetails.Controls.Add(this.lblHallName);
            this.grpHallDetails.Controls.Add(this.txtHallName);
            this.grpHallDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHallDetails.Location = new System.Drawing.Point(10, 10);
            this.grpHallDetails.Name = "grpHallDetails";
            this.grpHallDetails.Size = new System.Drawing.Size(380, 150);
            this.grpHallDetails.TabIndex = 0;
            this.grpHallDetails.TabStop = false;
            this.grpHallDetails.Text = "Hall Information";
            // 
            // txtHallName
            // 
            this.txtHallName.Location = new System.Drawing.Point(120, 30);
            this.txtHallName.Name = "txtHallName";
            this.txtHallName.Size = new System.Drawing.Size(240, 22);
            this.txtHallName.TabIndex = 0;
            // 
            // lblHallName
            // 
            this.lblHallName.AutoSize = true;
            this.lblHallName.Location = new System.Drawing.Point(20, 33);
            this.lblHallName.Name = "lblHallName";
            this.lblHallName.Size = new System.Drawing.Size(72, 16);
            this.lblHallName.TabIndex = 1;
            this.lblHallName.Text = "Hall Name:";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(20, 63);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(61, 16);
            this.lblCapacity.TabIndex = 2;
            this.lblCapacity.Text = "Capacity:";
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(120, 61);
            this.numCapacity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(120, 22);
            this.numCapacity.TabIndex = 1;
            this.numCapacity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 93);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Available",
            "Under Maintenance",
            "Reserved"});
            this.cboStatus.Location = new System.Drawing.Point(120, 90);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(240, 24);
            this.cboStatus.TabIndex = 2;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(10, 170);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(380, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(200, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddEditHallForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.grpHallDetails);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditHallForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hall Details";
            this.grpHallDetails.ResumeLayout(false);
            this.grpHallDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox grpHallDetails;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblHallName;
        private System.Windows.Forms.TextBox txtHallName;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}