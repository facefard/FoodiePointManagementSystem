﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void me_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogIN loginForm = new LogIN();
            loginForm.Show();
            this.Hide();
        }
          
        

        private void button2_Click(object sender, EventArgs e)
        {
            update updateForm = new update();
            updateForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            feedback feedbackForm = new feedback();
            feedbackForm.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            menu Form1Form = new menu();
            Form1Form.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            progressForm statusForm = new progressForm(); 
            statusForm.Show(); 
            this.Hide(); 
        }
    }
}
