using FootballManager.BusinessLogic;
using FootballManager.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FootballManager.UI
{
    public partial class TransfersForm : Form
    {
        private TransferService _transferService;
        private bool isInitializing = true;

        public TransfersForm()
        {
            InitializeComponent();
            _transferService = new TransferService();
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDropdowns();
                LoadHistory();

                isInitializing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при стартиране на формата: " + ex.Message, "Критична грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDropdowns()
        {
            // 1. Зареждаме клубовете
            cboToClub.DataSource = _transferService.GetClubsForDropdown();
            cboToClub.DisplayMember = "name";
            cboToClub.ValueMember = "id";
            cboToClub.SelectedIndex = -1;

            // 2. Зареждаме играчите (основното меню)
            cboPlayer.DataSource = _transferService.GetPlayersForDropdown();
            cboPlayer.DisplayMember = "full_name";
            cboPlayer.ValueMember = "id";
            cboPlayer.SelectedIndex = -1;

            // 3. Зареждаме готовия филтър директно от Service слоя
            cboPlayerFilter.DataSource = _transferService.GetPlayersForFilter();
            cboPlayerFilter.DisplayMember = "full_name";
            cboPlayerFilter.ValueMember = "id";
        }

        private void LoadHistory()
        {
            try
            {
                int.TryParse(cboPlayerFilter.SelectedValue?.ToString(), out int playerId);
                dgvTransfers.DataSource = _transferService.GetTransfersHistory(playerId);

                if (dgvTransfers.Columns.Contains("id")) dgvTransfers.Columns["id"].Visible = false;

                dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTransfers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTransfers.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на историята: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || cboPlayer.SelectedItem == null) return;

            DataRowView selectedPlayer = (DataRowView)cboPlayer.SelectedItem;

            // Показваме името на текущия клуб в полето за четене
            txtFromClub.Text = selectedPlayer["current_club_name"].ToString();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (cboPlayer.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете играч!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (cboToClub.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете целеви клуб!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // Извличаме данни от UI
            DataRowView selectedPlayer = (DataRowView)cboPlayer.SelectedItem;
            int? fromClubId = null;
            if (selectedPlayer["current_club_id"] != DBNull.Value)
            {
                fromClubId = Convert.ToInt32(selectedPlayer["current_club_id"]);
            }

            try
            {
                Transfer newTransfer = new Transfer
                {
                    PlayerId = Convert.ToInt32(cboPlayer.SelectedValue),
                    FromClubId = fromClubId,
                    ToClubId = Convert.ToInt32(cboToClub.SelectedValue),
                    TransferDate = dtpTransferDate.Value,
                    TransferFee = numFee.Value
                };

                // Всички проверки за коректност (напр. дали не е същия клуб) се правят вътре
                _transferService.ExecuteTransfer(newTransfer);

                MessageBox.Show("Трансферът е осъществен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Презареждаме
                isInitializing = true;
                LoadDropdowns();
                isInitializing = false;

                LoadHistory();
                ClearForm();
            }
            catch (ArgumentException argEx) // Хващаме проблеми с невалидни данни
            {
                MessageBox.Show(argEx.Message, "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException invEx) // Хващаме бизнес грешките (опит за трансфер в същия клуб)
            {
                MessageBox.Show(invEx.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Хващаме системни грешки
            {
                MessageBox.Show(ex.Message, "Критична грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPlayerFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
            LoadHistory();
        }

        private void ClearForm()
        {
            cboPlayer.SelectedIndex = -1;
            cboToClub.SelectedIndex = -1;
            txtFromClub.Clear();
            numFee.Value = 0;
        }
    }
}