using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FootballManager
{
    public partial class ScheduleForm : Form
    {
        private ScheduleRepository _repository;
        private bool isInitializing = true;

        public ScheduleForm()
        {
            InitializeComponent();
            _repository = new ScheduleRepository();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboLeague.DataSource = _repository.GetLeaguesForDropdown();
                cboLeague.DisplayMember = "league_info";
                cboLeague.ValueMember = "id";
                cboLeague.SelectedIndex = -1;

                dtpStartDate.Value = DateTime.Today.AddDays(7); // По подразбиране започва след седмица

                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане: " + ex.Message);
            }
        }

        private void cboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || cboLeague.SelectedValue == null) return;
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            int leagueId = Convert.ToInt32(cboLeague.SelectedValue);
            dgvSchedule.DataSource = _repository.GetScheduleDisplay(leagueId);

            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboLeague.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете първенство!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            int leagueId = Convert.ToInt32(cboLeague.SelectedValue);

            // 1. Проверка дали вече има програма (Бонус изискване)
            if (_repository.HasSchedule(leagueId))
            {
                MessageBox.Show("Това първенство вече има генерирана програма!", "Забранено действие", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 2. Взимане на участниците
            List<int> teamIds = _repository.GetLeagueTeamIds(leagueId);

            // 3. Валидация за минимален брой участници
            if (teamIds.Count < 2)
            {
                MessageBox.Show("Необходими са поне 2 отбора в лигата за генериране на програма!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. ГЕНЕРИРАНЕ ЧРЕЗ ROUND-ROBIN АЛГОРИТЪМ
            try
            {
                List<Match> schedule = GenerateRoundRobin(leagueId, teamIds, dtpStartDate.Value);
                _repository.SaveSchedule(schedule);

                MessageBox.Show("Програмата беше генерирана успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScheduleData(); // Показваме резултата веднага
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Критична грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= АЛГОРИТЪМ ЗА ГЕНЕРИРАНЕ =================
        private List<Match> GenerateRoundRobin(int leagueId, List<int> teams, DateTime startDate)
        {
            List<Match> matches = new List<Match>();

            // Ако отборите са нечетен брой, добавяме "почиващ" отбор (ID = -1)
            if (teams.Count % 2 != 0) teams.Add(-1);

            int numTeams = teams.Count;
            int numDays = numTeams - 1;       // Брой кръгове в полусезон
            int halfSize = numTeams / 2;      // Брой мачове на кръг

            // Въртим се за всеки кръг
            for (int round = 0; round < numDays; round++)
            {
                for (int i = 0; i < halfSize; i++)
                {
                    int home = teams[i];
                    int away = teams[numTeams - 1 - i];

                    // Ако нито един от двата отбора не е "почиващия"
                    if (home != -1 && away != -1)
                    {
                        // Първи полусезон (Домакинство)
                        matches.Add(new Match
                        {
                            LeagueId = leagueId,
                            RoundNo = round + 1,
                            HomeClubId = home,
                            AwayClubId = away,
                            MatchDate = startDate.AddDays(round * 7) // Мачовете са през 7 дни
                        });

                        // Втори полусезон (Гостуване - размяна) - БОНУС ТОЧКИ
                        matches.Add(new Match
                        {
                            LeagueId = leagueId,
                            RoundNo = round + 1 + numDays,
                            HomeClubId = away,
                            AwayClubId = home,
                            MatchDate = startDate.AddDays((round + numDays) * 7)
                        });
                    }
                }

                // Завъртане на отборите (оставяме първия на място, другите се въртят по часовниковата стрелка)
                int lastTeam = teams[teams.Count - 1];
                teams.RemoveAt(teams.Count - 1);
                teams.Insert(1, lastTeam);
            }

            // Връщаме мачовете сортирани по кръг
            return matches.OrderBy(m => m.RoundNo).ToList();
        }
    }
}