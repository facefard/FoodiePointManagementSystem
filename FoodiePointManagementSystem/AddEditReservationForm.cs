using System;
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
    public partial class AddEditReservationForm : Form
    {
        private int? reservationId;
        private int coordinatorId;
        private ReservationCoordinator coordinator;
        private List<Hall> availableHalls;

        public AddEditReservationForm(int? id, int coordinatorUserId)
        {
            InitializeComponent();

            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
            dtpEndTime.ValueChanged += dtpEndTime_ValueChanged;
            numPartySize.ValueChanged += numPartySize_ValueChanged;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            reservationId = id;
            coordinatorId = coordinatorUserId;
            coordinator = new ReservationCoordinator();

            if (reservationId.HasValue)
            {
                this.Text = "Edit Reservation";
                btnSave.Text = "Update";
                LoadReservationData();
            }
            else
            {
                this.Text = "Add New Reservation";
                btnSave.Text = "Save";
            }

            LoadEventTypes();
            LoadCustomers();
            InitializeDateTimePickers();
        }

        private void LoadReservationData()
        {
            try
            {
                var reservations = coordinator.GetReservations();
                var reservation = reservations.FirstOrDefault(r => r.ReservationID == reservationId.Value);

                if (reservation != null)
                {
                    cboCustomer.SelectedValue = reservation.CustomerID;
                    dtpDate.Value = reservation.StartDateTime.Date;
                    dtpStartTime.Value = reservation.StartDateTime;
                    dtpEndTime.Value = reservation.EndDateTime;
                    numPartySize.Value = reservation.PartySize;
                    cboEventType.Text = reservation.EventType;
                    txtSpecialRequests.Text = reservation.SpecialRequests;

                    // Load and select the hall
                    LoadAvailableHalls();
                    if (availableHalls.Any(h => h.HallID == reservation.HallID))
                    {
                        cboHall.SelectedValue = reservation.HallID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventTypes()
        {
            cboEventType.Items.AddRange(new string[] { "Birthday", "Wedding", "Corporate Event", "Family Gathering", "Other" });
        }

        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT UserID, FullName FROM Users WHERE Role = 'Customer'";
                DataTable customers = coordinator.GetCustomersFromDatabase(query);

                cboCustomer.DataSource = customers;
                cboCustomer.DisplayMember = "FullName";
                cboCustomer.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDateTimePickers()
        {
            dtpDate.MinDate = DateTime.Today;
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.ShowUpDown = true;
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.ShowUpDown = true;

            // Set default times
            dtpStartTime.Value = DateTime.Today.AddHours(12); // 12 PM
            dtpEndTime.Value = DateTime.Today.AddHours(14);   // 2 PM
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableHalls();
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end time is after start time
            if (dtpEndTime.Value <= dtpStartTime.Value)
            {
                dtpEndTime.Value = dtpStartTime.Value.AddHours(2);
            }
            LoadAvailableHalls();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end time is after start time
            if (dtpEndTime.Value <= dtpStartTime.Value)
            {
                MessageBox.Show("End time must be after start time.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndTime.Value = dtpStartTime.Value.AddHours(2);
            }
            LoadAvailableHalls();
        }

        private void numPartySize_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableHalls();
        }

        private void LoadAvailableHalls()
        {
            try
            {
                DateTime startDateTime = dtpDate.Value.Date.Add(dtpStartTime.Value.TimeOfDay);
                DateTime endDateTime = dtpDate.Value.Date.Add(dtpEndTime.Value.TimeOfDay);
                int partySize = (int)numPartySize.Value;

                availableHalls = coordinator.GetAvailableHalls(startDateTime, endDateTime, partySize);

                cboHall.DataSource = availableHalls;
                cboHall.DisplayMember = "HallName";
                cboHall.ValueMember = "HallID";

                if (availableHalls.Count == 0)
                {
                    lblHallStatus.Text = "No available halls for the selected criteria.";
                    lblHallStatus.ForeColor = Color.Red;
                    btnSave.Enabled = false;
                }
                else
                {
                    lblHallStatus.Text = $"{availableHalls.Count} hall(s) available";
                    lblHallStatus.ForeColor = Color.Green;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available halls: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                var reservation = new Reservation
                {
                    ReservationID = reservationId ?? 0,
                    CustomerID = (int)cboCustomer.SelectedValue,
                    HallID = (int)cboHall.SelectedValue,
                    EventType = cboEventType.Text,
                    StartDateTime = dtpDate.Value.Date.Add(dtpStartTime.Value.TimeOfDay),
                    EndDateTime = dtpDate.Value.Date.Add(dtpEndTime.Value.TimeOfDay),
                    PartySize = (int)numPartySize.Value,
                    SpecialRequests = txtSpecialRequests.Text,
                    Status = reservationId.HasValue ?
                        coordinator.GetReservationStatus(reservationId.Value) : "Confirmed"
                };

                bool success;
                if (reservationId.HasValue)
                {
                    success = coordinator.UpdateReservation(reservation);
                }
                else
                {
                    success = coordinator.AddReservation(reservation);
                }

                if (success)
                {
                    MessageBox.Show($"Reservation {(reservationId.HasValue ? "updated" : "added")} successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Failed to {(reservationId.HasValue ? "update" : "add")} reservation.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving reservation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (cboCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboEventType.Text))
            {
                MessageBox.Show("Please enter an event type.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numPartySize.Value <= 0)
            {
                MessageBox.Show("Party size must be at least 1.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboHall.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a hall.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddEditReservationForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
