namespace FoodiePointManagementSystem
{
    partial class ChefForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControlChef = new System.Windows.Forms.TabControl();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.btnUpdateOrderStatus = new System.Windows.Forms.Button();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.btnDeleteInventory = new System.Windows.Forms.Button();
            this.btnUpdateInventory = new System.Windows.Forms.Button();
            this.btnAddInventory = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.btnlogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.txtProfilePassword = new System.Windows.Forms.TextBox();
            this.txtProfileEmail = new System.Windows.Forms.TextBox();
            this.foodiePointDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.foodiePointDBDataSet = new FoodiePointManagementSystem.FoodiePointDBDataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlChef.SuspendLayout();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tabInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tabProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodiePointDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodiePointDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlChef
            // 
            this.tabControlChef.Controls.Add(this.tabOrders);
            this.tabControlChef.Controls.Add(this.tabInventory);
            this.tabControlChef.Controls.Add(this.tabProfile);
            this.tabControlChef.Location = new System.Drawing.Point(10, -2);
            this.tabControlChef.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlChef.Name = "tabControlChef";
            this.tabControlChef.SelectedIndex = 0;
            this.tabControlChef.Size = new System.Drawing.Size(621, 435);
            this.tabControlChef.TabIndex = 0;
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.pictureBox1);
            this.tabOrders.Controls.Add(this.btnUpdateOrderStatus);
            this.tabOrders.Controls.Add(this.cmbOrderStatus);
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 25);
            this.tabOrders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabOrders.Size = new System.Drawing.Size(613, 406);
            this.tabOrders.TabIndex = 0;
            this.tabOrders.Text = "manege";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // btnUpdateOrderStatus
            // 
            this.btnUpdateOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.btnUpdateOrderStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateOrderStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateOrderStatus.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnUpdateOrderStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateOrderStatus.Location = new System.Drawing.Point(104, 338);
            this.btnUpdateOrderStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
            this.btnUpdateOrderStatus.Size = new System.Drawing.Size(232, 42);
            this.btnUpdateOrderStatus.TabIndex = 2;
            this.btnUpdateOrderStatus.Text = "Update Order Status";
            this.btnUpdateOrderStatus.UseVisualStyleBackColor = false;
            this.btnUpdateOrderStatus.Click += new System.EventHandler(this.btnUpdateOrderStatus_Click);
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(384, 350);
            this.cmbOrderStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(126, 24);
            this.cmbOrderStatus.TabIndex = 1;
            this.cmbOrderStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(104, 121);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 27;
            this.dgvOrders.Size = new System.Drawing.Size(492, 193);
            this.dgvOrders.TabIndex = 0;
            // 
            // tabInventory
            // 
            this.tabInventory.Controls.Add(this.btnDeleteInventory);
            this.tabInventory.Controls.Add(this.btnUpdateInventory);
            this.tabInventory.Controls.Add(this.btnAddInventory);
            this.tabInventory.Controls.Add(this.txtPrice);
            this.tabInventory.Controls.Add(this.txtQuantity);
            this.tabInventory.Controls.Add(this.txtIngredientName);
            this.tabInventory.Controls.Add(this.dgvInventory);
            this.tabInventory.Location = new System.Drawing.Point(4, 25);
            this.tabInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabInventory.Size = new System.Drawing.Size(613, 406);
            this.tabInventory.TabIndex = 1;
            this.tabInventory.Text = "stock";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteInventory
            // 
            this.btnDeleteInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.btnDeleteInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteInventory.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnDeleteInventory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteInventory.Location = new System.Drawing.Point(439, 320);
            this.btnDeleteInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteInventory.Name = "btnDeleteInventory";
            this.btnDeleteInventory.Size = new System.Drawing.Size(106, 42);
            this.btnDeleteInventory.TabIndex = 6;
            this.btnDeleteInventory.Text = "Delete";
            this.btnDeleteInventory.UseVisualStyleBackColor = false;
            this.btnDeleteInventory.Click += new System.EventHandler(this.btnDeleteInventory_Click);
            // 
            // btnUpdateInventory
            // 
            this.btnUpdateInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.btnUpdateInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateInventory.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnUpdateInventory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateInventory.Location = new System.Drawing.Point(239, 320);
            this.btnUpdateInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUpdateInventory.Name = "btnUpdateInventory";
            this.btnUpdateInventory.Size = new System.Drawing.Size(123, 42);
            this.btnUpdateInventory.TabIndex = 5;
            this.btnUpdateInventory.Text = "Update";
            this.btnUpdateInventory.UseVisualStyleBackColor = false;
            this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.btnAddInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddInventory.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnAddInventory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddInventory.Location = new System.Drawing.Point(78, 320);
            this.btnAddInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(101, 42);
            this.btnAddInventory.TabIndex = 4;
            this.btnAddInventory.Text = "Add";
            this.btnAddInventory.UseVisualStyleBackColor = false;
            this.btnAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.txtPrice.Location = new System.Drawing.Point(439, 270);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(98, 26);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Text = "Price";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.txtQuantity.Location = new System.Drawing.Point(239, 270);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(114, 26);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "Quantity";
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.txtIngredientName.Location = new System.Drawing.Point(74, 270);
            this.txtIngredientName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(105, 26);
            this.txtIngredientName.TabIndex = 1;
            this.txtIngredientName.Text = "Name";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(52, 28);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 62;
            this.dgvInventory.RowTemplate.Height = 27;
            this.dgvInventory.Size = new System.Drawing.Size(513, 212);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.pictureBox2);
            this.tabProfile.Controls.Add(this.btnlogout);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.btnUpdateProfile);
            this.tabProfile.Controls.Add(this.txtProfilePassword);
            this.tabProfile.Controls.Add(this.txtProfileEmail);
            this.tabProfile.Location = new System.Drawing.Point(4, 25);
            this.tabProfile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabProfile.Size = new System.Drawing.Size(613, 406);
            this.tabProfile.TabIndex = 2;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlogout.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Location = new System.Drawing.Point(348, 266);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnlogout.Size = new System.Drawing.Size(139, 36);
            this.btnlogout.TabIndex = 5;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email:";
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.btnUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateProfile.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.btnUpdateProfile.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProfile.Location = new System.Drawing.Point(63, 266);
            this.btnUpdateProfile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(182, 37);
            this.btnUpdateProfile.TabIndex = 2;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            // 
            // txtProfilePassword
            // 
            this.txtProfilePassword.Location = new System.Drawing.Point(212, 177);
            this.txtProfilePassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProfilePassword.Name = "txtProfilePassword";
            this.txtProfilePassword.Size = new System.Drawing.Size(275, 22);
            this.txtProfilePassword.TabIndex = 1;
            this.txtProfilePassword.UseSystemPasswordChar = true;
            this.txtProfilePassword.UseWaitCursor = true;
            // 
            // txtProfileEmail
            // 
            this.txtProfileEmail.Location = new System.Drawing.Point(212, 108);
            this.txtProfileEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProfileEmail.Name = "txtProfileEmail";
            this.txtProfileEmail.Size = new System.Drawing.Size(275, 22);
            this.txtProfileEmail.TabIndex = 0;
            // 
            // foodiePointDBDataSetBindingSource
            // 
            this.foodiePointDBDataSetBindingSource.DataSource = this.foodiePointDBDataSet;
            this.foodiePointDBDataSetBindingSource.Position = 0;
            // 
            // foodiePointDBDataSet
            // 
            this.foodiePointDBDataSet.DataSetName = "FoodiePointDBDataSet";
            this.foodiePointDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::FoodiePointManagementSystem.Properties.Resources.FP_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FoodiePointManagementSystem.Properties.Resources.FP_LOGO;
            this.pictureBox2.Location = new System.Drawing.Point(5, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // ChefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(678, 502);
            this.Controls.Add(this.tabControlChef);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ChefForm";
            this.Text = "ChefForm";
            this.Load += new System.EventHandler(this.ChefForm_Load);
            this.tabControlChef.ResumeLayout(false);
            this.tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tabInventory.ResumeLayout(false);
            this.tabInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodiePointDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodiePointDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlChef;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.BindingSource foodiePointDBDataSetBindingSource;
        private FoodiePointDBDataSet foodiePointDBDataSet;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Button btnUpdateOrderStatus;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Button btnDeleteInventory;
        private System.Windows.Forms.Button btnUpdateInventory;
        private System.Windows.Forms.Button btnAddInventory;
        private System.Windows.Forms.TextBox txtProfilePassword;
        private System.Windows.Forms.TextBox txtProfileEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}