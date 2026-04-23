using System;
using System.Windows.Forms;
using FootballManager.UI;

namespace FootballManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenClubs_Click(object sender, EventArgs e)
        {
            ClubsForm clubsForm = new ClubsForm();
            clubsForm.ShowDialog();
        }

        private void btnOpenPlayers_Click(object sender, EventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();
            playersForm.ShowDialog();
        }

        private void btnOpenTransfers_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm();
            transfersForm.ShowDialog();
        }

        private void btnOpenLeagues_Click(object sender, EventArgs e)
        {
            LeaguesForm leaguesForm = new LeaguesForm();
            leaguesForm.ShowDialog();
        }

        private void btnOpenSchedule_Click(object sender, EventArgs e)
        {
            ScheduleForm scheduleForm = new ScheduleForm();
            scheduleForm.ShowDialog();
        }

        private void btnOpenMatches_Click(object sender, EventArgs e)
        {
            MatchResultForm matchResultForm = new MatchResultForm();
            matchResultForm.ShowDialog();
        }

        private void btnOpenStandings_Click(object sender, EventArgs e)
        {
            StandingsForm standingsForm = new StandingsForm();
            standingsForm.ShowDialog();
        }
    }
}