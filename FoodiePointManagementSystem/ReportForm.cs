using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodiePointManagementSystem
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReservationViewForm_Load(object sender, EventArgs e)
        {
            // Загрузим данные для фильтра
            LoadReservationTypes();
        }

        // Загружаем доступные типы бронирования в ComboBox
        private void LoadReservationTypes()
        {
            string query = "SELECT DISTINCT EventType FROM dbo.Reservations";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            cboEventType.Items.Clear();
            cboEventType.Items.Add("All");
            foreach (DataRow row in dataTable.Rows)
            {
                cboEventType.Items.Add(row["EventType"].ToString());
            }

            cboEventType.SelectedIndex = 0;  // Выбираем "All" по умолчанию
        }

        // Обработчик кнопки для фильтрации
        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Получаем фильтры
            string eventType = cboEventType.SelectedItem.ToString();
            string month = cboMonth.SelectedItem.ToString();

            // Строим SQL-запрос в зависимости от выбранных фильтров
            string query = "SELECT * FROM dbo.Reservations WHERE 1=1";

            if (eventType != "All")
                query += " AND EventType = @EventType";

            // Добавим фильтр по месяцу
            if (!string.IsNullOrEmpty(month))
                query += " AND MONTH(StartDateTime) = @Month";

            // Выполним запрос
            SqlParameter[] parameters = {
                new SqlParameter("@EventType", SqlDbType.NVarChar) { Value = eventType },
                new SqlParameter("@Month", SqlDbType.Int) { Value = int.Parse(month) }
            };

            DataTable reservations = DatabaseHelper.ExecuteQuery(query, parameters);

            // Отображаем данные в DataGridView
            dgvReservations.DataSource = reservations;
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
