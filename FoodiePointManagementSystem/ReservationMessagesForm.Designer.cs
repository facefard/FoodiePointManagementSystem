namespace FoodiePointManagementSystem
{
    partial class ReservationMessagesForm
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
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.txtNewMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMessages
            // 
            this.dgvMessages.AllowUserToAddRows = false;
            this.dgvMessages.AllowUserToDeleteRows = false;
            this.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessages.Location = new System.Drawing.Point(12, 12);
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.RowHeadersWidth = 62;
            this.dgvMessages.Size = new System.Drawing.Size(560, 200);
            this.dgvMessages.TabIndex = 0;
            // 
            // txtNewMessage
            // 
            this.txtNewMessage.Location = new System.Drawing.Point(12, 218);
            this.txtNewMessage.Multiline = true;
            this.txtNewMessage.Name = "txtNewMessage";
            this.txtNewMessage.Size = new System.Drawing.Size(400, 60);
            this.txtNewMessage.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(418, 218);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 60);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(499, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 60);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ReservationMessagesForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 290);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtNewMessage);
            this.Controls.Add(this.dgvMessages);
            this.Name = "ReservationMessagesForm";
            this.Text = "Reservation Messages";
            this.Load += new System.EventHandler(this.ReservationMessagesForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TextBox txtNewMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnClose;
    }
}