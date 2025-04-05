namespace FoodiePointManagementSystem
{
    partial class AddEditReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.numPartySize = new System.Windows.Forms.NumericUpDown();
            this.cboEventType = new System.Windows.Forms.ComboBox();
            this.cboHall = new System.Windows.Forms.ComboBox();
            this.txtSpecialRequests = new System.Windows.Forms.TextBox();
            this.lblHallStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPartySize)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(12, 12);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(260, 21);
            this.cboCustomer.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(12, 39);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(12, 65);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(125, 20);
            this.dtpStartTime.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(147, 65);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(125, 20);
            this.dtpEndTime.TabIndex = 3;
            // 
            // numPartySize
            // 
            this.numPartySize.Location = new System.Drawing.Point(147, 39);
            this.numPartySize.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numPartySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPartySize.Name = "numPartySize";
            this.numPartySize.Size = new System.Drawing.Size(125, 20);
            this.numPartySize.TabIndex = 4;
            this.numPartySize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboEventType
            // 
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(12, 91);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(260, 21);
            this.cboEventType.TabIndex = 5;
            // 
            // cboHall
            // 
            this.cboHall.FormattingEnabled = true;
            this.cboHall.Location = new System.Drawing.Point(12, 118);
            this.cboHall.Name = "cboHall";
            this.cboHall.Size = new System.Drawing.Size(260, 21);
            this.cboHall.TabIndex = 6;
            // 
            // txtSpecialRequests
            // 
            this.txtSpecialRequests.Location = new System.Drawing.Point(12, 145);
            this.txtSpecialRequests.Multiline = true;
            this.txtSpecialRequests.Name = "txtSpecialRequests";
            this.txtSpecialRequests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecialRequests.Size = new System.Drawing.Size(260, 60);
            this.txtSpecialRequests.TabIndex = 7;
            // 
            // lblHallStatus
            // 
            this.lblHallStatus.AutoSize = true;
            this.lblHallStatus.Location = new System.Drawing.Point(12, 208);
            this.lblHallStatus.Name = "lblHallStatus";
            this.lblHallStatus.Size = new System.Drawing.Size(0, 13);
            this.lblHallStatus.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddEditReservationForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHallStatus);
            this.Controls.Add(this.txtSpecialRequests);
            this.Controls.Add(this.cboHall);
            this.Controls.Add(this.cboEventType);
            this.Controls.Add(this.numPartySize);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cboCustomer);
            this.Name = "AddEditReservationForm";
            ((System.ComponentModel.ISupportInitialize)(this.numPartySize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.NumericUpDown numPartySize;
        private System.Windows.Forms.ComboBox cboEventType;
        private System.Windows.Forms.ComboBox cboHall;
        private System.Windows.Forms.TextBox txtSpecialRequests;
        private System.Windows.Forms.Label lblHallStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}