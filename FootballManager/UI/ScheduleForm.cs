using FootballManager.BusinessLogic;
using System;
using System.Windows.Forms;

namespace FootballManager.UI
{
    public partial class ScheduleForm : Form
    {
        private ScheduleService _scheduleService;
        private bool isInitializing = true;

        public ScheduleForm()
        {
            InitializeComponent();
            _scheduleService = new ScheduleService(); // Използваме новия Service
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboLeague.DataSource = _scheduleService.GetLeaguesForDropdown();
                cboLeague.DisplayMember = "league_info";
                cboLeague.ValueMember = "id";
                cboLeague.SelectedIndex = -1;

                dtpStartDate.Value = DateTime.Today.AddDays(7);
                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || cboLeague.SelectedValue == null) return;
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            try
            {
                int leagueId = Convert.ToInt32(cboLeague.SelectedValue);
                dgvSchedule.DataSource = _scheduleService.GetScheduleDisplay(leagueId);

                dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSchedule.ReadOnly = true;
                dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на програмата: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboLeague.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете първенство!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int leagueId = Convert.ToInt32(cboLeague.SelectedValue);

            try
            {
                // Цялата магия (проверки, алгоритми, запис в базата) се случва тук:
                _scheduleService.GenerateAndSaveSchedule(leagueId, dtpStartDate.Value);

                MessageBox.Show("Програмата беше генерирана успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScheduleData();
            }
            catch (InvalidOperationException invEx) // Хващаме бизнес грешките (напр. "вече има програма")
            {
                MessageBox.Show(invEx.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex) // Хващаме системни грешки
            {
                MessageBox.Show(ex.Message, "Критична грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}