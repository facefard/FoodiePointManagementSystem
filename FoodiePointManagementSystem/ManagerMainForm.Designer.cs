namespace FoodiePointManagementSystem
{
    partial class ManagerMainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMenu = new System.Windows.Forms.TabPage();
            this.dgvMenuItems = new System.Windows.Forms.DataGridView();
            this.panelMenuControls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMenuCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnAddMenuItem = new System.Windows.Forms.Button();
            this.btnEditMenuItem = new System.Windows.Forms.Button();
            this.btnDeleteMenuItem = new System.Windows.Forms.Button();
            this.tabHalls = new System.Windows.Forms.TabPage();
            this.dgvHalls = new System.Windows.Forms.DataGridView();
            this.panelHallControls = new System.Windows.Forms.Panel();
            this.btnAddHall = new System.Windows.Forms.Button();
            this.btnEditHall = new System.Windows.Forms.Button();
            this.btnDeleteHall = new System.Windows.Forms.Button();
            this.panelCommonControls = new System.Windows.Forms.Panel();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            this.panelMenuControls.SuspendLayout();
            this.tabHalls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHalls)).BeginInit();
            this.panelHallControls.SuspendLayout();
            this.panelCommonControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(122, 23);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(132, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, ...";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMenu);
            this.tabControl1.Controls.Add(this.tabHalls);
            this.tabControl1.Location = new System.Drawing.Point(27, 74);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 554);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.dgvMenuItems);
            this.tabMenu.Controls.Add(this.panelMenuControls);
            this.tabMenu.Location = new System.Drawing.Point(4, 25);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMenu.Size = new System.Drawing.Size(1192, 525);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.Text = "Menu Management";
            this.tabMenu.UseVisualStyleBackColor = true;
            // 
            // dgvMenuItems
            // 
            this.dgvMenuItems.AllowUserToAddRows = false;
            this.dgvMenuItems.AllowUserToDeleteRows = false;
            this.dgvMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenuItems.Location = new System.Drawing.Point(4, 62);
            this.dgvMenuItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.ReadOnly = true;
            this.dgvMenuItems.RowHeadersWidth = 51;
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Size = new System.Drawing.Size(1184, 459);
            this.dgvMenuItems.TabIndex = 1;
            // 
            // panelMenuControls
            // 
            this.panelMenuControls.Controls.Add(this.label1);
            this.panelMenuControls.Controls.Add(this.cboMenuCategoryFilter);
            this.panelMenuControls.Controls.Add(this.btnAddMenuItem);
            this.panelMenuControls.Controls.Add(this.btnEditMenuItem);
            this.panelMenuControls.Controls.Add(this.btnDeleteMenuItem);
            this.panelMenuControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuControls.Location = new System.Drawing.Point(4, 4);
            this.panelMenuControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMenuControls.Name = "panelMenuControls";
            this.panelMenuControls.Size = new System.Drawing.Size(1184, 58);
            this.panelMenuControls.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by Category:";
            // 
            // cboMenuCategoryFilter
            // 
            this.cboMenuCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenuCategoryFilter.FormattingEnabled = true;
            this.cboMenuCategoryFilter.Location = new System.Drawing.Point(133, 18);
            this.cboMenuCategoryFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMenuCategoryFilter.Name = "cboMenuCategoryFilter";
            this.cboMenuCategoryFilter.Size = new System.Drawing.Size(265, 24);
            this.cboMenuCategoryFilter.TabIndex = 3;
            // 
            // btnAddMenuItem
            // 
            this.btnAddMenuItem.Location = new System.Drawing.Point(667, 12);
            this.btnAddMenuItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddMenuItem.Name = "btnAddMenuItem";
            this.btnAddMenuItem.Size = new System.Drawing.Size(160, 37);
            this.btnAddMenuItem.TabIndex = 0;
            this.btnAddMenuItem.Text = "Add Menu Item";
            this.btnAddMenuItem.UseVisualStyleBackColor = true;
            // 
            // btnEditMenuItem
            // 
            this.btnEditMenuItem.Location = new System.Drawing.Point(840, 12);
            this.btnEditMenuItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditMenuItem.Name = "btnEditMenuItem";
            this.btnEditMenuItem.Size = new System.Drawing.Size(160, 37);
            this.btnEditMenuItem.TabIndex = 1;
            this.btnEditMenuItem.Text = "Edit Menu Item";
            this.btnEditMenuItem.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMenuItem
            // 
            this.btnDeleteMenuItem.Location = new System.Drawing.Point(1013, 12);
            this.btnDeleteMenuItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteMenuItem.Name = "btnDeleteMenuItem";
            this.btnDeleteMenuItem.Size = new System.Drawing.Size(160, 37);
            this.btnDeleteMenuItem.TabIndex = 2;
            this.btnDeleteMenuItem.Text = "Delete Menu Item";
            this.btnDeleteMenuItem.UseVisualStyleBackColor = true;
            // 
            // tabHalls
            // 
            this.tabHalls.Controls.Add(this.dgvHalls);
            this.tabHalls.Controls.Add(this.panelHallControls);
            this.tabHalls.Location = new System.Drawing.Point(4, 25);
            this.tabHalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabHalls.Name = "tabHalls";
            this.tabHalls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabHalls.Size = new System.Drawing.Size(1192, 525);
            this.tabHalls.TabIndex = 1;
            this.tabHalls.Text = "Halls Management";
            this.tabHalls.UseVisualStyleBackColor = true;
            // 
            // dgvHalls
            // 
            this.dgvHalls.AllowUserToAddRows = false;
            this.dgvHalls.AllowUserToDeleteRows = false;
            this.dgvHalls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHalls.Location = new System.Drawing.Point(4, 62);
            this.dgvHalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHalls.Name = "dgvHalls";
            this.dgvHalls.ReadOnly = true;
            this.dgvHalls.RowHeadersWidth = 51;
            this.dgvHalls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHalls.Size = new System.Drawing.Size(1184, 459);
            this.dgvHalls.TabIndex = 1;
            // 
            // panelHallControls
            // 
            this.panelHallControls.Controls.Add(this.btnAddHall);
            this.panelHallControls.Controls.Add(this.btnEditHall);
            this.panelHallControls.Controls.Add(this.btnDeleteHall);
            this.panelHallControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHallControls.Location = new System.Drawing.Point(4, 4);
            this.panelHallControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHallControls.Name = "panelHallControls";
            this.panelHallControls.Size = new System.Drawing.Size(1184, 58);
            this.panelHallControls.TabIndex = 0;
            // 
            // btnAddHall
            // 
            this.btnAddHall.Location = new System.Drawing.Point(840, 12);
            this.btnAddHall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddHall.Name = "btnAddHall";
            this.btnAddHall.Size = new System.Drawing.Size(160, 37);
            this.btnAddHall.TabIndex = 0;
            this.btnAddHall.Text = "Add Hall";
            this.btnAddHall.UseVisualStyleBackColor = true;
            // 
            // btnEditHall
            // 
            this.btnEditHall.Location = new System.Drawing.Point(1013, 12);
            this.btnEditHall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditHall.Name = "btnEditHall";
            this.btnEditHall.Size = new System.Drawing.Size(160, 37);
            this.btnEditHall.TabIndex = 1;
            this.btnEditHall.Text = "Edit Hall";
            this.btnEditHall.UseVisualStyleBackColor = true;
            // 
            // btnDeleteHall
            // 
            this.btnDeleteHall.Location = new System.Drawing.Point(667, 12);
            this.btnDeleteHall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteHall.Name = "btnDeleteHall";
            this.btnDeleteHall.Size = new System.Drawing.Size(160, 37);
            this.btnDeleteHall.TabIndex = 2;
            this.btnDeleteHall.Text = "Delete Hall";
            this.btnDeleteHall.UseVisualStyleBackColor = true;
            // 
            // panelCommonControls
            // 
            this.panelCommonControls.Controls.Add(this.btnViewReports);
            this.panelCommonControls.Controls.Add(this.btnUpdateProfile);
            this.panelCommonControls.Controls.Add(this.btnLogout);
            this.panelCommonControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommonControls.Location = new System.Drawing.Point(0, 640);
            this.panelCommonControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCommonControls.Name = "panelCommonControls";
            this.panelCommonControls.Size = new System.Drawing.Size(1267, 62);
            this.panelCommonControls.TabIndex = 2;
            // 
            // btnViewReports
            // 
            this.btnViewReports.Location = new System.Drawing.Point(27, 12);
            this.btnViewReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(160, 37);
            this.btnViewReports.TabIndex = 0;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = true;
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Location = new System.Drawing.Point(200, 12);
            this.btnUpdateProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(160, 37);
            this.btnUpdateProfile.TabIndex = 1;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1093, 12);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(133, 37);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FoodiePointManagementSystem.Properties.Resources.FP_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(35, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1267, 702);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelCommonControls);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ManagerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FoodiePoint - Manager";
            this.tabControl1.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            this.panelMenuControls.ResumeLayout(false);
            this.panelMenuControls.PerformLayout();
            this.tabHalls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHalls)).EndInit();
            this.panelHallControls.ResumeLayout(false);
            this.panelCommonControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMenu;
        private System.Windows.Forms.TabPage tabHalls;
        private System.Windows.Forms.DataGridView dgvMenuItems;
        private System.Windows.Forms.Panel panelMenuControls;
        private System.Windows.Forms.Button btnAddMenuItem;
        private System.Windows.Forms.Button btnEditMenuItem;
        private System.Windows.Forms.Button btnDeleteMenuItem;
        private System.Windows.Forms.DataGridView dgvHalls;
        private System.Windows.Forms.Panel panelHallControls;
        private System.Windows.Forms.Button btnAddHall;
        private System.Windows.Forms.Button btnEditHall;
        private System.Windows.Forms.Button btnDeleteHall;
        private System.Windows.Forms.Panel panelCommonControls;
        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cboMenuCategoryFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

