using System;
using System.Data;
using System.Windows.Forms;

namespace FootballManager
{
    public partial class MatchResultForm : Form
    {
        private MatchResultRepository _repository;
        private bool isInitializing = true;
        private int currentMatchId = 0;

        public MatchResultForm()
        {
            InitializeComponent();
            _repository = new MatchResultRepository();
        }

        private void MatchResultForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Зареждаме видовете събития
                cboEventType.Items.AddRange(new string[] { "Гол", "Жълт картон", "Червен картон", "Фал" });
                cboEventType.SelectedIndex = 0;

                // Настройваме минутите
                numMinute.Minimum = 1;
                numMinute.Maximum = 120;

                LoadMatches();
                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }

        private void LoadMatches()
        {
            DataTable matchesDt = _repository.GetMatchesForDropdown();
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

            // Зареждаме САМО играчите от този мач!
            LoadPlayersForCurrentMatch();

            // Зареждаме хронологията на събитията
            LoadEvents();
        }

        private void LoadPlayersForCurrentMatch()
        {
            DataTable playersDt = _repository.GetPlayersForMatch(currentMatchId);
            cboPlayer.DataSource = playersDt;
            cboPlayer.DisplayMember = "player_name";
            cboPlayer.ValueMember = "id";
            cboPlayer.SelectedIndex = -1;
        }

        private void LoadEvents()
        {
            dgvEvents.DataSource = _repository.GetMatchEvents(currentMatchId);
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ReadOnly = true;
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (currentMatchId == 0) { MessageBox.Show("Изберете мач!"); return; }
            if (cboPlayer.SelectedValue == null) { MessageBox.Show("Изберете играч!"); return; }

            int minute = (int)numMinute.Value;
            if (minute < 1 || minute > 120) { MessageBox.Show("Минутата трябва да е между 1 и 120!"); return; }

            try
            {
                int playerId = Convert.ToInt32(cboPlayer.SelectedValue);
                string eventType = cboEventType.SelectedItem.ToString();

                // Взимаме Club ID директно от избрания ред в менюто
                DataRowView selectedPlayer = (DataRowView)cboPlayer.SelectedItem;
                int clubId = Convert.ToInt32(selectedPlayer["current_club_id"]);

                // Записваме събитието (и автоматично обновяваме резултата, ако е гол)
                _repository.AddEvent(currentMatchId, playerId, clubId, eventType, minute);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}