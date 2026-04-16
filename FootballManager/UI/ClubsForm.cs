using FootballManager.BusinessLogic; // Добавяме референция към новия BLL
using FootballManager.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FootballManager.UI
{
    public partial class ClubsForm : Form
    {
        private ClubService _clubService; // Заменяме Repository със Service

        public ClubsForm()
        {
            InitializeComponent();
            _clubService = new ClubService();
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Зареждаме данните през Service слоя
                dgvClubs.DataSource = _clubService.GetAllClubs();

                if (dgvClubs.Columns.Contains("id"))
                {
                    dgvClubs.Columns["id"].HeaderText = "ID";
                    dgvClubs.Columns["id"].Width = 50;
                }

                if (dgvClubs.Columns.Contains("name"))
                    dgvClubs.Columns["name"].HeaderText = "Име на клуба";

                if (dgvClubs.Columns.Contains("city"))
                    dgvClubs.Columns["city"].HeaderText = "Град";

                if (dgvClubs.Columns.Contains("stadium"))
                    dgvClubs.Columns["stadium"].HeaderText = "Стадион";

                if (dgvClubs.Columns.Contains("founded_year"))
                    dgvClubs.Columns["founded_year"].HeaderText = "Основан (година)";

                ConfigureGridAppearance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на данните: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridAppearance()
        {
            dgvClubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClubs.RowHeadersVisible = false;
            dgvClubs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClubs.MultiSelect = false;
            dgvClubs.ReadOnly = true;
            dgvClubs.BackgroundColor = System.Drawing.Color.White;
            dgvClubs.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        // Тази логика остава тук, защото е свързана с конвертирането на UI текст към данни (Model binding)
        private int GetFoundedYear()
        {
            if (string.IsNullOrWhiteSpace(txtFoundedYear.Text)) return 0;

            if (int.TryParse(txtFoundedYear.Text.Trim(), out int year))
            {
                return year;
            }
            else
            {
                throw new ArgumentException("Годината на основаване трябва да бъде цяло число!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Club newClub = new Club
                {
                    Name = txtName.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Stadium = txtStadium.Text.Trim(),
                    FoundedYear = GetFoundedYear()
                };

                _clubService.AddClub(newClub); // Валидацията се случва вътре в Service-а
                MessageBox.Show("Клубът е успешно добавен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (ArgumentException argEx) // Хващаме бизнес/UI валидацията
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при добавяне: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Моля, изберете клуб от списъка за редакция!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Club updatedClub = new Club
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Stadium = txtStadium.Text.Trim(),
                    FoundedYear = GetFoundedYear()
                };

                _clubService.UpdateClub(updatedClub);
                MessageBox.Show("Данните са обновени успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при редакция: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Моля, изберете клуб за изтриване!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да изтриете този клуб?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtId.Text);
                    _clubService.DeleteClub(id);
                    MessageBox.Show("Клубът е изтрит!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при изтриване: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvClubs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClubs.Rows[e.RowIndex];

                txtId.Text = row.Cells["id"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtCity.Text = row.Cells["city"].Value.ToString();
                txtStadium.Text = row.Cells["stadium"].Value.ToString();
                txtFoundedYear.Text = row.Cells["founded_year"].Value.ToString();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtCity.Clear();
            txtStadium.Clear();
            txtFoundedYear.Clear();
        }
    }
}