using System;
using System.Data;
using System.Windows.Forms;

namespace FootballManager
{
    public partial class TransfersForm : Form
    {
        private TransfersRepository _repository;
        private bool isInitializing = true;

        public TransfersForm()
        {
            InitializeComponent();
            _repository = new TransfersRepository();
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
            cboToClub.DataSource = _repository.GetClubsForDropdown();
            cboToClub.DisplayMember = "name";
            cboToClub.ValueMember = "id";
            cboToClub.SelectedIndex = -1;

            // 2. Зареждаме играчите (основното меню)
            DataTable playersDt = _repository.GetPlayersForDropdown();
            cboPlayer.DataSource = playersDt;
            cboPlayer.DisplayMember = "full_name";
            cboPlayer.ValueMember = "id";
            cboPlayer.SelectedIndex = -1;

            // 3. БЕЗОПАСЕН ФИЛТЪР ПО ИГРАЧ
            // Вместо да копираме цялата таблица и да се борим с ограничения за NULL, 
            // създаваме чисто нова, проста таблица само с 2 колони (ID и Име).
            DataTable playersFilterDt = new DataTable();
            playersFilterDt.Columns.Add("id", typeof(int));
            playersFilterDt.Columns.Add("full_name", typeof(string));

            // Добавяме нулевия ред
            playersFilterDt.Rows.Add(0, "Всички играчи");

            // Прехвърляме играчите един по един
            foreach (DataRow row in playersDt.Rows)
            {
                playersFilterDt.Rows.Add(row["id"], row["full_name"]);
            }

            cboPlayerFilter.DataSource = playersFilterDt;
            cboPlayerFilter.DisplayMember = "full_name";
            cboPlayerFilter.ValueMember = "id";
        }
        private void LoadHistory()
        {
            try
            {
                int.TryParse(cboPlayerFilter.SelectedValue?.ToString(), out int playerId);
                dgvTransfers.DataSource = _repository.GetTransfersHistory(playerId);

                if (dgvTransfers.Columns.Contains("id")) dgvTransfers.Columns["id"].Visible = false;

                dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTransfers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTransfers.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на историята: " + ex.Message);
            }
        }

        private void cboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || cboPlayer.SelectedItem == null) return;

            DataRowView selectedPlayer = (DataRowView)cboPlayer.SelectedItem;

            // Просто показваме името на клуба в полето за четене
            txtFromClub.Text = selectedPlayer["current_club_name"].ToString();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            // ВАЛИДАЦИИ
            if (cboPlayer.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете играч!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (cboToClub.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете целеви клуб!", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            int toClubId = Convert.ToInt32(cboToClub.SelectedValue);

            // Взимаме избрания играч директно от менюто
            DataRowView selectedPlayer = (DataRowView)cboPlayer.SelectedItem;

            // Взимаме му текущия клуб директно от базата (ако не е свободен агент)
            int? fromClubId = null;
            if (selectedPlayer["current_club_id"] != DBNull.Value)
            {
                fromClubId = Convert.ToInt32(selectedPlayer["current_club_id"]);
            }

            // ЗАДЪЛЖИТЕЛНА ВАЛИДАЦИЯ: Не може в същия клуб!
            if (fromClubId == toClubId)
            {
                MessageBox.Show("Играчът вече е в този клуб! Трансферът е невъзможен.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Изпълнение на трансфера
            try
            {
                Transfer newTransfer = new Transfer
                {
                    PlayerId = Convert.ToInt32(cboPlayer.SelectedValue),
                    FromClubId = fromClubId, // ВЕЧЕ ИЗПОЛЗВАМЕ 100% ТОЧНАТА СТОЙНОСТ!
                    ToClubId = toClubId,
                    TransferDate = dtpTransferDate.Value,
                    TransferFee = numFee.Value
                };

                _repository.ExecuteTransfer(newTransfer);

                MessageBox.Show("Трансферът е осъществен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Презареждаме
                isInitializing = true;
                LoadDropdowns();
                isInitializing = false;

                LoadHistory();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Критична грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadHistory();
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