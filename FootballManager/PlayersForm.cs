using System;
using System.Data;
using System.Windows.Forms;

namespace FootballManager
{
    public partial class PlayersForm : Form
    {
        private PlayersRepository _repository;
        private bool isInitializing = true;

        public PlayersForm()
        {
            InitializeComponent();
            _repository = new PlayersRepository();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadData();
            isInitializing = false;
        }

        private void LoadDropdowns()
        {
            // Настройка на позициите (за филтъра и за добавяне)
            string[] positions = { "GK", "DF", "MF", "FW" };
            cboPosition.Items.AddRange(positions);

            cboPositionFilter.Items.Add("Всички");
            cboPositionFilter.Items.AddRange(positions);
            cboPositionFilter.SelectedIndex = 0;

            // Зареждане на клубове от базата
            DataTable clubsDb = _repository.GetClubsForDropdown();

            // Клонираме данните за филтъра и добавяме опция "Всички"
            DataTable clubsFilter = clubsDb.Copy();
            DataRow allRow = clubsFilter.NewRow();
            allRow["id"] = 0;
            allRow["name"] = "Всички";
            clubsFilter.Rows.InsertAt(allRow, 0);

            cboClubFilter.DataSource = clubsFilter;
            cboClubFilter.DisplayMember = "name";
            cboClubFilter.ValueMember = "id";

            // Клонираме данните за формата за добавяне и слагаме опция "Свободен агент"
            DataTable clubsInput = clubsDb.Copy();
            DataRow freeAgentRow = clubsInput.NewRow();
            freeAgentRow["id"] = 0;
            freeAgentRow["name"] = "--- Свободен агент ---";
            clubsInput.Rows.InsertAt(freeAgentRow, 0);

            cboClub.DataSource = clubsInput;
            cboClub.DisplayMember = "name";
            cboClub.ValueMember = "id";
        }

        private void LoadData()
        {
            try
            {
                // Взимане на стойностите от филтрите
                int clubId = Convert.ToInt32(cboClubFilter.SelectedValue);
                string position = cboPositionFilter.SelectedItem?.ToString();
                string search = txtSearchName.Text.Trim();

                dgvPlayers.DataSource = _repository.GetPlayers(clubId, position, search);

                // Скриване на системните колони
                if (dgvPlayers.Columns.Contains("id")) dgvPlayers.Columns["id"].Visible = false;
                if (dgvPlayers.Columns.Contains("current_club_id")) dgvPlayers.Columns["current_club_id"].Visible = false;

                // Разпъване на таблицата и настройки
                dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPlayers.MultiSelect = false;
                dgvPlayers.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Името и фамилията са задължителни!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPosition.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете валидна позиция (GK, DF, MF, FW)!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int age = DateTime.Today.Year - dtpBirthDate.Value.Year;
            if (dtpBirthDate.Value.Date > DateTime.Today.AddYears(-age)) age--;

            if (age < 10 || age > 60)
            {
                MessageBox.Show("Възрастта на играча трябва да е между 10 и 60 години!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                Player p = new Player
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    BirthDate = dtpBirthDate.Value,
                    Position = cboPosition.SelectedItem.ToString(),
                    Nationality = txtNationality.Text.Trim(),
                    KitNumber = (int)numKitNumber.Value,
                    CurrentClubId = Convert.ToInt32(cboClub.SelectedValue)
                };

                _repository.AddPlayer(p);
                MessageBox.Show("Играчът е добавен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при добавяне: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Изберете играч за редакция!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (!ValidateInput()) return;

            try
            {
                Player p = new Player
                {
                    Id = int.Parse(txtId.Text),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    BirthDate = dtpBirthDate.Value,
                    Position = cboPosition.SelectedItem.ToString(),
                    Nationality = txtNationality.Text.Trim(),
                    KitNumber = (int)numKitNumber.Value,
                    CurrentClubId = Convert.ToInt32(cboClub.SelectedValue)
                };

                _repository.UpdatePlayer(p);
                MessageBox.Show("Данните са обновени успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при редакция: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Изберете играч за изтриване!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (MessageBox.Show("Сигурни ли сте, че искате да изтриете този играч?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _repository.DeletePlayer(int.Parse(txtId.Text));
                    MessageBox.Show("Играчът е изтрит!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при изтриване: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPlayers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPlayers.Rows[e.RowIndex];

                txtId.Text = row.Cells["id"].Value.ToString();
                txtFirstName.Text = row.Cells["Име"].Value.ToString();
                txtLastName.Text = row.Cells["Фамилия"].Value.ToString();

                if (row.Cells["Дата на раждане"].Value != DBNull.Value)
                    dtpBirthDate.Value = Convert.ToDateTime(row.Cells["Дата на раждане"].Value);

                cboPosition.SelectedItem = row.Cells["Позиция"].Value.ToString();
                txtNationality.Text = row.Cells["Националност"].Value?.ToString();

                if (row.Cells["Номер"].Value != DBNull.Value)
                    numKitNumber.Value = Convert.ToDecimal(row.Cells["Номер"].Value);
                else
                    numKitNumber.Value = 1; // Default

                // Зареждане на клуба
                if (row.Cells["current_club_id"].Value != DBNull.Value)
                    cboClub.SelectedValue = row.Cells["current_club_id"].Value;
                else
                    cboClub.SelectedValue = 0; // Свободен агент
            }
        }

        private void cboClubFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
            LoadData();
        }
        private void cboPositionFilter_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (isInitializing) return;
            LoadData(); 
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e) => LoadData();

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            txtId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNationality.Clear();
            numKitNumber.Value = 1;
            cboPosition.SelectedIndex = -1;
            cboClub.SelectedIndex = 0; // Връща на "Свободен агент"
            dtpBirthDate.Value = DateTime.Today.AddYears(-20); // Слагаме 20-годишен по подразбиране
        }
    }
}