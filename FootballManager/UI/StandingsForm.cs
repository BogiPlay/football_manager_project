using FootballManager.BusinessLogic;
using FootballManager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootballManager.UI
{
    public partial class StandingsForm : Form
    {
        private StandingsService _standingsService;
        private bool isInitializing = true;

        public StandingsForm()
        {
            InitializeComponent();
            _standingsService = new StandingsService();
        }

        private void StandingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboLeague.DataSource = _standingsService.GetLeaguesForDropdown();
                cboLeague.DisplayMember = "league_info";
                cboLeague.ValueMember = "id";
                cboLeague.SelectedIndex = -1;

                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на лигите: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || cboLeague.SelectedValue == null) return;
            LoadStandings();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cboLeague.SelectedValue == null) return;
            LoadStandings();
        }

        private void LoadStandings()
        {
            try
            {
                int leagueId = Convert.ToInt32(cboLeague.SelectedValue);

                // Взимаме готовия списък от Service слоя
                List<Standing> standings = _standingsService.CalculateStandings(leagueId);

                dgvStandings.DataSource = standings;

                // Скриваме техническите колони, които не ни трябват в UI
                if (dgvStandings.Columns.Contains("ClubId")) dgvStandings.Columns["ClubId"].Visible = false;
                if (dgvStandings.Columns.Contains("GoalsFor")) dgvStandings.Columns["GoalsFor"].Visible = false;
                if (dgvStandings.Columns.Contains("GoalsAgainst")) dgvStandings.Columns["GoalsAgainst"].Visible = false;

                // Преименуваме колоните на български
                if (dgvStandings.Columns.Contains("Position")) dgvStandings.Columns["Position"].HeaderText = "№";
                if (dgvStandings.Columns.Contains("ClubName")) dgvStandings.Columns["ClubName"].HeaderText = "Отбор";
                if (dgvStandings.Columns.Contains("MatchesPlayed")) dgvStandings.Columns["MatchesPlayed"].HeaderText = "Мачове";
                if (dgvStandings.Columns.Contains("Wins")) dgvStandings.Columns["Wins"].HeaderText = "Победи";
                if (dgvStandings.Columns.Contains("Draws")) dgvStandings.Columns["Draws"].HeaderText = "Равни";
                if (dgvStandings.Columns.Contains("Losses")) dgvStandings.Columns["Losses"].HeaderText = "Загуби";
                if (dgvStandings.Columns.Contains("Goals")) dgvStandings.Columns["Goals"].HeaderText = "Голове (В:Д)";
                if (dgvStandings.Columns.Contains("GoalDifference")) dgvStandings.Columns["GoalDifference"].HeaderText = "Голова разлика";
                if (dgvStandings.Columns.Contains("Points")) dgvStandings.Columns["Points"].HeaderText = "Точки";

                // Настройки за външен вид
                dgvStandings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStandings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvStandings.ReadOnly = true;

                // Правим първата колона (Позиция) по-тясна
                if (dgvStandings.Columns.Contains("Position"))
                    dgvStandings.Columns["Position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при пресмятане на класирането: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}