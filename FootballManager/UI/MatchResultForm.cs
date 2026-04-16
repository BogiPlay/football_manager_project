using FootballManager.BusinessLogic;
using FootballManager.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FootballManager.UI
{
    public partial class MatchResultForm : Form
    {
        private MatchResultService _matchResultService;
        private bool isInitializing = true;
        private int currentMatchId = 0;

        public MatchResultForm()
        {
            InitializeComponent();
            _matchResultService = new MatchResultService();
        }

        private void MatchResultForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboEventType.Items.AddRange(new string[] { "Гол", "Жълт картон", "Червен картон", "Фал" });
                cboEventType.SelectedIndex = 0;

                numMinute.Minimum = 1;
                numMinute.Maximum = 120;

                LoadMatches();
                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на формата: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMatches()
        {
            DataTable matchesDt = _matchResultService.GetMatchesForDropdown();
            cboMatch.DataSource = matchesDt;
            cboMatch.DisplayMember = "match_name";
            cboMatch.ValueMember = "id";
            cboMatch.SelectedIndex = -1;
        }

        private void cboMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || cboMatch.SelectedValue == null) return;

            currentMatchId = Convert.ToInt32(cboMatch.SelectedValue);

            // Взимаме данните за избрания мач (за да покажем резултата)
            DataRowView selectedMatch = (DataRowView)cboMatch.SelectedItem;
            string homeG = selectedMatch["home_goals"].ToString();
            string awayG = selectedMatch["away_goals"].ToString();
            string status = selectedMatch["status"].ToString();

            lblScore.Text = status == "Played" ? $"Резултат: {homeG} - {awayG}" : "Резултат: 0 - 0 (Неизигран)";

            LoadPlayersForCurrentMatch();
            LoadEvents();
        }

        private void LoadPlayersForCurrentMatch()
        {
            DataTable playersDt = _matchResultService.GetPlayersForMatch(currentMatchId);
            cboPlayer.DataSource = playersDt;
            cboPlayer.DisplayMember = "player_name";
            cboPlayer.ValueMember = "id";
            cboPlayer.SelectedIndex = -1;
        }

        private void LoadEvents()
        {
            dgvEvents.DataSource = _matchResultService.GetMatchEvents(currentMatchId);
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ReadOnly = true;
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (currentMatchId == 0) { MessageBox.Show("Изберете мач!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cboPlayer.SelectedValue == null) { MessageBox.Show("Изберете играч!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                DataRowView selectedPlayer = (DataRowView)cboPlayer.SelectedItem;

                // Създаваме модел с данните от UI
                MatchEvent newEvent = new MatchEvent
                {
                    MatchId = currentMatchId,
                    PlayerId = Convert.ToInt32(cboPlayer.SelectedValue),
                    ClubId = Convert.ToInt32(selectedPlayer["current_club_id"]),
                    EventType = cboEventType.SelectedItem.ToString(),
                    Minute = (int)numMinute.Value
                };

                // Пращаме към Service слоя
                _matchResultService.AddEvent(newEvent);

                MessageBox.Show("Събитието е добавено успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Презареждаме мачовете тихо (за да се обнови резултатът в падащото меню)
                isInitializing = true;
                int savedMatchId = currentMatchId;
                LoadMatches();
                cboMatch.SelectedValue = savedMatchId;
                isInitializing = false;

                // Обновяваме UI
                cboMatch_SelectedIndexChanged(null, null);

                // Изчистваме полетата за ново събитие
                cboPlayer.SelectedIndex = -1;
                numMinute.Value = 1;
            }
            catch (ArgumentException argEx) // Хващаме бизнес валидацията
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) // Хващаме системни грешки
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}