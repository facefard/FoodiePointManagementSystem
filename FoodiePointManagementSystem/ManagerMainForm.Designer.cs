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
            this.btnAddMenuItem = new System.Windows.Forms.Button();
            this.btnEditMenuItem = new System.Windows.Forms.Button();
            this.btnDeleteMenuItem = new System.Windows.Forms.Button();
            this.cboMenuCategoryFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabControl1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            this.panelMenuControls.SuspendLayout();
            this.tabHalls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHalls)).BeginInit();
            this.panelHallControls.SuspendLayout();
            this.panelCommonControls.SuspendLayout();
            this.SuspendLayout();

            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(100, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, ...";

            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMenu);
            this.tabControl1.Controls.Add(this.tabHalls);
            this.tabControl1.Location = new System.Drawing.Point(20, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 450);
            this.tabControl1.TabIndex = 1;

            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.dgvMenuItems);
            this.tabMenu.Controls.Add(this.panelMenuControls);
            this.tabMenu.Location = new System.Drawing.Point(4, 22);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabMenu.Size = new System.Drawing.Size(892, 424);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.Text = "Menu Management";
            this.tabMenu.UseVisualStyleBackColor = true;

            // dgvMenuItems
            // 
            this.dgvMenuItems.AllowUserToAddRows = false;
            this.dgvMenuItems.AllowUserToDeleteRows = false;
            this.dgvMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenuItems.Location = new System.Drawing.Point(3, 50);
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.ReadOnly = true;
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Size = new System.Drawing.Size(886, 371);
            this.dgvMenuItems.TabIndex = 1;

            // panelMenuControls
            // 
            this.panelMenuControls.Controls.Add(this.label1);
            this.panelMenuControls.Controls.Add(this.cboMenuCategoryFilter);
            this.panelMenuControls.Controls.Add(this.btnAddMenuItem);
            this.panelMenuControls.Controls.Add(this.btnEditMenuItem);
            this.panelMenuControls.Controls.Add(this.btnDeleteMenuItem);
            this.panelMenuControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuControls.Location = new System.Drawing.Point(3, 3);
            this.panelMenuControls.Name = "panelMenuControls";
            this.panelMenuControls.Size = new System.Drawing.Size(886, 47);
            this.panelMenuControls.TabIndex = 0;

            // btnAddMenuItem
            // 
            this.btnAddMenuItem.Location = new System.Drawing.Point(500, 10);
            this.btnAddMenuItem.Name = "btnAddMenuItem";
            this.btnAddMenuItem.Size = new System.Drawing.Size(120, 30);
            this.btnAddMenuItem.TabIndex = 0;
            this.btnAddMenuItem.Text = "Add Menu Item";
            this.btnAddMenuItem.UseVisualStyleBackColor = true;

            // btnEditMenuItem
            // 
            this.btnEditMenuItem.Location = new System.Drawing.Point(630, 10);
            this.btnEditMenuItem.Name = "btnEditMenuItem";
            this.btnEditMenuItem.Size = new System.Drawing.Size(120, 30);
            this.btnEditMenuItem.TabIndex = 1;
            this.btnEditMenuItem.Text = "Edit Menu Item";
            this.btnEditMenuItem.UseVisualStyleBackColor = true;

            // btnDeleteMenuItem
            // 
            this.btnDeleteMenuItem.Location = new System.Drawing.Point(760, 10);
            this.btnDeleteMenuItem.Name = "btnDeleteMenuItem";
            this.btnDeleteMenuItem.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteMenuItem.TabIndex = 2;
            this.btnDeleteMenuItem.Text = "Delete Menu Item";
            this.btnDeleteMenuItem.UseVisualStyleBackColor = true;

            // cboMenuCategoryFilter
            // 
            this.cboMenuCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenuCategoryFilter.FormattingEnabled = true;
            this.cboMenuCategoryFilter.Location = new System.Drawing.Point(100, 15);
            this.cboMenuCategoryFilter.Name = "cboMenuCategoryFilter";
            this.cboMenuCategoryFilter.Size = new System.Drawing.Size(200, 21);
            this.cboMenuCategoryFilter.TabIndex = 3;

            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by Category:";

            // tabHalls
            // 
            this.tabHalls.Controls.Add(this.dgvHalls);
            this.tabHalls.Controls.Add(this.panelHallControls);
            this.tabHalls.Location = new System.Drawing.Point(4, 22);
            this.tabHalls.Name = "tabHalls";
            this.tabHalls.Padding = new System.Windows.Forms.Padding(3);
            this.tabHalls.Size = new System.Drawing.Size(892, 424);
            this.tabHalls.TabIndex = 1;
            this.tabHalls.Text = "Halls Management";
            this.tabHalls.UseVisualStyleBackColor = true;

            // dgvHalls
            // 
            this.dgvHalls.AllowUserToAddRows = false;
            this.dgvHalls.AllowUserToDeleteRows = false;
            this.dgvHalls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHalls.Location = new System.Drawing.Point(3, 50);
            this.dgvHalls.Name = "dgvHalls";
            this.dgvHalls.ReadOnly = true;
            this.dgvHalls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHalls.Size = new System.Drawing.Size(886, 371);
            this.dgvHalls.TabIndex = 1;

            // panelHallControls
            // 
            this.panelHallControls.Controls.Add(this.btnAddHall);
            this.panelHallControls.Controls.Add(this.btnEditHall);
            this.panelHallControls.Controls.Add(this.btnDeleteHall);
            this.panelHallControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHallControls.Location = new System.Drawing.Point(3, 3);
            this.panelHallControls.Name = "panelHallControls";
            this.panelHallControls.Size = new System.Drawing.Size(886, 47);
            this.panelHallControls.TabIndex = 0;

            // btnAddHall
            // 
            this.btnAddHall.Location = new System.Drawing.Point(630, 10);
            this.btnAddHall.Name = "btnAddHall";
            this.btnAddHall.Size = new System.Drawing.Size(120, 30);
            this.btnAddHall.TabIndex = 0;
            this.btnAddHall.Text = "Add Hall";
            this.btnAddHall.UseVisualStyleBackColor = true;

            // btnEditHall
            // 
            this.btnEditHall.Location = new System.Drawing.Point(760, 10);
            this.btnEditHall.Name = "btnEditHall";
            this.btnEditHall.Size = new System.Drawing.Size(120, 30);
            this.btnEditHall.TabIndex = 1;
            this.btnEditHall.Text = "Edit Hall";
            this.btnEditHall.UseVisualStyleBackColor = true;

            // btnDeleteHall
            // 
            this.btnDeleteHall.Location = new System.Drawing.Point(500, 10);
            this.btnDeleteHall.Name = "btnDeleteHall";
            this.btnDeleteHall.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteHall.TabIndex = 2;
            this.btnDeleteHall.Text = "Delete Hall";
            this.btnDeleteHall.UseVisualStyleBackColor = true;

            // panelCommonControls
            // 
            this.panelCommonControls.Controls.Add(this.btnViewReports);
            this.panelCommonControls.Controls.Add(this.btnUpdateProfile);
            this.panelCommonControls.Controls.Add(this.btnLogout);
            this.panelCommonControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommonControls.Location = new System.Drawing.Point(0, 520);
            this.panelCommonControls.Name = "panelCommonControls";
            this.panelCommonControls.Size = new System.Drawing.Size(950, 50);
            this.panelCommonControls.TabIndex = 2;

            // btnViewReports
            // 
            this.btnViewReports.Location = new System.Drawing.Point(20, 10);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(120, 30);
            this.btnViewReports.TabIndex = 0;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = true;

            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Location = new System.Drawing.Point(150, 10);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateProfile.TabIndex = 1;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = true;

            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(820, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;

            // ManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 570);
            this.Controls.Add(this.panelCommonControls);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}

