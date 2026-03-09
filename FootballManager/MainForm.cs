using System;
using System.Windows.Forms;

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
    }
}