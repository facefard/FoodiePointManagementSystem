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
    public partial class ReservationMessagesForm : Form
    {
        private int reservationId;
        private int currentUserId;
        private ReservationCoordinator coordinator;

        public ReservationMessagesForm(int reservationId, int currentUserId)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            this.currentUserId = currentUserId;
            coordinator = new ReservationCoordinator();

            btnSendMessage.Click += btnSendMessage_Click;
            btnClose.Click += btnClose_Click;

            LoadMessages();
        }

        private void LoadMessages()
        {
            try
            {
                var messages = coordinator.GetMessages(reservationId);
                dgvMessages.DataSource = messages;
                FormatMessagesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatMessagesGrid()
        {
            if (dgvMessages.Columns.Count > 0)
            {
                dgvMessages.Columns["SenderName"].HeaderText = "Sender";
                dgvMessages.Columns["MessageText"].HeaderText = "Message";
                dgvMessages.Columns["SentDateTime"].HeaderText = "Time";

                dgvMessages.Columns["SentDateTime"].DefaultCellStyle.Format = "g";
                dgvMessages.Columns["MessageID"].Visible = false;
                dgvMessages.Columns["ReservationID"].Visible = false;
                dgvMessages.Columns["SenderID"].Visible = false;
                dgvMessages.Columns["IsRead"].Visible = false;

                dgvMessages.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewMessage.Text))
            {
                MessageBox.Show("Please enter a message.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (coordinator.SendMessage(reservationId, currentUserId, txtNewMessage.Text))
                {
                    txtNewMessage.Clear();
                    LoadMessages();
                }
                else
                {
                    MessageBox.Show("Failed to send message.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReservationMessagesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
