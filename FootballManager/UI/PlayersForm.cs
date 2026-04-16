using FootballManager.BusinessLogic; // Добавяме референция към BLL
using FootballManager.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FootballManager.UI // Добра практика е формата да е в UI namespace
{
    public partial class PlayersForm : Form
    {
        private PlayerService _playerService; // Заменяме Repository със Service
        private bool isInitializing = true;

        public PlayersForm()
        {
            InitializeComponent();
            _playerService = new PlayerService();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadData();
            isInitializing = false;
        }

        private void LoadDropdowns()
        {
            string[] positions = { "GK", "DF", "MF", "FW" };
            cboPosition.Items.AddRange(positions);

            cboPositionFilter.Items.Add("Всички");
            cboPositionFilter.Items.AddRange(positions);
            cboPositionFilter.SelectedIndex = 0;

            // Взимаме данните през Service слоя
            DataTable clubsDb = _playerService.GetClubsForDropdown();

            DataTable clubsFilter = clubsDb.Copy();
            DataRow allRow = clubsFilter.NewRow();
            allRow["id"] = 0;
            allRow["name"] = "Всички";
            clubsFilter.Rows.InsertAt(allRow, 0);

            cboClubFilter.DataSource = clubsFilter;
            cboClubFilter.DisplayMember = "name";
            cboClubFilter.ValueMember = "id";

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
                int clubId = Convert.ToInt32(cboClubFilter.SelectedValue);
                string position = cboPositionFilter.SelectedItem?.ToString();
                if (position == "Всички") position = null; // Подобрение за филтъра
                string search = txtSearchName.Text.Trim();

                // Взимаме играчите през Service слоя
                dgvPlayers.DataSource = _playerService.GetPlayers(clubId, position, search);

                if (dgvPlayers.Columns.Contains("id")) dgvPlayers.Columns["id"].Visible = false;
                if (dgvPlayers.Columns.Contains("current_club_id")) dgvPlayers.Columns["current_club_id"].Visible = false;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Player p = new Player
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    BirthDate = dtpBirthDate.Value,
                    Position = cboPosition.SelectedItem?.ToString(),
                    Nationality = txtNationality.Text.Trim(),
                    KitNumber = (int)numKitNumber.Value,
                    CurrentClubId = Convert.ToInt32(cboClub.SelectedValue)
                };

                _playerService.AddPlayer(p); // Service-ът ще валидира и добави
                MessageBox.Show("Играчът е добавен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (ArgumentException argEx) // Хващаме валидационните грешки от BLL
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) // Хващаме системни/базови грешки
            {
                MessageBox.Show("Грешка при добавяне: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Изберете играч за редакция!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Player p = new Player
                {
                    Id = int.Parse(txtId.Text),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    BirthDate = dtpBirthDate.Value,
                    Position = cboPosition.SelectedItem?.ToString(),
                    Nationality = txtNationality.Text.Trim(),
                    KitNumber = (int)numKitNumber.Value,
                    CurrentClubId = Convert.ToInt32(cboClub.SelectedValue)
                };

                _playerService.UpdatePlayer(p);
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
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Изберете играч за изтриване!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Сигурни ли сте, че искате да изтриете този играч?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _playerService.DeletePlayer(int.Parse(txtId.Text));
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
                    numKitNumber.Value = 1;

                if (row.Cells["current_club_id"].Value != DBNull.Value)
                    cboClub.SelectedValue = row.Cells["current_club_id"].Value;
                else
                    cboClub.SelectedValue = 0;
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
            cboClub.SelectedIndex = 0;
            dtpBirthDate.Value = DateTime.Today.AddYears(-20);
        }
    }
}