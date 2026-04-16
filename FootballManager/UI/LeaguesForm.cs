using FootballManager.BusinessLogic;
using FootballManager.Models;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FootballManager.UI
{
    public partial class LeaguesForm : Form
    {
        private LeagueService _leagueService;
        private bool isInitializing = true;
        private int currentLeagueId = 0;

        public LeaguesForm()
        {
            InitializeComponent();
            _leagueService = new LeagueService();
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
            dgvLeagues.DataSource = _leagueService.GetAllLeagues();
            if (dgvLeagues.Columns.Contains("id")) dgvLeagues.Columns["id"].Visible = false;

            dgvLeagues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeagues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeagues.MultiSelect = false;
            dgvLeagues.ReadOnly = true;
        }

        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            try
            {
                League l = new League
                {
                    Name = txtName.Text.Trim(),
                    Season = txtSeason.Text.Trim()
                };

                _leagueService.AddLeague(l);
                LoadLeagues();
                ClearLeagueFields();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException invEx) // Хващаме MySQL грешките, които Service-ът е превел
            {
                MessageBox.Show(invEx.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Изберете лига!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                League l = new League
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text.Trim(),
                    Season = txtSeason.Text.Trim()
                };

                _leagueService.UpdateLeague(l);
                LoadLeagues();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException invEx)
            {
                MessageBox.Show(invEx.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return;

            if (MessageBox.Show("Сигурни ли сте, че искате да изтриете тази лига?", "Изтриване", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _leagueService.DeleteLeague(int.Parse(txtId.Text));
                    LoadLeagues();
                    ClearLeagueFields();
                }
                catch (InvalidOperationException invEx)
                {
                    MessageBox.Show(invEx.Message, "Забранено действие", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearLeague_Click(object sender, EventArgs e)
        {
            ClearLeagueFields();
        }

        private void ClearLeagueFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtSeason.Clear();
            currentLeagueId = 0;
            dgvParticipants.DataSource = null;
            cboAvailableClubs.DataSource = null;
        }

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
                dgvParticipants.DataSource = _leagueService.GetParticipants(currentLeagueId);
                if (dgvParticipants.Columns.Contains("id")) dgvParticipants.Columns["id"].Visible = false;

                dgvParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvParticipants.ReadOnly = true;

                DataTable available = _leagueService.GetAvailableClubs(currentLeagueId);
                cboAvailableClubs.DataSource = available;
                cboAvailableClubs.DisplayMember = "name";
                cboAvailableClubs.ValueMember = "id";
                cboAvailableClubs.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на участниците: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddClubToLeague_Click(object sender, EventArgs e)
        {
            if (currentLeagueId == 0) { MessageBox.Show("Първо изберете лига!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cboAvailableClubs.SelectedValue == null) { MessageBox.Show("Изберете клуб за добавяне!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                int clubId = Convert.ToInt32(cboAvailableClubs.SelectedValue);
                _leagueService.AddClubToLeague(currentLeagueId, clubId);

                LoadParticipantsPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при добавяне: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveClubFromLeague_Click(object sender, EventArgs e)
        {
            if (currentLeagueId == 0) return;
            if (dgvParticipants.CurrentRow == null) { MessageBox.Show("Изберете отбор от списъка с участници за премахване!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int clubId = Convert.ToInt32(dgvParticipants.CurrentRow.Cells["id"].Value);
            string clubName = dgvParticipants.CurrentRow.Cells["Клуб"].Value.ToString();

            if (MessageBox.Show($"Премахване на {clubName} от тази лига?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _leagueService.RemoveClubFromLeague(currentLeagueId, clubId);
                    LoadParticipantsPanel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при премахване: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}