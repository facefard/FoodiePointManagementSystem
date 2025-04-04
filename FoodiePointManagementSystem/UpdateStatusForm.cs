using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodiePoint;

namespace FoodiePoint
{
    public partial class UpdateStatusForm : Form
    {
        private int reservationId;
        private ReservationCoordinator coordinator;

        public UpdateStatusForm(int reservationId, string currentStatus)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            coordinator = new ReservationCoordinator();

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;

            cboStatus.SelectedItem = currentStatus;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newStatus = cboStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Please select a status.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (coordinator.UpdateReservationStatus(reservationId, newStatus))
                {
                    MessageBox.Show("Reservation status updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update reservation status.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateStatusForm_Load(object sender, EventArgs e)
        {

        }
    }
}
