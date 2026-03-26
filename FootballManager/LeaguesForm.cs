using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FootballManager
{
    public partial class LeaguesForm : Form
    {
        private LeaguesRepository _repository;
        private bool isInitializing = true;

        // Пази ID-то на маркираната в момента лига
        private int currentLeagueId = 0;

        public LeaguesForm()
        {
            InitializeComponent();
            _repository = new LeaguesRepository();
        }

        private void LeaguesForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLeagues();
                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= УПРАВЛЕНИЕ НА ЛИГИ (ЛЯВ ПАНЕЛ) =================

        private void LoadLeagues()
        {
            dgvLeagues.DataSource = _repository.GetAllLeagues();
            if (dgvLeagues.Columns.Contains("id")) dgvLeagues.Columns["id"].Visible = false;

            dgvLeagues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeagues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeagues.MultiSelect = false;
            dgvLeagues.ReadOnly = true;
        }

        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSeason.Text))
            {
                MessageBox.Show("Името и сезонът са задължителни!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            try
            {
                League l = new League { Name = txtName.Text.Trim(), Season = txtSeason.Text.Trim() };
                _repository.AddLeague(l);
                LoadLeagues();
                ClearLeagueFields();
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Грешка за дублиране (UNIQUE constraint)
            {
                MessageBox.Show("Лига с това име и сезон вече съществува!", "Дублиране", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }

        private void btnEditLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) { MessageBox.Show("Изберете лига!"); return; }

            try
            {
                League l = new League
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text.Trim(),
                    Season = txtSeason.Text.Trim()
                };
                _repository.UpdateLeague(l);
                LoadLeagues();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Лига с това име и сезон вече съществува!", "Дублиране", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return;

            if (MessageBox.Show("Сигурни ли сте, че искате да изтриете тази лига?", "Изтриване", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _repository.DeleteLeague(int.Parse(txtId.Text));
                    LoadLeagues();
                    ClearLeagueFields();
                }
                catch (MySqlException ex) when (ex.Number == 1451) // Foreign Key constraint error
                {
                    MessageBox.Show("Тази лига не може да бъде изтрита, защото в нея има записани отбори!", "Забранено действие", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnClearLeague_Click(object sender, EventArgs e)
        {
            ClearLeagueFields();
        }

        private void ClearLeagueFields()
        {
            txtId.Clear(); txtName.Clear(); txtSeason.Clear();
            currentLeagueId = 0;
            dgvParticipants.DataSource = null;
            cboAvailableClubs.DataSource = null;
        }

        // Когато потребителят кликне върху лига, зареждаме участниците в десния панел
        private void dgvLeagues_SelectionChanged(object sender, EventArgs e)
        {
            if (isInitializing || dgvLeagues.CurrentRow == null) return;

            currentLeagueId = Convert.ToInt32(dgvLeagues.CurrentRow.Cells["id"].Value);

            txtId.Text = currentLeagueId.ToString();
            txtName.Text = dgvLeagues.CurrentRow.Cells["Име на лига"].Value.ToString();
            txtSeason.Text = dgvLeagues.CurrentRow.Cells["Сезон"].Value.ToString();

            LoadParticipantsPanel();
        }

        // ================= УПРАВЛЕНИЕ НА УЧАСТНИЦИ (ДЕСЕН ПАНЕЛ) =================

        private void LoadParticipantsPanel()
        {
            if (currentLeagueId == 0) return;

            try
            {
                // Зареждане на таблицата с участници
                dgvParticipants.DataSource = _repository.GetParticipants(currentLeagueId);
                if (dgvParticipants.Columns.Contains("id")) dgvParticipants.Columns["id"].Visible = false;

                dgvParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvParticipants.ReadOnly = true;

                // Зареждане на падащото меню със СВОБОДНИ клубове
                DataTable available = _repository.GetAvailableClubs(currentLeagueId);
                cboAvailableClubs.DataSource = available;
                cboAvailableClubs.DisplayMember = "name";
                cboAvailableClubs.ValueMember = "id";
                cboAvailableClubs.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на участниците: " + ex.Message);
            }
        }

        private void btnAddClubToLeague_Click(object sender, EventArgs e)
        {
            if (currentLeagueId == 0) { MessageBox.Show("Първо изберете лига!"); return; }
            if (cboAvailableClubs.SelectedValue == null) { MessageBox.Show("Изберете клуб за добавяне!"); return; }

            try
            {
                int clubId = Convert.ToInt32(cboAvailableClubs.SelectedValue);
                _repository.AddClubToLeague(currentLeagueId, clubId);

                // Презареждаме десния панел (клубът се мести от менюто в таблицата)
                LoadParticipantsPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при добавяне: " + ex.Message);
            }
        }

        private void btnRemoveClubFromLeague_Click(object sender, EventArgs e)
        {
            if (currentLeagueId == 0) return;
            if (dgvParticipants.CurrentRow == null) { MessageBox.Show("Изберете отбор от списъка с участници за премахване!"); return; }

            int clubId = Convert.ToInt32(dgvParticipants.CurrentRow.Cells["id"].Value);
            string clubName = dgvParticipants.CurrentRow.Cells["Клуб"].Value.ToString();

            if (MessageBox.Show($"Премахване на {clubName} от тази лига?", "Потвърждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _repository.RemoveClubFromLeague(currentLeagueId, clubId);
                    LoadParticipantsPanel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при премахване: " + ex.Message);
                }
            }
        }
    }
}