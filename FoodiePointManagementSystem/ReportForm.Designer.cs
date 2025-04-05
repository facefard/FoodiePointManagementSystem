using System.Windows.Forms;
using System;

namespace FoodiePointManagementSystem
{
    partial class ReportForm
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
            this.dgvReservations = new DataGridView();
            this.cboEventType = new ComboBox();
            this.cboMonth = new ComboBox();
            this.btnFilter = new Button();
            this.lblEventType = new Label();
            this.lblMonth = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();

            // dgvReservations
            this.dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(12, 90);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(760, 400);
            this.dgvReservations.TabIndex = 0;

            // cboEventType
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(12, 30);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(200, 24);
            this.cboEventType.TabIndex = 1;

            // cboMonth
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"});
            this.cboMonth.Location = new System.Drawing.Point(230, 30);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 24);
            this.cboMonth.TabIndex = 2;

            // btnFilter
            this.btnFilter.Location = new System.Drawing.Point(370, 30);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 30);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new EventHandler(this.btnFilter_Click);

            // lblEventType
            this.lblEventType.AutoSize = true;
            this.lblEventType.Location = new System.Drawing.Point(12, 10);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(80, 16);
            this.lblEventType.TabIndex = 4;
            this.lblEventType.Text = "Event Type:";

            // lblMonth
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(230, 10);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(48, 16);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "Month:";

            // ReservationViewForm
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblEventType);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.cboEventType);
            this.Controls.Add(this.dgvReservations);
            this.Name = "ReservationViewForm";
            this.Text = "View Reservations";
            this.Load += new EventHandler(this.ReservationViewForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private DataGridView dgvReservations;
        private ComboBox cboEventType;
        private ComboBox cboMonth;
        private Button btnFilter;
        private Label lblEventType;
        private Label lblMonth;
    }
}