using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace FoodiePointManagementSystem
{
    public partial class ReservationCoordinatorMainForm : Form
    {
        private int currentUserId;
        private ReservationCoordinator coordinator;

        public ReservationCoordinatorMainForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            coordinator = new ReservationCoordinator();

            // Инициализация интерфейса
            InitializeStatusFilter();
            SetupDataGridView();

            // Загрузка данных
            LoadUserData();
            LoadReservations();

            // Подписка на события кнопок
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            // Подписка на события кнопок
            btnNewReservation.Click += btnNewReservation_Click;
            btnEditReservation.Click += btnEditReservation_Click;
            btnDeleteReservation.Click += btnDeleteReservation_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            btnViewMessages.Click += btnViewMessages_Click;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            btnLogout.Click += btnLogout_Click;

            // Подписка на другие события
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
        }

        private void LoadUserData()
        {
            User user = coordinator.GetUserById(currentUserId);
            if (user != null)
            {
                lblWelcome.Text = $"Welcome, {user.Username}";
            }
        }

        private void InitializeStatusFilter()
        {
            cboStatusFilter.Items.AddRange(new string[] { "All", "Pending", "Confirmed", "Completed", "Cancelled" });
            cboStatusFilter.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvReservations.Columns.Clear();

            // Настройка колонок DataGridView
            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ReservationID",
                HeaderText = "Reservation ID",
                Name = "ReservationID",
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Customer",
                Name = "CustomerName",
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HallName",
                HeaderText = "Hall",
                Name = "HallName",
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "EventType",
                HeaderText = "Event Type",
                Name = "EventType",
            });

            var startDateColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "StartDateTime",
                HeaderText = "Start Time",
                Name = "StartDateTime"
            };
            dgvReservations.Columns.Add(startDateColumn);

            var endDateColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "EndDateTime",
                HeaderText = "End Time",
                Name = "EndDateTime"
            };
            dgvReservations.Columns.Add(endDateColumn);

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PartySize",
                HeaderText = "Party Size",
                Name = "PartySize",
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Name = "Status",
            });
        }

        private void LoadReservations(string status = null)
        {
            try
            {
                if (status == "All") status = null;

                List<Reservation> reservations = coordinator.GetReservations(status);
                dgvReservations.DataSource = reservations;
                dgvReservations.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики событий кнопок (остаются без изменений)
        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditReservationForm(null, currentUserId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = (int)dgvReservations.SelectedRows[0].Cells["ReservationID"].Value;
            using (var form = new AddEditReservationForm(reservationId, currentUserId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void btnViewMessages_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to view messages.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = (int)dgvReservations.SelectedRows[0].Cells["ReservationID"].Value;
            using (var form = new ReservationMessagesForm(reservationId, currentUserId))
            {
                form.ShowDialog();
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to update status.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = (int)dgvReservations.SelectedRows[0].Cells["ReservationID"].Value;
            string currentStatus = dgvReservations.SelectedRows[0].Cells["Status"].Value.ToString();

            using (var form = new UpdateStatusForm(reservationId, currentStatus))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = (int)dgvReservations.SelectedRows[0].Cells["ReservationID"].Value;
            string customerName = dgvReservations.SelectedRows[0].Cells["CustomerName"].Value.ToString();

            if (MessageBox.Show($"Are you sure you want to delete reservation for {customerName}?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (coordinator.DeleteReservation(reservationId))
                    {
                        MessageBox.Show("Reservation deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservations();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete reservation.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            using (var form = new UpdateProfileForm(currentUserId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUserData();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            LogIN loginForm = new LogIN();
            loginForm.Show();
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cboStatusFilter.SelectedItem?.ToString();
            LoadReservations(status);
        }

        private void ReservationCoordinatorMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
